using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
    public enum ModalidadeTransporte
    {
        [XmlEnum("1")]
        [Description("Rodoviário")]
        Rodoviario = 1,
        [XmlEnum("2")]
        [Description("Aéreo")]
        Aereo = 2,
        [XmlEnum("3")]
        [Description("Aquaviário")]
        Aquaviario = 1,
        [XmlEnum("4")]
        [Description("Ferroviário")]
        Ferroviario = 1,
    }
}
