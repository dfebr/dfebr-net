using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfAdic
    {
        /// <summary>
        /// Informações adicionais de interesse do Fisco
        /// </summary>
        [XmlElement(ElementName = "infAdFisco")]
        public string InfAdFisco { get; set; }

        /// <summary>
        /// Informações complementares de interesse do Contribuinte
        /// </summary>
        [XmlElement(ElementName = "infCpl")]
        public string InfCpl { get; set; }
    }
}
