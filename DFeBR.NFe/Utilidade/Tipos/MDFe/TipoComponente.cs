using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoComponente
    {
        [XmlEnum("01")]
        [Description("Vale Pedágio")]
        ValePedagio = 01,

        [XmlEnum("02")]
        [Description("Impostos, taxas e contribuições")]
        ImpostosTaxasEContribuicoes = 02,

        [XmlEnum("03")]
        [Description("Despesas (bancárias, meios de pagamento, outras)")]
        DespesasBancariasMeiosDePagamentoOutras = 03,

        [XmlEnum("99")]
        [Description("Outros")]
        Outros = 99
    }
}
