// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
    #region Danfe
    public enum TipoPapelNFCe
    {
        Mm80,
        Mm58,
    }

    public enum Status
    {
        Autorizada,
        Cancelada,
        NaoAuotorizada,
        Negada,
        Recusada,
        EsperandoAutorizacao
    }
    public enum TemplateDanfeNFCe
    {
        Header,
        Body,
        Products,
        Total,
        Payments,
        AdditionalInformation, 
        Footer,
        Structure, 
        Recipient, 
        Script,
        Data,
        Taxes 
    }

    public enum TemplateDanfeNFe
    {
        Header,
        Body,
        Products,
        Total,
        Payments,
        AdditionalInformation,
        DeliveryAddress,
        Footer,
        Structure,
        Issuer,
        Recipient,
        Invoice,
        InvoiceItem,
        Transport,
        Trailer,
        TrailerItem,
        ISSQN,
        Volume,
        VolumeList,
        VolumeListItem,
        Script,
        Data,
        Taxes,
        tableFormPayment,
        tableMadeSalesPDV,
        tableCashReinforcement,
        tableCashDrain,
        tableClosedCashier,
    }

    #endregion

    #region Identificacao NFe

    /// <summary>
    ///     Informar "1=Empresa Emitente" para este evento.
    ///     Nota:
    ///     1=Empresa Emitente;
    ///     2=Empresa Destinatária;
    ///     3=Empresa;
    ///     5=Fisco;
    ///     6=RFB;
    ///     9=Outros Órgãos.
    /// </summary>
    public enum TipoAutor
    {
        [XmlEnum("1")] taEmpresaEmitente = 1,

        [XmlEnum("2")] taEmpresaDestinataria = 2,

        [XmlEnum("3")] taEmpresa = 3,

        [XmlEnum("5")] taFisco = 5,

        [XmlEnum("6")] taRFB = 6,

        [XmlEnum("9")] taOutrosOrgaos = 9
    }

    /// <summary>
    ///     Indicador da forma de pagamento
    ///     <para>0 – pagamento à vista;</para>
    ///     <para>1 – pagamento à prazo;</para>
    ///     <para>2 - outros.</para>
    /// </summary>
    public enum IndicadorPagamento
    {
        [XmlEnum("0")] IpVista = 0,
        [XmlEnum("1")] IpPrazo = 1,
        [XmlEnum("2")] IpOutras = 2
    }

    public enum IndicadorPagamentoDetalhePagamento
    {
        [XmlEnum("0")] IpDetPgVista = 0,
        [XmlEnum("1")] IpDetPgPrazo = 1
    }


    /// <summary>
    ///     Finalidade da emissão da NF-e
    ///     <para>1 - NFe normal</para>
    ///     <para>2 - NFe complementar</para>
    ///     <para>3 - NFe de ajuste</para>
    ///     <para>4 - Devolução/Retorno</para>
    /// </summary>
    public enum FinalidadeNFe
    {
        [XmlEnum("1")] FnNormal = 1,
        [XmlEnum("2")] FnComplementar = 2,
        [XmlEnum("3")] FnAjuste = 3,
        [XmlEnum("4")] FnDevolucao = 4
    }


    /// <summary>
    ///     Indicador de presença do comprador no estabelecimento comercial no momento da operação
    ///     <para>0 - Não se aplica</para>
    ///     <para>1 - Operação presencial;</para>
    ///     <para>2 - Operação não presencial, pela Internet;</para>
    ///     <para>3 - Operação não presencial, Teleatendimento;</para>
    ///     <para>4 - NFC-e em operação com entrega a domicílio;</para>
    ///     <para>9 - Operação não presencial, outros.</para>
    /// </summary>
    public enum PresencaComprador
    {
        [XmlEnum("0")] PcNao = 0,
        [XmlEnum("1")] PcPresencial = 1,
        [XmlEnum("2")] PcInternet = 2,
        [XmlEnum("3")] PcTeleatendimento = 3,
        [XmlEnum("4")] PcEntregaDomicilio = 4,
        [XmlEnum("5")] PcPresencialForaEstabelecimento = 5, // versão 4.00
        [XmlEnum("9")] PcOutros = 9
    }

    /// <summary>
    ///     Indicador do tipo de Operação do CSC
    ///     <para>1 - Consulta CSC Ativos;</para>
    ///     <para>2 - Solicita novo CSC;</para>
    ///     <para>3 - Revoga CSC Ativo</para>
    /// </summary>
    public enum IdentificadorOperacaoCsc
    {
        [XmlEnum("1")] IoConsultaCscAtivos = 1,
        [XmlEnum("2")] IoSolicitaNovoCsc = 2,
        [XmlEnum("3")] IoRevogaCscAtivo = 3
    }

    public enum refMod
    {
        [XmlEnum("01")] Modelo = 1,

        [XmlEnum("02")] Modelo2 = 2 // Versão 4.00
    }

    #endregion

    /// <summary>
    ///     Situação do contribuinte: 0 - não habilitado; 1 - habilitado.
    /// </summary>
    public enum SituacaoContribuinte
    {
        [XmlEnum("0")] NaoHabilitado = 0,
        [XmlEnum("1")] Habilitado = 1
    }

    /// <summary>
    ///     Indicador de contribuinte credenciado a emitir NF-e.
    ///     <para>0 - Não credenciado para emissão da NF-e;</para>
    ///     <para>1 - Credenciado;</para>
    ///     <para>2 - Credenciado com obrigatoriedade para todas operações;</para>
    ///     <para>3 - Credenciado com obrigatoriedade parcial;</para>
    ///     <para>
    ///         4 – a SEFAZ não fornece a informação. Este indicador significa apenas que o contribuinte é credenciado para
    ///         emitir NF-e na SEFAZ consultada.
    ///     </para>
    /// </summary>
    public enum IndicadorCredenciamentoNfe
    {
        [XmlEnum("0")] NaoCredenciado = 0,
        [XmlEnum("1")] Credenciado = 1,
        [XmlEnum("2")] CredenciadoTodasOperacoes = 2,
        [XmlEnum("3")] CredenciadoParcial = 3,
        [XmlEnum("4")] SemInformacaoSefaz = 4
    }

    /// <summary>
    ///     Indicador de contribuinte credenciado a emitir CT-e.
    ///     <para>0 - Não credenciado para emissão da CT-e;</para>
    ///     <para>1 - Credenciado;</para>
    ///     <para>2 - Credenciado com obrigatoriedade para todas operações;</para>
    ///     <para>3 - Credenciado com obrigatoriedade parcial;</para>
    ///     <para>
    ///         4 – a SEFAZ não fornece a informação. Este indicador significa apenas que o contribuinte é credenciado para
    ///         emitir CT-e na SEFAZ consultada.
    ///     </para>
    /// </summary>
    public enum IndicadorCredenciamentoCte
    {
        [XmlEnum("0")] NaoCredenciado = 0,
        [XmlEnum("1")] Credenciado = 1,
        [XmlEnum("2")] CredenciadoTodasOperacoes = 2,
        [XmlEnum("3")] CredenciadoParcial = 3,
        [XmlEnum("4")] SemInformacaoSefaz = 4
    }

    /// <summary>
    ///     Tipo de documento a ser utilizado na consulta de cadastro.
    ///     <para>Ie - Inscrição Estadual</para>
    ///     <para>Cnpj - CNPJ</para>
    ///     <para>Cpf - CPF</para>
    /// </summary>
    public enum ConsultaCadastroTipoDocumento
    {
        Ie = 0,
        Cnpj = 1,
        Cpf = 2
    }

    #region Produto

    /// <summary>
    ///     <para>0 – o valor do item (vProd) não compõe o valor total da NF-e (vProd)</para>
    ///     <para>1  – o valor do item (vProd) compõe o valor total da NF-e (vProd)</para>
    /// </summary>
    public enum IndicadorTotal
    {
        [XmlEnum("0")] ValorDoItemNaoCompoeTotalNf = 0,
        [XmlEnum("1")] ValorDoItemCompoeTotalNf = 1
    }

    /// <summary>
    ///     1=Marítima;
    ///     2=Fluvial;
    ///     3=Lacustre;
    ///     4=Aérea;
    ///     5=Postal
    ///     6=Ferroviária;
    ///     7=Rodoviária;
    ///     8=Conduto / Rede Transmissão;
    ///     9=Meios Próprios;
    ///     10=Entrada / Saída ficta; 11=Courier; 12=Handcarry. (NT 2013/005 v 1.10).
    /// </summary>
    public enum TipoTransporteInternacional
    {
        /// <summary>
        ///     1=Marítima
        /// </summary>
        [XmlEnum("1")] Maritima = 1,

        /// <summary>
        ///     2=Fluvial
        /// </summary>
        [XmlEnum("2")] Fluvial = 2,

        /// <summary>
        ///     3=Lacustre
        /// </summary>
        [XmlEnum("3")] Lacustre = 3,

        /// <summary>
        ///     4=Aérea
        /// </summary>
        [XmlEnum("4")] Aerea = 4,

        /// <summary>
        ///     5=Postal
        /// </summary>
        [XmlEnum("5")] Postal = 5,

        /// <summary>
        ///     6=Ferroviária
        /// </summary>
        [XmlEnum("6")] Ferroviaria = 6,

        /// <summary>
        ///     7=Rodoviária
        /// </summary>
        [XmlEnum("7")] Rodoviaria = 7,

        /// <summary>
        ///     8=Conduto / Rede de Transmissão
        /// </summary>
        [XmlEnum("8")] CondutoRedeTransmissão = 8,

        /// <summary>
        ///     9=Meios Próprios
        /// </summary>
        [XmlEnum("9")] MeiosProprios = 9,

        /// <summary>
        ///     10=Entrada / Saída ficta
        /// </summary>
        [XmlEnum("10")] EntradaSaidaficta = 10,

        /// <summary>
        ///     11=Courier
        /// </summary>
        [XmlEnum("11")] Courier = 11,

        /// <summary>
        ///     12=Handcarry (NT 2013/005 v 1.10)
        /// </summary>
        [XmlEnum("12")] Handcarry = 12
    }

    /// <summary>
    ///     1=Importação por conta própria;
    ///     2=Importação por conta e ordem;
    ///     3=Importação por encomenda;
    /// </summary>
    public enum TipoIntermediacao
    {
        /// <summary>
        ///     1=Importação por conta própria
        /// </summary>
        [XmlEnum("1")] ContaPropria = 1,

        /// <summary>
        ///     2=Importação por conta e ordem
        /// </summary>
        [XmlEnum("2")] ContaeOrdem = 2,

        /// <summary>
        ///     3=Importação por encomenda
        /// </summary>
        [XmlEnum("3")] PorEncomenda = 3
    }


    /// <summary>
    ///     0=Uso permitido; 1=Uso restrito;
    /// </summary>
    public enum TipoArma
    {
        [XmlEnum("0")] UsoPermitido = 0,
        [XmlEnum("1")] UsoRestrito = 1
    }

    /// <summary>
    ///     Indicador de Escala Relevante:
    ///     S -  Produzido em Escala Relevante; N – Produzido em Escala NÃO Relevante.
    ///     Versão 4.00
    /// </summary>
    public enum indEscala
    {
        [XmlEnum("S")] S = 'S',
        [XmlEnum("N")] N = 'N'
    }

    #endregion

    /// <summary>
    ///     Indicador de Sincronização:
    ///     <para>0 = Assíncrono. A resposta deve ser obtida consultando o serviço NFeRetAutorizacao, com o nº do recibo</para>
    ///     <para>
    ///         1 = Síncrono. Empresa solicita processamento síncrono do Lote de NF-e (sem a geração de Recibo para consulta
    ///         futura);
    ///     </para>
    /// </summary>
    public enum IndicadorSincronizacao
    {
        [XmlEnum("0")] Assincrono = 0,

        [XmlEnum("1")] Sincrono = 1
    }

    /// <summary>
    ///     Tipo do evento de manifestação do destinatário.
    /// </summary>
    public enum TipoEventoManifestacaoDestinatario
    {
        [Description("Confirmacao da Operacao")]
        TeMdConfirmacaoDaOperacao = 210200,

        [Description("Ciencia da Operacao")] TeMdCienciaDaEmissao = 210210,

        [Description("Desconhecimento da Operacao")]
        TeMdDesconhecimentoDaOperacao = 210220,

        [Description("Operacao nao Realizada")]
        TeMdOperacaoNaoRealizada = 210240
    }

    /// <summary>
    ///     Versao do servico.
    /// </summary>
    public enum VersaoServico
    {
        [XmlEnum("1.00")] Ve100,

        [XmlEnum("2.00")] Ve200,

        [XmlEnum("3.10")] Ve310,

        [XmlEnum("4.00")] Ve400
    }

    public enum TiposServicoNFe
    {
        /// <summary>
        ///     serviço destinado à recepção de mensagem do Evento de Cancelamento da NF-e
        /// </summary>
        RecepcaoEventoCancelmento,

        /// <summary>
        ///     serviço destinado à recepção de mensagem do Evento de Carta de Correção da NF-e
        /// </summary>
        RecepcaoEventoCartaCorrecao,

        /// <summary>
        ///     serviço destinado à recepção de mensagem do Evento EPEC da NF-e
        /// </summary>
        RecepcaoEventoEpec,

        /// <summary>
        ///     serviço destinado à recepção de mensagem do Evento de Manifestação do destinatário da NF-e
        /// </summary>
        RecepcaoEventoManifestacaoDestinatario,

        /// <summary>
        ///     serviço destinado à recepção de mensagens de lote de NF-e versão 2.0
        /// </summary>
        NfeRecepcao,

        /// <summary>
        ///     serviço destinado a retornar o resultado do processamento do lote de NF-e versão 2.0
        /// </summary>
        NfeRetRecepcao,

        /// <summary>
        ///     Serviço para consultar o cadastro de contribuintes do ICMS da unidade federada
        /// </summary>
        NfeConsultaCadastro,

        /// <summary>
        ///     serviço destinado ao atendimento de solicitações de inutilização de numeração
        /// </summary>
        NfeInutilizacao,

        /// <summary>
        ///     serviço destinado ao atendimento de solicitações de consulta da situação atual da NF-e
        ///     na Base de Dados do Portal da Secretaria de Fazenda Estadual
        /// </summary>
        NfeConsultaProtocolo,

        /// <summary>
        ///     serviço destinado à consulta do status do serviço prestado pelo Portal da Secretaria de Fazenda Estadual
        /// </summary>
        NfeStatusServico,

        /// <summary>
        ///     serviço destinado à recepção de mensagens de lote de NF-e versão 3.10
        /// </summary>
        NFeAutorizacao,

        /// <summary>
        ///     serviço destinado a retornar o resultado do processamento do lote de NF-e versão 3.10
        /// </summary>
        NFeRetAutorizacao,

        /// <summary>
        ///     Distribui documentos e informações de interesse do ator da NF-e
        /// </summary>
        NFeDistribuicaoDFe,

        /// <summary>
        ///     “Serviço de Consulta da Relação de Documentos Destinados” para um determinado CNPJ
        ///     de destinatário informado na NF-e.
        /// </summary>
        NfeConsultaDest,

        /// <summary>
        ///     Serviço destinado ao atendimento de solicitações de download de Notas Fiscais Eletrônicas por seus destinatários
        /// </summary>
        NfeDownloadNf,

        /// <summary>
        ///     Serviço destinado a administração do CSC.
        /// </summary>
        NfceAdministracaoCsc
    }

    /// <summary>
    ///     Tipo de certificado
    /// </summary>
    public enum TipoCertificado
    {
        [Description("Certificado A1")] A1Repositorio = 0,

        [Description("Certificado A1 em arquivo")]
        A1Arquivo = 1,

        [Description("Certificado A3")] A3 = 2,

        [Description("Certificado A1 em byte array")]
        A1ByteArray = 3
    }

    public enum TipoImpressao
    {
        [XmlEnum("0")] [Description("0 - Sem geração de DANFE")]
        SemDanfe = 0,

        [XmlEnum("1")] [Description("1 - DANFE normal, Retrato")]
        NormalRetrato = 1,

        [XmlEnum("2")] [Description("2 - DANFE normal, Paisagem")]
        NormalPaisagem = 2,

        [XmlEnum("3")] [Description("3 - DANFE Simplificado")]
        Simplificado = 3,

        [XmlEnum("4")] [Description("4 - DANFE NFC-e")]
        Nfce = 4,

        [XmlEnum("5")] [Description("5 - DANFE NFC-e em mensagem eletrônica")]
        MensagemEletronica = 5
    }

    /// <summary>
    ///     1=Acabado; 2=Inacabado; 3=Semiacabado
    /// </summary>
    public enum CondicaoVeiculo
    {
        [XmlEnum("1")] [Description("1-Acabado")]
        Acabado = 1,

        [XmlEnum("2")] [Description("2-Inacabado")]
        Inacabado = 2,

        [XmlEnum("3")] [Description("3-Semi-acabado")]
        SemiAcabado = 3
    }

    /// <summary>
    ///     Tipo de documento de pesquisa de uma NFe
    /// </summary>
    public enum DocumentoProtocolo
    {
        [XmlEnum("1")] [Description("1-Chave")]
        Chave = 1,

        [XmlEnum("2")] [Description("2-Xml")] Xml = 2
    }

    /// <summary>
    ///     Informa-se o veículo tem VIN (chassi) remarcado. R=Remarcado; N=Normal
    /// </summary>
    public enum CondicaoVin
    {
        [XmlEnum("R")] [Description("R-Remarcado")]
        Ciclomoto = 0,

        [XmlEnum("N")] [Description("N-Normal")]
        Motoneta = 1
    }

    /// <summary>
    ///     Indica operação com Consumidor final
    ///     <para>0 - Normal;</para>
    ///     <para>1 - Consumidor final;</para>
    /// </summary>
    public enum ConsumidorFinal
    {
        [XmlEnum("0")] [Description("0 - Não")]
        Nao = 0,

        [XmlEnum("1")] [Description("1 - Consumidor final")]
        Sim = 1
    }

    public enum Crt
    {
        [XmlEnum("1")] [Description("1 - Simples Nacional")]
        SimplesNacional = 1,

        [XmlEnum("2")] [Description("2 - Simples Nacional Ex. Rec. Bruta")]
        SimplesNacionalExcRecBruta = 2,

        [XmlEnum("3")] [Description("3 - Regime Nomral")]
        RegimeNomral = 3
    }

    public enum DestinoOperacao
    {
        [XmlEnum("1")] [Description("1 - Operação interna")]
        Interna = 1,

        [XmlEnum("2")] [Description("2 - Operação interestadual")]
        Interestadual = 2,

        [XmlEnum("3")] [Description("3 - Operação com exterior")]
        Exterior = 3
    }

    public enum EspecieVeiculo
    {
        [XmlEnum("01")] [Description("1-PASSAGEIRO")]
        Passageiro = 01,

        [XmlEnum("02")] [Description("2-CARGA")]
        Carga = 02,

        [XmlEnum("03")] [Description("3-MISTO")]
        Misto = 03,

        [XmlEnum("04")] [Description("4-CORRIDA")]
        Corrida = 04,

        [XmlEnum("05")] [Description("5-TRAÇÃO")]
        Tracao = 05,

        [XmlEnum("06")] [Description("6-ESPECIAL")]
        Especial = 06
    }

    public enum Estado
    {
        [XmlEnum("12")] Ac = 12,

        [XmlEnum("27")] Al = 27,

        [XmlEnum("16")] Ap = 16,

        [XmlEnum("13")] Am = 13,

        [XmlEnum("29")] Ba = 29,

        [XmlEnum("23")] Ce = 23,

        [XmlEnum("53")] Df = 53,

        [XmlEnum("32")] Es = 32,

        [XmlEnum("52")] Go = 52,

        [XmlEnum("21")] Ma = 21,

        [XmlEnum("51")] Mt = 51,

        [XmlEnum("50")] Ms = 50,

        [XmlEnum("31")] Mg = 31,

        [XmlEnum("15")] Pa = 15,

        [XmlEnum("25")] Pb = 25,

        [XmlEnum("41")] Pr = 41,

        [XmlEnum("26")] Pe = 26,

        [XmlEnum("22")] Pi = 22,

        [XmlEnum("33")] Rj = 33,

        [XmlEnum("24")] Rn = 24,

        [XmlEnum("43")] Rs = 43,

        [XmlEnum("11")] Ro = 11,

        [XmlEnum("14")] Rr = 14,

        [XmlEnum("42")] Sc = 42,

        [XmlEnum("35")] Sp = 35,

        [XmlEnum("28")] Se = 28,

        [XmlEnum("17")] To = 17,

        [XmlEnum("91")] An = 91,

        [XmlEnum("99")] Ex = 99
    }

    public enum Finalidade
    {
        [XmlEnum("1")] [Description("1 - NF-e normal")]
        Normal = 1,

        [XmlEnum("2")] [Description("2 - NF-e complementar")]
        Complementar = 2,

        [XmlEnum("3")] [Description("3 - NF-e de ajuste")]
        Ajuste = 3,

        [XmlEnum("4")] [Description("4 - Devolução")]
        Devolucao = 4
    }

    public enum FormaImportacao
    {
        [XmlEnum("1")] [Description("1 - Importação por conta própria")]
        Propria = 1,

        [XmlEnum("2")] [Description("2 - Importação por conta e ordem")]
        ContaeOrdem = 2,

        [XmlEnum("3")] [Description("3 - Importação por encomenda")]
        Encomenda = 3
    }

    public enum IndicadorDestinatario
    {
        [XmlEnum("1")] [Description("1 - Contribuinte ICMS")]
        Contribuinte = 1,

        [XmlEnum("2")] [Description("2 - Contribuinte isento")]
        Isento = 2,

        [XmlEnum("3")] [Description("9 - Não Contribuinte")]
        NaoContribuinte = 3
    }

    public enum IndicadorEscala
    {
        [XmlEnum("S")] [Description("S - Escala Relevante")]
        Relevante = 1,

        [XmlEnum("N")] [Description("N - Escala não Relevante")]
        NaoRelevante = 2
    }

    public enum IndicadorPresenca
    {
        [XmlEnum("0")] [Description("0 - Não se aplica")]
        NaoSeAplica = 0,

        [XmlEnum("1")] [Description("1 - Operação presencial")]
        OperacaoPresencial = 1,

        [XmlEnum("2")] [Description("2 - Operação não presencial, pela Internet")]
        NaoPresencial = 2,

        [XmlEnum("3")] [Description("3 - Operação não presencial, Teleatendimento")]
        NaoPresencialTeleatendimento = 3,

        [XmlEnum("4")] [Description("4 - NFC-e em operação com entrega a domicílio")]
        NfceEntregaDomicilio = 4,

        [XmlEnum("5")] [Description("5 - Operação presencial fora do estabelecimento")]
        PresencialForaDoEstabelecimento = 5,

        [XmlEnum("9")] [Description("9 - Operação não presencial, outros")]
        NaoPresencialOutros = 9
    }

    public enum IndicadorTotalidade
    {
        [XmlEnum("0")] [Description("0 - Não compõe o valor total da NF-e ")]
        Compoe = 0,

        [XmlEnum("1")] [Description("1 - Compõe o valor total da NF-e ")]
        NaoCompoe = 0
    }

    public enum ModeloDocumento
    {
        [XmlEnum("55")] [Description("55 - NFe")]
        NFe = 55,

        [XmlEnum("58")] [Description("58 - MDFe")]
        MdFe = 58,

        [XmlEnum("65")] [Description("65 - NFCe")]
        NfCe = 65,

        [XmlEnum("57")] [Description("57 - CTe")]
        CTe = 57,

        [XmlEnum("67")] [Description("67 - CTeOS")]
        CteOs = 67
    }

    public enum ModeloEcfReferenciado
    {
        [XmlEnum("2B")] [Description("2B - Cupom Fiscal máquina registradora")]
        CupomRegistradora = 1,

        [XmlEnum("2C")] [Description("2C - Cupom Fiscal PDV")]
        CupomPdv = 1,

        [XmlEnum("2D")] [Description("2D - Cupom Fiscal (emitido por ECF)")]
        CupomEcf = 1
    }

    public enum ModeloNotaReferenciada
    {
        [XmlEnum("1")] [Description("1 - Modelo 01")]
        Modelo01 = 1,

        [XmlEnum("2")] [Description("2 - Modelo 02")]
        Modelo02 = 2
    }

    /// <summary>
    ///     Processo de emissão utilizado com a seguinte codificação:
    ///     <para>0 - emissão de NF-e com aplicativo do contribuinte;</para>
    ///     <para>1 - emissão de NF-e avulsa pelo Fisco;</para>
    ///     <para>2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;</para>
    ///     <para>3- emissão de NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.</para>
    /// </summary>
    public enum ProcessoEmissao
    {
        [XmlEnum("0")] [Description("0 - Aplicativo do contribuinte")]
        AplicativoContribuinte = 0,

        [XmlEnum("1")] [Description("1 - Avulsa pelo Fisco")]
        AvulsaFisco = 1,

        [XmlEnum("2")] [Description("2 - Avulsa pelo site do Fisco")]
        AvulsaSiteFisco = 2,

        [XmlEnum("3")] [Description("3 - Aplicativo fornecido pelo Fisco")]
        AplicativoFisco = 3
    }

    public enum TipoAmbiente
    {
        [XmlEnum("1")] [Description("1 - Produção")]
        Producao = 1,

        [XmlEnum("2")] [Description("2 - Homologação")]
        Homologacao = 2
    }

    public enum TipoArmamento
    {
        [XmlEnum("0")] [Description("0 - Uso permitido")]
        UsoPermitido = 0,

        [XmlEnum("1")] [Description("1 - Uso restrito")]
        UsoRestrito = 1
    }

    public enum TipoCombustivel
    {
        [XmlEnum("01")] [Description("01 - Álcool")]
        Alcool = 01,

        [XmlEnum("02")] [Description("02 - Gasolina")]
        Gasolina = 02,

        [XmlEnum("03")] [Description("03 - Diesel")]
        Diesel = 03,

        [XmlEnum("04")] [Description("04 - Gasogênio")]
        Gasogenio = 04,

        [XmlEnum("05")] [Description("05 - Gás Metano")]
        GasMetano = 05,

        [XmlEnum("06")] [Description("06 - Elétrico/Fonte Interna")]
        EletricoInterno = 06,

        [XmlEnum("07")] [Description("07 - Elétrico/Fonte Externa")]
        EletricoExterno = 07,

        [XmlEnum("08")] [Description("08 - Gasolina/Gás Natural Combustível")]
        GasolinaGasNatural = 08,

        [XmlEnum("09")] [Description("09 - Álcool/Gás Natural Combustível")]
        AlcoolGasNatural = 09,

        [XmlEnum("10")] [Description("10 - Diesel/Gás Natural Combustível")]
        DieselGasNatural = 10,

        [XmlEnum("11")] [Description("11 - Vide/Campo/Observação")]
        VideObservacao = 11,

        [XmlEnum("12")] [Description("12 - Álcool/Gás Natural Veicular")]
        AlcoolGasNaturalVeicular = 12,

        [XmlEnum("13")] [Description("13 - Gasolina/Gás Natural Veicular")]
        GasolinaGasNaturalVeicular = 13,

        [XmlEnum("14")] [Description("14 - Diesel/Gás Natural Veicular")]
        DieselGasNaturalVeicular = 14,

        [XmlEnum("15")] [Description("15 - Gás Natural Veicular")]
        Gnv = 15,

        [XmlEnum("16")] [Description("16 - Álcool/Gasolina")]
        AlcoolGasolina = 16,

        [XmlEnum("17")] [Description("17 - Gasolina/Álcool/Gás Natural Veicular")]
        GasolinaAlcoolGasNatualVeicular = 17,

        [XmlEnum("18")] [Description("18 - Gasolina/elétrico")]
        GasolinaEletrico = 18
    }

    public enum TipoEmissao
    {
        [XmlEnum("1")] [Description("1 - Emissão normal")]
        Normal = 1,

        [XmlEnum("2")] [Description("2 - Contingência FS-IA")]
        ContingenciaFs = 2,

        [XmlEnum("4")] [Description("4 - Contingência DPEC")]
        ContingenciaDpec = 4,

        [XmlEnum("5")] [Description("5 - Contingência FS-DA")]
        ContingenciaFsDa = 5,

        [XmlEnum("6")] [Description("6 - Contingência SVC-AN")]
        ContingenciaSvcAn = 6,

        [XmlEnum("7")] [Description("7 - Contingência SVC-RS")]
        ContingenciaSvcRs = 7,

        [XmlEnum("9")] [Description("9 - Contingência off-line da NFC-e")]
        ContingenciaOffLineNfce = 9
    }

    public enum TipoNFe
    {
        [XmlEnum("0")] [Description("0 - Entrada")]
        Entrada = 0,

        [XmlEnum("1")] [Description("1 - Saída")]
        Saida = 1
    }

    /// <summary>
    ///     1=Venda concessionária,
    ///     2=Faturamento direto para consumidor final
    ///     3=Venda direta para grandes consumidores (frotista, governo, ...)
    ///     0=Outros
    /// </summary>
    public enum TipoOperacao
    {
        [XmlEnum("1")] [Description("1 - Venda concessionária")]
        Concessionaria = 1,

        [XmlEnum("2")] [Description("2 - Faturamento direto")]
        Direto = 2,

        [XmlEnum("3")] [Description("3 - Venda direta para grandes consumidores")]
        GrandesConsumidores = 3,

        [XmlEnum("0")] [Description("0 - Outros")]
        Outros = 0
    }


    /// <summary>
    ///     0=Não há; 1=Alienação Fiduciária;
    ///     2=Arrendamento Mercantil; 3=Reserva de Domínio;
    ///     4=Penhor de Veículos; 9=Outras. (v2.0)
    /// </summary>
    public enum TipoRestricao
    {
        [XmlEnum("0")] [Description("0 - Não há")]
        Nenhuma = 0,

        [XmlEnum("1")] [Description("1 - Alienação Fiduciária")]
        Alienacao = 1,

        [XmlEnum("2")] [Description("2 - Arrendamento Mercantil")]
        Arrendamento = 2,

        [XmlEnum("3")] [Description("3 - Reserva de Domínio")]
        Reserva = 3,

        [XmlEnum("4")] [Description("4 - Penhor de Veículos")]
        Penhor = 4,

        [XmlEnum("9")] [Description("9 - outras")]
        Outras = 9
    }

    public enum TipoVeiculo
    {
        [XmlEnum("02")] [Description("02 CICLOMOTO")]
        Ciclomoto = 02,

        [XmlEnum("03")] [Description("03 MOTONETA")]
        Motoneta = 03,

        [XmlEnum("04")] [Description("04 MOTOCICLO")]
        Motociclo = 04,

        [XmlEnum("05")] [Description("05 TRICICLO")]
        Triciclo = 05,

        [XmlEnum("06")] [Description("06 AUTOMÓVEL")]
        Automovel = 06,

        [XmlEnum("07")] [Description("07 MICROÔNIBUS")]
        Microonibus = 07,

        [XmlEnum("08")] [Description("08 ÔNIBUS")]
        Onibus = 08,

        [XmlEnum("10")] [Description("10 REBOQUE")]
        Reboque = 10,

        [XmlEnum("13")] [Description("13 CAMINHONETA")]
        Caminhoneta = 13,

        [XmlEnum("14")] [Description("14 CAMINHÃO")]
        Caminhao = 14,

        [XmlEnum("17")] [Description("17 C. TRATOR")]
        Ctrator = 14,

        [XmlEnum("22")] [Description("22 ESP / ÔNIBUS")]
        EspOnibus = 14,

        [XmlEnum("23")] [Description("23 MISTO / CAM")]
        MistoCam = 14,

        [XmlEnum("24")] [Description("24 CARGA / CAM")]
        CargaCam = 14
    }

    public enum VersaoQRCode
    {
        Versao1 = 1,

        Versao2 = 2
    }

    public enum ViaTransporteInternacional
    {
        [XmlEnum("1")] [Description("1 - Marítima")]
        Maritima = 1,

        [XmlEnum("2")] [Description("2 - Fluvial")]
        Fluvial = 2,

        [XmlEnum("3")] [Description("3 - Lacustre")]
        Lacustre = 3,

        [XmlEnum("4")] [Description("4 - Aérea")]
        Aerea = 4,

        [XmlEnum("5")] [Description("5 - Postal")]
        Postal = 5,

        [XmlEnum("6")] [Description("6 - Ferroviária")]
        Ferroviaria = 6,

        [XmlEnum("7")] [Description("7 - Rodoviária")]
        Rodoviaria = 7,

        [XmlEnum("7")] [Description("8 - Conduto / Rede Transmissão")]
        Conduto = 7,

        [XmlEnum("9")] [Description("9 - Meios Próprios")]
        Proprio = 9
    }
}