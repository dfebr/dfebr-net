using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoCarga
    {
        [XmlEnum("01")]
        [Description("Granel Sólido")]
        GranelSolido = 01,

        [XmlEnum("02")]
        [Description("Granel Líquido")]
        GranelLiquido = 02,

        [XmlEnum("03")]
        [Description("Frigorificada")]
        Frigorificada = 03,

        [XmlEnum("04")]
        [Description("Conteinerizada")]
        Conteinerizada = 04,

        [XmlEnum("05")]
        [Description("Carga Geral;")]
        CargaGeral = 05,

        [XmlEnum("06")]
        [Description("Neogranel")]
        Neogranel = 06,

        [XmlEnum("07")]
        [Description("Perigosa (granel sólido)")]
        PerigosaGranelSolido = 07,

        [XmlEnum("08")]
        [Description("Perigosa (granel líquido)")]
        PerigosaGranelLiquido = 08,

        [XmlEnum("09")]
        [Description("Perigosa (carga frigorificada)")]
        PerigosaCargaFrigorificada = 09,

        [XmlEnum("10")]
        [Description("Perigosa (conteinerizada)")]
        PerigosaConteinerizada = 10,

        [XmlEnum("11")]
        [Description("Perigosa (carga geral)")]
        PerigosaCargaGeral = 11
    }
}
