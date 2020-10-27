using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoRodado
    {
        [XmlEnum("01")]
        [Description("Truck")]
        Truck = 01,
        [XmlEnum("02")]
        [Description("Toco")]
        Toco = 02,
        [XmlEnum("03")]
        [Description("Cavalo Mecânico")]
        CavaloMecanico = 03,
        [XmlEnum("04")]
        [Description("VAN")]
        VAN = 04,
        [XmlEnum("05")]
        [Description("Utilitário")]
        Utilitario = 05,
        [XmlEnum("06")]
        [Description("Outros")]
        Outros = 06
    }
}
