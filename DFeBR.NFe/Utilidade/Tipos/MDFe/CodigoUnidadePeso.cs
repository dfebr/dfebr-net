using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum CodigoUnidadePeso
    {
        [XmlEnum("01")]
        [Description("KG")]
        KG = 01,

        [XmlEnum("02")]
        [Description("TON")]
        TON = 02,
    }
}
