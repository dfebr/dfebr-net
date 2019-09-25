// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:02/05/2019
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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Inutilizacao;
using DFeBR.EmissorNFe.Servicos.Interfaces;
using DFeBR.EmissorNFe.Servicos.Retornos;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Entidades;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Templates
{
    public abstract class ServInutTemplate : IServInutTemplate
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
        public string NomeServico => "Inutilização de Númeração Fiscal";

        #endregion

        #region Construtor

        protected ServInutTemplate(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, string cnpj, int ano,
                ModeloDocumento modelo, VersaoServico versao, int serie, int numeroInicial, int numeroFinal, string justificativa)
        {
            _emisorEmissorServicoConfig = emissorServicoConfig;
            _certificadoDigital = certificado;
            _cnpj = cnpj;
            _ano = ano;
            _modelo = modelo;
            _serie = serie;
            _numeroInicial = numeroInicial;
            _numeroFinal = numeroFinal;
            _justificativa = justificativa;
            _versao = versao;
        }

        #endregion

        /// <summary>
        ///     Certificado Digital
        /// </summary>
        private readonly X509Certificate2 _certificadoDigital;

        /// <summary>
        ///     Dados de configuração do emissor
        /// </summary>
        private readonly EmissorServicoConfig _emisorEmissorServicoConfig;

        /// <summary>
        ///     Serviço Base
        /// </summary>
        private IServHttpSoapBase _servicoBase;

        /// <summary>
        ///     Versão do serviço
        /// </summary>
        private VersaoServico _versao;

        /// <summary>
        ///     Url do serviço
        /// </summary>
        private string _urlServico;

        /// <summary>
        ///     Url WSDL do serviço
        /// </summary>
        private string _urlWsdlServico;

        /// <summary>
        ///     CNPJ do emitente
        /// </summary>
        private readonly string _cnpj;

        /// <summary>
        ///     Ano da nota fiscal
        ///     <para>Deve ter apenas 2 digitos, ex: 2019, 19</para>
        /// </summary>
        private readonly int _ano;

        /// <summary>
        ///     Modelo
        /// </summary>
        private readonly ModeloDocumento _modelo;

        /// <summary>
        ///     Numero de série
        /// </summary>
        private readonly int _serie;

        /// <summary>
        ///     Numero Inicial
        /// </summary>
        private readonly int _numeroInicial;

        /// <summary>
        ///     Numero Final
        /// </summary>
        private readonly int _numeroFinal;

        /// <summary>
        ///     Justificativa
        /// </summary>
        private readonly string _justificativa;

        private string ObterWsdlServico()
        {
            return _emisorEmissorServicoConfig.ConfigServ.UrlsWsdl.Inutiliza;
        }

        /// <summary>
        ///     Gerar Id
        /// </summary>
        /// <param name="entity"></param>
        private void GerarId(inutNFe entity)
        {
            var numId = string.Concat((int) entity.infInut.cUF, entity.infInut.ano, entity.infInut.CNPJ, (int) entity.infInut.mod,
                    entity.infInut.serie.ToString().PadLeft(3, '0'), entity.infInut.nNFIni.ToString().PadLeft(9, '0'),
                    entity.infInut.nNFFin.ToString().PadLeft(9, '0'));
            entity.infInut.Id = "ID" + numId;
        }

        /// <summary>
        ///     Obter endereço serviço
        /// </summary>
        /// <returns></returns>
        private string ObterUrlServico(infInutEnv entity)
        {
            switch (entity.mod)
            {
                case ModeloDocumento.NFe:
                    var url = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                            ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Homologacao.Inutiliza
                            : _emisorEmissorServicoConfig.ConfigServ.UrlsNFe.Producao.Inutiliza;
                    return url;
                case ModeloDocumento.NfCe:
                    var url1 = _emisorEmissorServicoConfig.Ambiente == TipoAmbiente.Homologacao
                            ? _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Homologacao.Inutiliza
                            : _emisorEmissorServicoConfig.ConfigServ.UrlsNFce.Producao.Inutiliza;
                    return url1;
                default:
                    throw new ArgumentOutOfRangeException("Modelo de documento não suportado para o serviço");
            }
        }

        /// <summary>
        ///     Obter mensagem Soap em formato Xml
        ///     <para>Corpo da mensagem compativel com a especificação SOAP e requisitos Sefaz</para>
        /// </summary>
        /// <param name="urlWsdl">Endereço WSDL do serviço</param>
        /// <param name="entity"></param>
        /// <example></example>
        /// <returns></returns>
        protected virtual string ObterCorpoMensagemSoap(string urlWsdl, inutNFe entity)
        {
            var xmlCorpo = Utils.ClasseParaXmlString(entity);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
            stringBuilder.Append(
                    "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            stringBuilder.Append("<soap:Body>");
            stringBuilder.Append("<nfeDadosMsg xmlns=\"" + urlWsdl + "\">" + xmlCorpo + "</nfeDadosMsg>");
            stringBuilder.Append("</soap:Body>");
            stringBuilder.Append("</soap:Envelope>");
            var msg = stringBuilder.ToString();
            return msg;
        }

        /// <summary>
        ///     Validar regra
        /// </summary>
        /// <param name="entity"></param>
        private void ValidarRegra(inutNFe entity)
        {
            if (entity.infInut.ano > 99) throw new FalhaValidacaoException("O ano deve possuir apenas 2 digitos");
        }

        /// <summary>
        ///     Validar schema
        /// </summary>
        /// <param name="entity"></param>
        private void ValidarSchema(inutNFe entity)
        {
            if (_emisorEmissorServicoConfig.ValidarSchema) return;
            var caminhoSchema = _emisorEmissorServicoConfig.DiretorioSchemaXsd;
            if (!Directory.Exists(caminhoSchema))
                throw new Exception("Diretório de Schemas não encontrado: \n" + caminhoSchema);
            // Define o tipo de validação
            var cfg = new XmlReaderSettings {ValidationType = ValidationType.Schema};
            //Listar arquivos XSD e inclui-las na validação
            var list = ObterListaNomeSchemas().ToList();
            list.ForEach(n => { cfg.Schemas.Add(null, Path.Combine(caminhoSchema, n)); });
            cfg.ValidationEventHandler += ValidationEventHandler;
            var xml = Utils.ClasseParaXmlString(entity);
            var reader = XmlReader.Create(new StringReader(xml), cfg);
            var document = new XmlDocument();
            document.Load(reader);

            //Valida xml
            document.Validate(ValidationEventHandler);
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            var msg = $"Erro ao validar xml contra Schema Xsd.\n{args.Message}";
            throw new FalhaValidacaoSchemaException(msg);
        }

        /// <summary>
        ///     Assinar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private void Assinar(inutNFe entity)
        {
            try
            {
                var assinatura = AssinaturaDigital.AssinarNFe(entity, entity.infInut.Id, _certificadoDigital);
                entity.Signature = assinatura;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaAssinaturaException("Erro ao assinar arquivo Xml", ex);
            }
        }

        /// <summary>
        ///     Salvar arquivo Xml
        /// </summary>
        private void SalvarArquivo(RetInut entity)
        {
            if (!_emisorEmissorServicoConfig.SalvarArquivoRetorno) return;
            //SalvarArquivo 
            if (string.IsNullOrWhiteSpace(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml))
                throw new InvalidOperationException("Informe um diretório válido.");
            var nomeArq = $"{entity.Retorno.infInut.Id}-ped-inu.xml";
            var caminho = Path.Combine(_emisorEmissorServicoConfig.DiretorioArquivoRetornoXml, "Inutilizacao","Recebidos");
            Utils.EscreverArquivo(caminho, nomeArq, entity.XmlRecebido);
        }

        /// <summary>
        ///     Lista de schemas relativos ao serviço
        /// </summary>
        /// <returns></returns>
        private ICollection<string> ObterListaNomeSchemas()
        {
            var list = new List<string>();
            var arqs = _emisorEmissorServicoConfig.ConfigServ.Schemas.Inutiliza.ToList();
            arqs.ForEach(n => { list.Add(n); });
            return arqs;
        }

        /// <summary>
        ///     Obter Dados
        /// </summary>
        /// <returns></returns>
        private inutNFe ObterDados()
        {
            var entity = new inutNFe
            {
                    versao = VersaoServico.Ve400.ObterVersaoServico(),
                    infInut = new infInutEnv
                    {
                            tpAmb = _emisorEmissorServicoConfig.Ambiente,
                            cUF = _emisorEmissorServicoConfig.Estado,
                            ano = _ano,
                            CNPJ = _cnpj?.RetirarCaracteresEspeciais(),
                            mod = _modelo,
                            serie = _serie,
                            nNFIni = _numeroInicial,
                            nNFFin = _numeroFinal,
                            xJust = _justificativa
                    }
            };
            ValidarRegra(entity);
            return entity;
        }

        #region Implementacoes

        public IRetInut Executar()
        {
            if (_servicoBase == null) throw new InvalidOperationException("Uma instância do serviço base é requerido");
            if (_emisorEmissorServicoConfig == null)
                throw new InvalidOperationException("Uma instância de configuração do emissor é requerido");
            var d1 = ObterDados();
            _urlServico = ObterUrlServico(d1.infInut);
            _urlWsdlServico = ObterWsdlServico();
            //Gerar Id
            GerarId(d1);
            //Validar regras de negocio
            ValidarRegra(d1);
            //Assinar Xml
            Assinar(d1);
            //Validar schemas
            ValidarSchema(d1);
            var soapXml = ObterCorpoMensagemSoap(_urlWsdlServico, d1);
            var ws = _servicoBase.ObterRequisicaoSoap(_urlServico, soapXml);
            var resposta = _servicoBase.ObterResposta(ws);

            //Obter Node
            var node = Utils.ObterNodeDeStringXml("retInutNFe", resposta);
            var retorno1 = Utils.XmlStringParaClasse<retInutNFe>(node);
            retorno1.cStat = retorno1.infInut.cStat;
            retorno1.dhResp = retorno1.infInut.dhRecbto;
            retorno1.tpAmb = retorno1.infInut.tpAmb;
            retorno1.verAplic = retorno1.infInut.verAplic;
            retorno1.xMotivo = retorno1.infInut.xMotivo;
            var xmlEnviado = Utils.ClasseParaXmlString(d1);
            _processadas++;
            if (retorno1.infInut == null) _rejeitadas++;
            if (retorno1.infInut != null)
                if (StatusSefaz.ListarCodigo.All(n => n.Key != retorno1.infInut.cStat)) _rejeitadas++;
            var retorno2 = new RetInut(retorno1, node, _processadas, _rejeitadas, xmlEnviado);
            //Salvar arquivo 
            SalvarArquivo(retorno2);
            return retorno2;
        }

        #endregion
    }
}