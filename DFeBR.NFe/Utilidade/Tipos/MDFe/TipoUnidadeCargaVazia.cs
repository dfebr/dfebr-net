using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoUnidCargaVazia
    {
        [XmlEnum("1")]
        Container = 1,
        [XmlEnum("2")]
        Carreta = 2
    }
}
