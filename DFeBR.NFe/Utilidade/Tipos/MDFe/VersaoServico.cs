using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum VersaoServicoMDFe
    {
        [XmlEnum("1.00")]
        [Description("Versão 1.00")]
        Ve100 = 100,

        [XmlEnum("3.00")]
        [Description("Versão 3.00")]
        Ve300 = 300
    }
}
