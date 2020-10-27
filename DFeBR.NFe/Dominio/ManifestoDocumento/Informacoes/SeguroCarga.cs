using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Informações de Seguro da Carga
    /// </summary>
    public class SeguroCarga
    {
        /// <summary>
        /// Informações do responsável pelo seguro da carga
        /// </summary>
        [XmlElement(ElementName = "infResp")]
        public InfResp InfResp { get; set; }

        /// <summary>
        /// Informações da seguradora 
        /// </summary>
        [XmlElement(ElementName = "infSeg")]
        public InfSeg InfSeg { get; set; }

        /// <summary>
        /// Número da Apólice 
        /// </summary>
        [XmlElement(ElementName = "nApol")]
        public string NApol { get; set; }

        /// <summary>
        /// Número da Averbação 
        /// </summary>
        [XmlElement(ElementName = "nAver")]
        public List<string> NAver { get; set; }
    }
}
