// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:11/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.IO;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Enderecador;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Emitente;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Entidades;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar
{
    /// <summary>
    ///     Configurar Emissor
    /// </summary>
    public sealed class EmissorServicoConfig
    {
        

        #region Construtor

        public EmissorServicoConfig(VersaoServico versaoServico, Estado estado, TipoAmbiente ambiente,
                IndicadorSincronizacao indicadorSincronizacao = IndicadorSincronizacao.Sincrono, int timeOut = 60000)
        {
            VersaoServico = versaoServico;
            IndicadorSincronizacao = indicadorSincronizacao;
            Estado = estado;
            Ambiente = ambiente;
            TimeOut = timeOut;
            ValidaConfiguracaoBasica();
            CarregarConfigServ();
        }

        #endregion

        /// <summary>
        ///     Configurar dados de Endereços Web Services
        /// </summary>
        /// <param name="configServ"></param>
        public void ConfiguraServicos(ConfigServ configServ)
        {
            ConfigServ = configServ;
        }

        /// <summary>
        ///     Carregar dados de configuração de endereços web
        /// </summary>
        private void CarregarConfigServ()
        {
            var nomeArq = "ConfigWeb.json";
            try
            {
                var localArq = $@"{Environment.CurrentDirectory}";
                var arq = Utils.LerArquivo(localArq, nomeArq);
                var arqConfig = (ConfigServ) Utils.JsonDeserialize<ConfigServ>(arq);
                ConfigServ = arqConfig;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new InvalidOperationException($"Não foi possível encontrar ou processar o arquivo {nomeArq}");
            }
        }


        /// <summary>
        ///     Configuração dos Schemas XSD
        /// </summary>
        /// <param name="validar">Determina se está habilitado validar os Schemas XSD</param>
        /// <param name="diretorio">Diretório no qual se localizam os arquivos XSD</param>
        public void ConfiguraSchemaXSD(bool validar, string diretorio)
        {
            if (!Directory.Exists(diretorio))
                throw new FalhaValidacaoException("O diretório não existe ou é inválido");
            ValidarSchema = validar;
            DiretorioSchemaXsd = diretorio;
        }

        /// <summary>
        ///     Configuração dos arquivos de Retorno
        /// </summary>
        /// <param name="salvar">Determina se está habilitado salvar os arquivos</param>
        /// <param name="diretorio">Diretório dos arquivos a serem salvos</param>
        public void ConfiguraArquivoRetorno(bool salvar, string diretorio)
        {
            if (!Directory.Exists(diretorio))
                throw new FalhaValidacaoException("O diretório não existe ou é inválido");
            SalvarArquivoRetorno = salvar;
            DiretorioArquivoRetornoXml = diretorio;
        }

        private void ValidaEmitente()
        {
            if (Emitente == null)
                throw new FalhaValidacaoException("Emitente não informado");
            if (string.IsNullOrEmpty(Emitente.xNome))
                throw new FalhaValidacaoException("A razão social (xNome) do emitente são obrigatórios");
            if (!string.IsNullOrEmpty(Emitente.IE))
            {
                string ie = Emitente.IE;
                if (ie.Contains(".") || ie.Contains("/") || ie.Contains(@"\") || ie.Contains("-") || ie.Contains(",") || ie.Contains(" "))
                    throw new FalhaValidacaoException("A IE do emitente contém caracteres inválidos");
            }

            if (!string.IsNullOrEmpty(Emitente.IEST))
            {
                string ieSt = Emitente.IEST;
                if (ieSt.Contains(".") || ieSt.Contains("/") || ieSt.Contains(@"\") || ieSt.Contains("-") || ieSt.Contains(",") ||
                    ieSt.Contains(" "))
                    throw new FalhaValidacaoException("A IE ST do emitente contém caracteres inválidos");
            }

            if (!string.IsNullOrEmpty(Emitente.IM))
                if (string.IsNullOrEmpty(Emitente.CNAE))
                    throw new FalhaValidacaoException(
                            "O CNAE do emitente não foi informado. Ele é obrigatório sempre que for informado a inscrição municipal (IM)");
            if (Emitente.enderEmit.cMun == 0)
                throw new FalhaValidacaoException("O Código do Município (cMun) do emitente não foi informado ou é inválido");
            if (string.IsNullOrEmpty(Emitente.enderEmit.xMun))
                throw new FalhaValidacaoException("O nome do município do emitente não foi informado");
            if (string.IsNullOrEmpty(Emitente.enderEmit.UF))
                throw new FalhaValidacaoException("A UF do emitente não foi informada");
            if (string.IsNullOrEmpty(Emitente.enderEmit.CEP))
                throw new FalhaValidacaoException("O CEP do emitente não foi informada");
        }

        private void ValidaConfiguracaoBasica()
        {
            if (ValidarSchema)
                if (!Directory.Exists(DiretorioSchemaXsd))
                    throw new FalhaValidacaoException("O diretório dos arquivos de Schemas XSD é inválido");
            if (SalvarArquivoRetorno)
                if (!Directory.Exists(DiretorioArquivoRetornoXml))
                    throw new FalhaValidacaoException("O diretório dos arquivos de retorno é inválido");
        }

        #region Configuração do Certificado Digital

        public CertificadoConfig Certificado { get; private set; }

        /// <summary>
        ///     Configuração do certificado A1 em forma de arquivo físico
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo .pfx do certificado</param>
        /// <param name="signatureMethodSignedXML">Algoritmo de Assinatura</param>
        /// <param name="digestMethodReference">URI para DigestMethod na Classe Reference para auxiliar para a assinatura</param>
        public void ConfiguraCertificadoA1Arquivo(string caminhoArquivo,
                string signatureMethodSignedXML = "http://www.w3.org/2000/09/xmldsig#rsa-sha1",
                string digestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1")
        {
            if (Certificado != null)
                throw new FalhaValidacaoException("O certificado já foi configurado previamente");
            if (!File.Exists(caminhoArquivo))
                throw new FalhaCertificadoDigitalException("O arquivo não foi encontrado no caminho informado");
            Certificado = new CertificadoConfig
            {
                    TipoCertificado = TipoCertificado.A1Arquivo,
                    Arquivo = caminhoArquivo,
                    SignatureMethodSignedXml = signatureMethodSignedXML,
                    DigestMethodReference = digestMethodReference
            };
        }

        /// <summary>
        ///     Configuração do certificado A1 em forma de byte array
        /// </summary>
        /// <param name="byteArrayCertificado"></param>
        /// <param name="signatureMethodSignedXML">Algoritmo de Assinatura</param>
        /// <param name="digestMethodReference">URI para DigestMethod na Classe Reference para auxiliar para a assinatura</param>
        public void ConfiguraCertificadoA1ByteArray(byte[] byteArrayCertificado,
                string signatureMethodSignedXML = "http://www.w3.org/2000/09/xmldsig#rsa-sha1",
                string digestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1")
        {
            if (Certificado != null)
                throw new FalhaValidacaoException("O certificado já foi configurado previamente");
            if (byteArrayCertificado == null)
                throw new FalhaCertificadoDigitalException("Byte array inválido");
            if (byteArrayCertificado.Length <= 0)
                throw new FalhaCertificadoDigitalException("Byte array inválido");
            Certificado = new CertificadoConfig
            {
                    TipoCertificado = TipoCertificado.A1ByteArray,
                    ArrayBytesArquivo = byteArrayCertificado,
                    SignatureMethodSignedXml = signatureMethodSignedXML,
                    DigestMethodReference = digestMethodReference
            };
        }

        /// <summary>
        ///     Configuração do certificado A1 buscando pelo repositório do Windows
        /// </summary>
        /// <param name="serialRepositorio">Serial identificador do certificado no repositório do Windows</param>
        /// <param name="signatureMethodSignedXML">Algoritmo de Assinatura</param>
        /// <param name="digestMethodReference">URI para DigestMethod na Classe Reference para auxiliar para a assinatura</param>
        public void ConfiguraCertificadoA1Repositorio(string serialRepositorio,
                string signatureMethodSignedXML = "http://www.w3.org/2000/09/xmldsig#rsa-sha1",
                string digestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1")
        {
            if (Certificado != null)
                throw new FalhaValidacaoException("O certificado já foi configurado previamente");
            if (string.IsNullOrEmpty(serialRepositorio))
                throw new FalhaCertificadoDigitalException("Serial do repositório é inválido");
            Certificado = new CertificadoConfig
            {
                    TipoCertificado = TipoCertificado.A1Repositorio,
                    Serial = serialRepositorio,
                    SignatureMethodSignedXml = signatureMethodSignedXML,
                    DigestMethodReference = digestMethodReference
            };
        }

        /// <summary>
        ///     Configuração do certificado A3 (cartão)
        /// </summary>
        /// <param name="serial">Serial do certificado</param>
        /// <param name="signatureMethodSignedXML">Algoritmo de Assinatura</param>
        /// <param name="digestMethodReference">URI para DigestMethod na Classe Reference para auxiliar para a assinatura</param>
        public void ConfiguraCertificadoA3(string serial, string signatureMethodSignedXML = "http://www.w3.org/2000/09/xmldsig#rsa-sha1",
                string digestMethodReference = "http://www.w3.org/2000/09/xmldsig#sha1")
        {
            if (Certificado != null)
                throw new FalhaValidacaoException("O certificado já foi configurado previamente");
            if (string.IsNullOrEmpty(serial))
                throw new FalhaCertificadoDigitalException("Serial não informado");
            Certificado = new CertificadoConfig
            {
                TipoCertificado = TipoCertificado.A3,
                Serial = serial,
                DigestMethodReference = digestMethodReference,
                SignatureMethodSignedXml = signatureMethodSignedXML
            };
        }

        #endregion



        /// <summary>
        ///     Versao do serviço
        /// </summary>
        public VersaoServico VersaoServico { get; set; }

        /// <summary>
        ///     Tempo de espera pelo serviço
        /// </summary>
        public int TimeOut { get; set; } = 60000;

        /// <summary>
        ///     True, Salvar arquivo de retorno do serviço
        /// </summary>
        public bool SalvarArquivoRetorno { get; private set; }

        /// <summary>
        ///     Diretório para onde deverão ser salvos os arquivos Xml de retorno
        /// </summary>
        public string DiretorioArquivoRetornoXml { get; private set; }

        /// <summary>
        ///     True, valida schema contra o XSD
        /// </summary>
        public bool ValidarSchema { get; private set; }

        /// <summary>
        ///     Diretório para onde deverão ser obtidos os schemas XSD para validação de Xml
        /// </summary>
        public string DiretorioSchemaXsd { get; private set; }

        /// <summary>
        ///     Indicador de sincronização de serviço
        ///     <para>Indica o tipo de serviço utilizado para o envio de NFe</para>
        /// </summary>
        public IndicadorSincronizacao IndicadorSincronizacao { get; set; }

        public Estado Estado { get; set; }

        public TipoAmbiente Ambiente { get; set; }

        /// <summary>
        ///     Versão do Serviço
        /// </summary>
        public string Versao { get; set; }
 
        /// <summary>
        ///     Configurações de Endereços Web Services
        /// </summary>
        public ConfigServ ConfigServ { get; private set; }
 

        #region Dados do Emitente

        public emit Emitente { get; private set; }

        public TokenNFe Token { get; private set; }

        /// <summary>
        ///     Configura o Token para emissão de NFe e NFCe
        /// </summary>
        /// <param name="cscID">Código de Segurança do Contribuinte(antigo Token)</param>
        /// <param name="cscToken">Identificador do CSC – Código de Segurança do Contribuinte no Banco de Dados da SEFAZ</param>
        public void ConfiguraCSC(string cscID, string cscToken)
        {
            //AssertionConcern.AssertArgumentNotNullOrEmpty(cscID, "cscId - O ID do CSC é obrigatório");
            //AssertionConcern.AssertArgumentNotNullOrEmpty(cscToken, "cscToken - O Token do CSC é obrigatório");
            Token = new TokenNFe(cscID, cscToken);
        }

        /// <summary>
        ///     Configura dados do emitente para emissão dos documentos fiscais
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="cpf"></param>
        /// <param name="xNome"></param>
        /// <param name="xFant"></param>
        /// <param name="ie">
        ///     Inscrição Estadual
        ///     <para>Campo de informação obrigatória nos casos de emissão própria (procEmi = 0, 2 ou 3).</para>
        ///     <para>
        ///         A IE deve ser informada apenas com algarismos para destinatários contribuintes do ICMS, sem caracteres de
        ///         formatação (ponto, barra, hífen, etc.);
        ///     </para>
        ///     <para>
        ///         O literal “ISENTO” deve ser informado apenas para contribuintes do ICMS que são isentos de inscrição no
        ///         cadastro de contribuintes do ICMS e estejam emitindo NF-e avulsa;
        ///     </para>
        /// </param>
        /// <param name="ieSt">
        ///     Informar a IE do ST da UF de destino da mercadoria, quando houver a retenção do ICMS ST para a UF de
        ///     destino.
        /// </param>
        /// <param name="im">
        ///     Inscrição Municipal
        ///     <para>
        ///         Este campo deve ser informado, quando ocorrer a emissão de NF-e conjugada, com prestação de serviços sujeitos
        ///         ao ISSQN e fornecimento de peças sujeitos ao ICMS.
        ///     </para>
        /// </param>
        /// <param name="cnae">
        ///     CNAE fiscal
        ///     <para>Este campo deve ser informado quando o campo IM (C19) for informado.</para>
        /// </param>
        /// <param name="crt"></param>
        /// <param name="xLgr"></param>
        /// <param name="nro"></param>
        /// <param name="xCpl"></param>
        /// <param name="xBairro"></param>
        /// <param name="cMun">
        ///     Código do município
        ///     <para>Código do município (utilizar a tabela do IBGE), informar 9999999 para operações com o exterior.</para>
        /// </param>
        /// <param name="xMun">Nome do município, informar EXTERIOR para operações com o exterior.</param>
        /// <param name="uf"> Sigla da UF, informar EX para operações com o exterior.</param>
        /// <param name="cep">
        ///     Código do CEP
        ///     <para>Informar os zeros não significativos. (NT 2011/004)</para>
        /// </param>
        /// <param name="fone">
        ///     Telefone
        ///     <para>
        ///         Preencher com o Código DDD + número do telefone. Nas operações com exterior é permitido informar o código do
        ///         país + código da localidade + número do telefone (v.2.0)
        ///     </para>
        /// </param>
        public void ConfiguraEmitente(string cnpj, string cpf, string xNome, string xFant, string ie, string ieSt, string im, string cnae,
                CRT crt, string xLgr, string nro, string xCpl, string xBairro, long cMun, string xMun, string uf, string cep, long? fone)
        {
            Emitente = new emit
            {
                    CNPJ = cnpj,
                    CPF = cpf,
                    xNome = xNome,
                    xFant = xFant,
                    IE = ie,
                    IEST = ieSt,
                    IM = im,
                    CNAE = cnae,
                    CRT = crt,
                    enderEmit = new enderEmit
                    {
                            xLgr = xLgr,
                            nro = nro,
                            xCpl = xCpl,
                            xBairro = xBairro,
                            cMun = cMun,
                            xMun = xMun,
                            UF = uf,
                            CEP = cep,
                            fone = fone,
                            cPais = 1058,
                            xPais = "BRASIL"
                    }
            };
            ValidaEmitente();
        }

        #endregion
    }

    public sealed class TokenNFe
    {
        #region Propriedades

        public string CscID { get; }

        public string CscToken { get; }

        #endregion

        #region Construtor

        internal TokenNFe(string cscId, string cscToken)
        {
            CscID = cscId;
            CscToken = cscToken;
        }

        #endregion
    }
}