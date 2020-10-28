using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum VersaoModalMDFe
    {
        [XmlEnum("1.00")]
        Versao100 = 100,

        [XmlEnum("3.00")]
        Versao300 = 300
    }
}
