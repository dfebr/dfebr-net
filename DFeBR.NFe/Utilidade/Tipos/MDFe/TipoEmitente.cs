using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum TipoEmitente
    {    
        [XmlEnum("1")]
        PrestadorServicoDeTransporte = 1,
        [XmlEnum("2")]
        TransportadorCargaPropria = 2
    }
}
