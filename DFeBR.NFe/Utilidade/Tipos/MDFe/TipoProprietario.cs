using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoProprietario
    {
        [XmlEnum("0")]
        [Description("TAC – Agregado")]
        TacAgregado = 0,
        [XmlEnum("1")]
        [Description("TAC – Independente")]
        TacIndependente = 1,
        [XmlEnum("2")]
        [Description("Outros")]
        Outros = 2
    }
}
