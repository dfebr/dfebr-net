using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Informações do responsável pelo seguro da carga
    /// </summary>
    public class InfResp
    {
        /// <summary>
        /// Responsável pelo seguro
        /// </summary>
        [XmlElement(ElementName = "respSeg")]
        public ResponsavelSeguro RespSeg { get; set; }

        /// <summary>
        /// Número do CNPJ do responsável pelo seguro
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Número do CPF do responsável pelo seguro
        /// </summary>
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }
    }
}
