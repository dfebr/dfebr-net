// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe
{
    /// <summary>
    ///     <para>0 – o valor do item (vProd) não compõe o valor total da NF-e (vProd)</para>
    ///     <para>1  – o valor do item (vProd) compõe o valor total da NF-e (vProd)</para>
    /// </summary>
    public enum IndicadorTotal
    {
        [XmlEnum("0")] ValorDoItemNaoCompoeTotalNF = 0,
        [XmlEnum("1")] ValorDoItemCompoeTotalNF = 1
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
    ///     1=Venda concessionária,
    ///     2=Faturamento direto para consumidor final
    ///     3=Venda direta para grandes consumidores (frotista, governo, ...)
    ///     0=Outros
    /// </summary>
    public enum TipoOperacao
    {
        [XmlEnum("0")] Outros = 0,
        [XmlEnum("1")] VendaConcessionaria = 1,
        [XmlEnum("2")] FaturamentodiretoparaconsumidorFinal = 2,
        [XmlEnum("3")] VendaDiretaParaGrandesConsumidores = 3
    }

    /// <summary>
    ///     Informa-se o veículo tem VIN (chassi) remarcado. R=Remarcado; N=Normal
    /// </summary>
    public enum CondicaoVin
    {
        [XmlEnum("R")] Remarcado = 'R',
        [XmlEnum("N")] Normal = 'N'
    }

    /// <summary>
    ///     1=Acabado; 2=Inacabado; 3=Semiacabado
    /// </summary>
    public enum CondicaoVeiculo
    {
        [XmlEnum("1")] Acabado = 1,
        [XmlEnum("2")] Inacabado = 2,
        [XmlEnum("3")] Semiacabado = 3
    }

    /// <summary>
    ///     0=Não há; 1=Alienação Fiduciária;
    ///     2=Arrendamento Mercantil; 3=Reserva de Domínio;
    ///     4=Penhor de Veículos; 9=Outras. (v2.0)
    /// </summary>
    public enum TipoRestricao
    {
        [XmlEnum("0")] Nenhuma = 0,
        [XmlEnum("1")] AlienacaoFiduciaria = 1,
        [XmlEnum("2")] ArrendamentoMercantil = 2,
        [XmlEnum("3")] ReservaDeDominio = 3,
        [XmlEnum("4")] PenhorDeVeiculos = 4,
        [XmlEnum("9")] Outras = 9
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
}