using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class LacreUnidCarga
    {
        /// <summary>
        /// 7 - Número do lacre
        /// </summary>
        [XmlElement(ElementName = "nLacre")]
        public string NLacre { get; set; }
    }
}
