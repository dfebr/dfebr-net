using DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Protocolos;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento
{
    [XmlRoot(ElementName = "mdfeProc", Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public class MDFeProc
    {
        public MDFeProc()
        {
            Versao = VersaoServicoMDFe.Ve300;
        }

        [XmlAttribute(AttributeName = "versao")]
        public VersaoServicoMDFe Versao { get; set; }

        [XmlElement(ElementName = "MDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe")]
        public MDFe MDFe { get; set; }

        [XmlElement(ElementName = "protMDFe")]
        public ProtMDFe ProtMDFe { get; set; }
    }
}
