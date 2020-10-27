using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class ProdPred
    {
        /// <summary>
        /// Tipo da Carga. 
        /// </summary>
        [XmlElement(ElementName = "tpCarga")]
        public TipoCarga TpCarga { get; set; }

        /// <summary>
        /// Descrição do produto predominante 
        /// </summary>
        [XmlElement(ElementName = "xProd")]
        public string XProd { get; set; }

        /// <summary>
        /// GTIN (Global Trade Item Number) do produto, antigo código EAN ou código de barras
        /// </summary>
        [XmlElement(ElementName = "cEAN")]
        public string CEan { get; set; }

        /// <summary>
        /// Código NCM
        /// </summary>
        [XmlElement(ElementName = "NCM")]
        public string Ncm { get; set; }

        /// <summary>
        /// Informações da carga lotação. Informar somente quando MDF-e for de carga lotação
        /// </summary>
        [XmlElement(ElementName = "infLotacao")]
        public InfLotacao InfLotacao { get; set; }
    }
}