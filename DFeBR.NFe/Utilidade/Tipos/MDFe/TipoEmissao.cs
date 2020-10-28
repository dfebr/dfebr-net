using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoEmissao
    {
        [XmlEnum("1")]
        Normal = 1,
        [XmlEnum("2")]
        Contingencia = 2
    }
}
