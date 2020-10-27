using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfPag
    {
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }

        [XmlElement(ElementName = "idEstrangeiro")]
        public string IdEstrangeiro { get; set; }

        [XmlElement(ElementName = "Comp")]
        public List<Comp> Comp { get; set; }

        [XmlIgnore]
        public decimal VContrato { get; set; }

        [XmlElement("vContrato")]
        public decimal VContratoProxy
        {
            get { return Math.Round(VContrato, 2); }
            set { VContrato = value; }
        }

        [XmlElement(ElementName = "indPag")]
        public IndicadorFormaPagamento IndPag { get; set; }

        [XmlElement(ElementName = "infPrazo")]
        public List<InfPrazo> InfPrazo { get; set; }

        [XmlElement(ElementName = "infBanc")]
        public InfBanco InfBanc { get; set; }
    }
}