using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Autorizados para download do XML
    /// </summary>
    public class AutXML
    {
        /// <summary>
        /// CNPJ do autorizado 
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// CPF do autorizado
        /// </summary>
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }
    }
}
