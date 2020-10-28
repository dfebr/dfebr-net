using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfMunCarrega
    {
        /// <summary>
        /// Código do Município de Carregamento 
        /// </summary>
        [XmlElement(ElementName = "cMunCarrega")]
        public string CMunCarrega { get; set; }

        /// <summary>
        /// Nome do Município de Carregamento 
        /// </summary>
        [XmlElement(ElementName = "xMunCarrega")]
        public string XMunCarrega { get; set; }
    }
}
