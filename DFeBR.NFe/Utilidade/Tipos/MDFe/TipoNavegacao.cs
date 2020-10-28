using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoNavegacao
    {
        [XmlEnum("0")]
        Interior = 0,
        [XmlEnum("1")]
        Cabotagem = 1
    }
}
