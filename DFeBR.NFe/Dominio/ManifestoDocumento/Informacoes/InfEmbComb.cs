using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfEmbComb
    {
        /// <summary>
        /// Código da embarcação do comboio 
        /// </summary>
        [XmlElement(ElementName = "cEmbComb")]
        public string CEmbComb { get; set; }

        /// <summary>
        /// Identificador da Balsa 
        /// </summary>
        [XmlElement(ElementName = "xBalsa")]
        public string XBalsa { get; set; }
    }
}