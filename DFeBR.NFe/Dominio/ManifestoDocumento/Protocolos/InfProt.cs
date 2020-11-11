using DFeBR.EmissorNFe.Dominio.Assinatura;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Protocolos
{
    public class InfProt
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "tpAmb")]
        public TipoAmbiente TpAmb { get; set; }

        [XmlElement(ElementName = "verAplic")]
        public string VerAplic { get; set; }

        [XmlElement(ElementName = "chMDFe")]
        public string ChMDFe { get; set; }

        [XmlElement(ElementName = "dhRecbto")]
        public DateTime DhRecbto { get; set; }

        [XmlElement(ElementName = "nProt")]
        public string NProt { get; set; }

        [XmlElement(ElementName = "digVal")]
        public string DigVal { get; set; }

        [XmlElement(ElementName = "cStat")]
        public short CStat { get; set; }

        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }

        [XmlElement(ElementName = "Signature")]
        public Signature Signature { get; set; }
    }
}