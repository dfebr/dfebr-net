using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoCarroceria
    {
        [XmlEnum("00")]
        [Description("Não Aplicável")]
        NaoAplicavel = 00,

        [XmlEnum("01")]
        [Description("Aberta")]
        Aberta = 01,

        [XmlEnum("02")]
        [Description("Fechada/Baú")]
        FechadaBau = 02,

        [XmlEnum("03")]
        [Description("Granelera")]
        Granelera = 03,

        [XmlEnum("04")]
        [Description("Porta Container")]
        PortaContainer = 04,

        [XmlEnum("05")]
        [Description("Sider")]
        Sider = 05
    }
}
