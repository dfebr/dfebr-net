using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Emit
    {
        public Emit()
        {
            EnderEmit = new EnderEmit();
        }

        /// <summary>
        /// CNPJ do emitente 
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        public string CPF { get; set; }

        /// <summary>
        /// Inscrição Estadual do emitemte
        /// </summary>
        [XmlElement(ElementName = "IE")]
        public string IE { get; set; }

        /// <summary>
        /// Razão social ou Nome do emitente 
        /// </summary>
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// Nome fantasia do emitente 
        /// </summary>
        [XmlElement(ElementName = "xFant")]
        public string XFant { get; set; }

        /// <summary>
        /// Endereço do emitente 
        /// </summary>
        [XmlElement(ElementName = "enderEmit")]
        public EnderEmit EnderEmit { get; set; }
    }
}
