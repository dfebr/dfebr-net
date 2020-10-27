using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento
{
    public class InfMDFeSupl
    {
        /// <summary>
        /// Texto com o QR-Code para consulta do MDF-e
        /// </summary>
        [XmlElement(ElementName = "qrCodMDFe")]
        public string QrCodMDFe { get; set; }
    }
}
