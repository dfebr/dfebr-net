using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfContratante
    {
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        /// <summary>
        /// Identificador do responsável pelo pgto em caso de ser estrangeiro
        /// </summary>
        [XmlElement(ElementName = "idEstrangeiro")]
        public string IdEstrangeiro { get; set; }
    }
}