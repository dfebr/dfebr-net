using DFeBR.EmissorNFe.Dominio.Assinatura;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/mdfe", ElementName = "MDFe")]
    public class MDFe
    {
        public MDFe()
        {
            InfMDFe = new InfMDFe();
        }

        [XmlElement(ElementName = "infMDFe")]
        public InfMDFe InfMDFe { get; set; }

        [XmlElement(ElementName = "infMDFeSupl")]
        public InfMDFeSupl InfMDFeSupl { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }
}
