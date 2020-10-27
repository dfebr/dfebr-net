using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
    public enum TipoTransporte
    {
        [XmlEnum("1")]
        ETC = 1,
        [XmlEnum("2")]
        TAC = 2,
        [XmlEnum("3")]
        CTC = 3
    }
}
