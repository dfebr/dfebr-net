using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfNFe
    {
        /// <summary>
        /// Nota Fiscal Eletrônica 
        /// </summary>
        [XmlElement(ElementName = "chNFe")]
        public string ChNFe { get; set; }

        /// <summary>
        /// Segundo código de barras 
        /// </summary>
        [XmlElement(ElementName = "SegCodBarra")]
        public string SegCodBarra { get; set; }

        /// <summary>
        /// Indicador de Reentrega
        /// Versão 3.0
        /// </summary>
        [XmlElement(ElementName = "indReentrega")]
        public byte? IndReentrega { get; set; }

        public bool IndReentregaSpecified => IndReentrega.HasValue;

        /// <summary>
        /// Informações das Unidades de Transporte (Carreta/Reboque/Vagão) 
        /// </summary>
        [XmlElement(ElementName = "infUnidTransp")]
        public List<InfUnidTransp> InfUnidTransps { get; set; }

        /// <summary>
        /// Preenchido quando for transporte de produtos classificados
        /// pela ONU como perigosos.
        /// MDF-e 3.0
        /// </summary>
        [XmlElement(ElementName = "peri")]
        public List<Perigoso> Peri { get; set; }
    }
}