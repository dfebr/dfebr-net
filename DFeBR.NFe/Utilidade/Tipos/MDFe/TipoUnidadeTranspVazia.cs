using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoUnidadeTranspVazia
    {
        [XmlEnum("1")]
        RodoviarioTracaoCaminhao = 1,
        [XmlEnum("2")]
        RodoviarioReboqueCarrega = 2
    }
}
