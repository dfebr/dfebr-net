using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class RespTec
    {
        /// <summary>
        /// CNPJ responsável pelo sistema emissor
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// Nome da pessoa a ser contatada
        /// </summary>
        [XmlElement(ElementName = "xContato")]
        public string XContato { get; set; }

        /// <summary>
        /// Email da pessoa jurídica a ser contatada
        /// </summary>
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone da pessoa física/jurídica a ser contatada
        /// </summary>
        [XmlElement(ElementName = "fone")]
        public string Fone { get; set; }

        /// <summary>
        /// Identificador do CSRT
        /// </summary>
        [XmlElement(ElementName = "idCSRT")]
        public int? IdCSRT { get; set; }        
    }
}
