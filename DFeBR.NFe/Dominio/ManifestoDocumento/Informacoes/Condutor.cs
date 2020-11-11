using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Condutor
    {
        /// <summary>
        /// Nome do Condutor 
        /// </summary>
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// CPF do Condutor
        /// </summary>
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }
    }
}
