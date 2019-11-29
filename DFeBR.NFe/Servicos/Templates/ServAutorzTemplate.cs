// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:09/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Schema; 
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Autorizacao;
using DFeBR.EmissorNFe.Servicos.Interfaces;
using DFeBR.EmissorNFe.Servicos.Retornos;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Entidades;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Templates
{
    public abstract class ServAutorzTemplate : IServAutorzTemplate
    {
        #region Variaveis Globais

        /// <summary>
        ///     Quantidade de solicitações processadas
        /// </summary>
        private static int _processadas;

        /// <summary>
        ///     Quantidade de solicitações rejeitadas ou denegadas
        /// </summary>
        private static int _rejeitadas;

        #endregion

        #region Propriedades

        /// <summary>
        ///     Tipo do serviço
        /// </summary>
        public string NomeServico => "Autorização de NFe";
          

        #endregion

        #region Construtor

        protected ServAutorzTemplate(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, int idlote,
                ICollection<NFe> nFes, VersaoServico versao, bool compactarMensagem = false)
        {
            _certificadoDigital = certificado ?? throw new ArgumentNullException(nameof(certificado));
            _emisorEmissorServicoConfig = emissorServicoConfig ?? throw new ArgumentNullException(nameof(emissorServicoConfig));
            _servicoBase = new ServHttpSoapBase(emissorServicoConfig, certificado, NomeServico);
            _nFes = nFes;
            _idlote = idlote;
            _compactarMensagem = compactarMensagem;
            _versao = versao; 
        }

        protected ServAutorzTemplate(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, string xml,
                VersaoServico versao, bool compactarMensagem = false)
        {
            _certificadoDigital = certificado ?? throw new ArgumentNullException(nameof(certificado));
            _emisorEmissorServicoConfig = emissorServicoConfig ?? throw new ArgumentNullException(nameof(emissorServicoConfig));
            _servicoBase = new ServHttpSoapBase(emissorServicoConfig, certificado, NomeServico);
            _nFes = null;
            _idlote = 1;
            _compactarMensagem = compactarMensagem;
            _versao = versao;
            _xmlNfe = xml; 
        }

        #endregion

        /// <summary>
        ///     Certificado Digital
        /// </summary>
        private readonly X509Certificate2 _certificadoDigital;

        /// <summary>
        ///     Serviço Base
        /// </summary>
        private readonly IServHttpSoapBase _servicoBase;

        /// <summary>
        ///     Url do serviço
        /// </summary>
        private string _urlServico;

        /// <summary>
        ///     Url WSDL do serviço
        /// </summary>
        private string _urlWsdlServico;

        /// <summary>
        ///     Dados de configuração do emissor
        /// </summary>
        private readonly EmissorServicoConfig _emisorEmissorServicoConfig;

        /// <summary>
        ///     Dados da NFe
        /// </summary>
        private readonly ICollection<NFe> _nFes;

        /// <summary>
        ///     String Xml bem formado contendo informações de uma NFe
        /// </summary>
        private readonly string _xmlNfe;

        /// <summary>
        ///     Número do Lote
        /// </summary>
        private readonly int _idlote;

        /// <summary>
        ///     Compactar mensagem
        /// </summary>
        private readonly bool _compactarMensagem;

        /// <summary>
        ///     Versão da NFe
        /// </summary>
        private readonly VersaoServico _versao;

        /// <summary>
        ///     True, dados enviados em modo contingencia
        /// </summary>
        private bool _contingencia;

        /// <summary>
        ///     Obter url de contingência
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string ObterUrlContingencia(NFe entity)
        {
            //Tratar para ambiente de produção 
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _contingencia = true;

            //Sendo o modelo 65, entao continuar com o mesmo endereço
            var modelo = entity.infNFe.ide.mod;
            if (modelo == ModeloDocumento.NfCe) return ObterUrlServicoNormal(entity);
            //Sendo modelo 55, entao verificar o tipo de emissão escolhida
            var tpEmissao = entity.infNFe.ide.tpEmis;
            switch (tpEmissao)
            {
                case TipoEmissao.ContingenciaDpec:
                    return _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Producao.ContingenciaDpec;
                case TipoEmissao.ContingenciaSvcAn:
                    return _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Producao.ContingenciaSvcan;
                case TipoEmissao.ContingenciaSvcRs:
                    return _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Producao.ContingenciaSvcrs;
                default:
                    throw new ArgumentOutOfRangeException(
                            $"Não foram encontrados os tipo de emissão em contigência SVC-AN, DPEC ou SVC-RS ");
            }
        }

        /// <summary>
        ///     Obter endereço serviço
        /// <para>O tipo selecionado na tag NFe.infNFe.ide.tpEmis direciona para qual url deve ser direcionado o serviço, se normal ou em contingencia</para>
        /// </summary>
        /// <returns></returns>
        private string ObterUrlServico(NFe entity)
        {
            //O tipo selecionado na tag NFe.infNFe.ide.tpEmis direciona para qual url deve ser direcionado o serviço, se normal ou em contingencia
            //Verificar pelo tipo de emissão se trata-se de emissão em contingencia
            _contingencia = false;
            var tpEmissao = entity.infNFe.ide.tpEmis;
            //Obter uma url em contingencia por ter sido informado o tipo de emissão diferente de normal
            if (tpEmissao != TipoEmissao.Normal) return ObterUrlContingencia(entity);

            //Obter uma url para um serviço de envio normal
            return ObterUrlServicoNormal(entity);
        }

        /// <summary>
        ///     Obter Url para ambiente normal
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string ObterUrlServicoNormal(NFe entity)
        {
            //Obter uma url para tipo de emissão normal
            switch (entity.infNFe.ide.mod)
            {
                case ModeloDocumento.NFe:
                    var url = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                            ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Homologacao.Autoriza
                            : _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Producao.Autoriza;
                    return url;
                case ModeloDocumento.NfCe:
                    var url1 = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                            ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Homologacao.Autoriza
                            : _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Producao.Autoriza;
                    return url1;
                default:
                    throw new ArgumentOutOfRangeException("Modelo de documento não suportado para o serviço");
            }
        }

        /// <summary>
        ///     Processar envio e retorno da mensagem
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        private IRetAutorz ProcessarEnvioMensagem(enviNFe d1)
        {
            var soapXml = ObterCorpoMensagemSoap(_urlWsdlServico, d1);
            SalvarArquivoLoteEnviado(soapXml);
            var ws = _servicoBase.ObterRequisicaoSoap(_urlServico, soapXml);
             var resposta = _servicoBase.ObterResposta(ws);
               if (string.IsNullOrWhiteSpace(resposta))
                throw new InvalidOperationException("Não foi possível obter resposta a chamada do serviço");
            return RetornoProcessamento(resposta, d1, _contingencia);
        }

        /// <summary>
        ///     Obter Dados
        /// </summary>
        /// <returns></returns>
        private enviNFe ObterDados()
        {
            if (!string.IsNullOrWhiteSpace(_xmlNfe))
            {
                var d0 = Utils.ConverterXMLParaClasse<NFe>(_xmlNfe);
                return new enviNFe(_versao.ObterVersaoServico(), _idlote, _emisorEmissorServicoConfig.IndicadorSincronizacao,
                        new List<NFe> {d0});
            }

            if (_nFes.Count == 0) throw new InvalidOperationException("Informe ao menos uma Nfe");
            var pedEnvio = new enviNFe(_versao.ObterVersaoServico(), _idlote, _emisorEmissorServicoConfig.IndicadorSincronizacao,
                    _nFes.ToList());
            return pedEnvio;
        }


        /// <summary>
        ///     Processa retorno
        /// </summary>
        /// <param name="xmlRecebido"></param>
        /// <param name="enviNFe"></param>
        /// <param name="contingencia">True, enviado em contingência</param>
        /// <returns></returns>
        private RetAutorz RetornoProcessamento(string xmlRecebido, enviNFe enviNFe, bool contingencia)
        {
            var node = Utils.ObterNodeDeStringXml("retEnviNFe", xmlRecebido);
            var retorno1 = Utils.ConverterXMLParaClasse<retEnviNFe>(node);
            _processadas++;
            if (retorno1.protNFe == null) _rejeitadas++;
            if(retorno1.protNFe!=null)
            if (StatusSefaz.ListarCodigo.All(n => retorno1.protNFe.infProt.All(m=>m.cStat!=n.Key))) _rejeitadas++;
           
            var xmlEnviado = Utils.ObterStringXML(enviNFe.NFe);
            var retorno2 = new RetAutorz(retorno1, xmlRecebido, _processadas, _rejeitadas, xmlEnviado, contingencia);
            SalvarArquivoLoteRecebidos(retorno2);
              
            return retorno2;
        }


        /// <summary>
        ///     Gerar string QRcode
        /// </summary>
        /// <param name="entity"></param>
        private void GerarUrlQrCode(NFe entity)
        {
            //QRCode somente para modelo de documento NFCe
            if (entity.infNFe.ide.mod != ModeloDocumento.NfCe) return;
            entity.infNFeSupl = new infNFeSupl();
            var urlQrCodeConsulta = ObterUrlQrCodeConsulta();
            var urlQrCodeChave = ObterUrlQrCodeChave();
            entity.infNFeSupl.urlChave = urlQrCodeConsulta;
            entity.infNFeSupl.qrCode = QrCodeNfCe.ObterUrlQrCode2(entity, _emisorEmissorServicoConfig.Token.CscID,
                    _emisorEmissorServicoConfig.Token.CscToken, urlQrCodeChave);
        }

        /// <summary>
        ///     Gerar Id
        /// </summary>
        /// ObterChave
        /// <param name="entity"></param>
        private void GerarChave(NFe entity)
        {
            var tamanhocNf = 8;
            //Define cNF
            entity.infNFe.ide.cNF = Convert.ToInt32(entity.infNFe.ide.cNF).ToString().PadLeft(tamanhocNf, '0');
            var modeloDocumentoFiscal = entity.infNFe.ide.mod;
            var tipoEmissao = (int) entity.infNFe.ide.tpEmis;
            var codigoNumerico = int.Parse(entity.infNFe.ide.cNF);
            var estado = entity.infNFe.ide.cUF;
            var dataEHoraEmissao = entity.infNFe.ide.dhEmi;
            var cnpj = entity.infNFe.emit.CNPJ;
            var numeroDocumento = entity.infNFe.ide.nNF;
            var serie = entity.infNFe.ide.serie;
            var dadosChave = Utils.ObterChave(estado, dataEHoraEmissao.LocalDateTime, cnpj, modeloDocumentoFiscal, serie, numeroDocumento,
                    tipoEmissao, codigoNumerico);
            entity.infNFe.Id = "NFe" + dadosChave.Chave;
            entity.infNFe.ide.cDV = Convert.ToInt32(dadosChave.DigitoVerificador);
        }

        /// <summary>
        ///     Assinar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private void Assinar(NFe entity)
        {
            try
            {
                var assinatura = AssinaturaDigital.AssinarNFe(entity, entity.infNFe.Id, _certificadoDigital);
                entity.Signature = assinatura;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex, "Erro ao assinar arquivo Xml");
                throw new FalhaAssinaturaException("Erro ao assinar arquivo Xml", ex);
            }
        }


        /// <summary>
        ///     Validar schema
        /// </summary>
        /// <param name="entity"></param>
        private void ValidarSchema(NFe entity)
        {
            var caminhoSchema = _emisorEmissorServicoConfig.DiretorioSchemaXsd;
            if (!Directory.Exists(caminhoSchema))
                throw new Exception("Diretório de Schemas não encontrado: \n" + caminhoSchema);
            // Define o tipo de validação
            var cfg = new XmlReaderSettings {ValidationType = ValidationType.Schema};
            //Listar arquivos XSD e inclui-las na validação
            var list = ObterListaNomeSchemas().ToList();
            list.ForEach(n => { cfg.Schemas.Add(null, Path.Combine(caminhoSchema, n)); });
            cfg.ValidationEventHandler += ValidationEventHandler;
            var xml = Utils.ObterStringXML(entity);
            var reader = XmlReader.Create(new StringReader(xml), cfg);
            var document = new XmlDocument();
            document.Load(reader);

            //Valida xml
            document.Validate(ValidationEventHandler);
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs ex)
        {
            var msg = $"Erro ao validar xml contra Schema Xsd.\n{ex.Message}";
            Utils.TraceException(ex.Exception, msg);
            throw new FalhaValidacaoSchemaException(msg);
        }

        /// <summary>
        ///     Obter endereço QrCode de consulta
        ///     <para>Obrigatório para NFCe</para>
        /// </summary>
        /// <returns></returns>
        private string ObterUrlQrCodeConsulta()
        {
            var url = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                    ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Homologacao.QrcodeConsulta
                    : _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Producao.QrcodeConsulta;
            return url;
        }

        /// <summary>
        ///     Obter endereço QrCode para compor a chave
        ///     <para>Obrigatório para NFCe</para>
        /// </summary>
        /// <returns></returns>
        private string ObterUrlQrCodeChave()
        {
            var url = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                    ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Homologacao.QrcodeChave
                    : _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Producao.QrcodeChave;
            return url;
        }

        /// <summary>
        ///     Obter mensagem Soap em formato Xml
        ///     <para>Corpo da mensagem compativel com a especificação SOAP e requisitos Sefaz</para>
        /// </summary>
        /// <param name="urlWsdl">Endereço WSDL do serviço</param>
        /// <param name="entity"></param>
        /// <example></example>
        /// <returns></returns>
        protected virtual string ObterCorpoMensagemSoap(string urlWsdl, enviNFe entity)
        {
            var xmlCorpo = Utils.ObterStringXML(entity);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
            stringBuilder.Append(
                    "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            stringBuilder.Append("<soap:Body>");
            if (_compactarMensagem)
            {
                //Compacta arquivo para uma bas64
                var xmlCompactado = Convert.ToBase64String(Utils.Zip(xmlCorpo));
                stringBuilder.Append("<nfeDadosMsgZip xmlns=\"" + urlWsdl + "\">" + xmlCompactado + "</nfeDadosMsgZip>");
            }
            else
            {
                stringBuilder.Append("<nfeDadosMsg xmlns=\"" + urlWsdl + "\">" + xmlCorpo + "</nfeDadosMsg>");
            }

            stringBuilder.Append("</soap:Body>");
            stringBuilder.Append("</soap:Envelope>");
            var msg = stringBuilder.ToString();
            return msg;
        }

        /// <summary>
        ///     Salvar arquivo Xml enviado
        /// </summary>
        private void SalvarArquivoLoteEnviado(string resposta)
        {
            if (!_emisorEmissorServicoConfig.SalvarArquivoRetorno) return;
            //SalvarArquivo 
            if (string.IsNullOrWhiteSpace(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml))
                throw new InvalidOperationException("Informe um diretório válido.");
            var nomeArq = $"{_idlote}-env-lot.xml";
            var caminho = Path.Combine(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml, "Autorizacoes", "Enviados");
            Utils.EscreverArquivo(caminho, nomeArq, resposta);
        }

        /// <summary>
        ///     Salvar arquivo Xml recebidos
        /// </summary>
        private void SalvarArquivoLoteRecebidos(RetAutorz retornoNfeAutorizacao)
        {
            if (!_emisorEmissorServicoConfig.SalvarArquivoRetorno) return;
            //SalvarArquivo 
            if (string.IsNullOrWhiteSpace(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml))
                throw new InvalidOperationException("Informe um diretório válido.");
            var nomeArq = $"{_idlote}-rec.xml";
            var caminho = Path.Combine(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml, "Autorizacoes", "Recebidos");
            Utils.EscreverArquivo(caminho, nomeArq, retornoNfeAutorizacao.XmlRecebido);
        }

        /// <summary>
        ///     Lista de schemas relativos ao serviço
        /// </summary>
        /// <returns></returns>
        private ICollection<string> ObterListaNomeSchemas()
        {
            var list = new List<string>();
            var arqs = _emisorEmissorServicoConfig.ConfigServ.Schemas.Autoriza.ToList();
            arqs.ForEach(n => { list.Add(n); });
            return arqs;
        }

        /// <summary>
        ///     Obter endereço WSDL do serviço
        /// </summary>
        /// <returns></returns>
        private string ObterWsdlServico()
        {
            return _emisorEmissorServicoConfig.ConfigServ.UrlsWsdl.Autoriza;
        }

        #region Implementacoes

        public IRetAutorz Executar()
        {
            if (_servicoBase == null)
                throw new ArgumentNullException(nameof(_servicoBase));
            if ((_nFes == null) & string.IsNullOrWhiteSpace(_xmlNfe))
                throw new InvalidOperationException("Uma string XmlNfe ou uma lista NFes é requerida para processar.");
            if (_emisorEmissorServicoConfig == null)
                throw new InvalidOperationException("Uma instância de configuração do emissor é requerido");

            //Danfe = "";
            var d1 = ObterDados();
            if (d1 == null) throw new InvalidOperationException(nameof(d1));
            //Obtem a url do serviço,com base no modelo e ambiente do documento
            _urlServico = ObterUrlServico(d1.NFe[0]); //Obtem o 1º item da coleção
            _urlWsdlServico = ObterWsdlServico();

            //Gerar chave
            d1.NFe.ForEach(GerarChave);
            //Assinar
            d1.NFe.ForEach(Assinar);
            //Gerar QRCode
            d1.NFe.ForEach(GerarUrlQrCode);
            //Validar
            d1.NFe.ForEach(ValidarSchema);
            //Enviar mensagem
            return ProcessarEnvioMensagem(d1); 
        }

        
        #endregion
    }
}