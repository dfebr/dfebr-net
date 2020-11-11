using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfBanco
    {
        /// <summary>
        /// Número do banco 
        /// </summary>
        [XmlElement(ElementName = "codBanco")]
        public string CodBanco { get; set; }

        /// <summary>
        /// Número da Agência
        /// </summary>
        [XmlElement(ElementName = "codAgencia")]
        public string CodAgencia { get; set; }

        /// <summary>
        /// Número do CNPJ da Instituição de pagamento Eletrônico do Frete
        /// </summary>
        public string CNPJIPEF { get; set; }
    }
}