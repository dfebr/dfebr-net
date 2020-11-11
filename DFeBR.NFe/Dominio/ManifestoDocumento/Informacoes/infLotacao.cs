using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfLotacao
    {
        [XmlElement(ElementName = "infLocalCarrega")]
        public InfLocalCarregamento InfLocalCarrega { get; set; }

        [XmlElement(ElementName = "infLocalDescarrega")]
        public InfLocalDescarregamento InfLocalDescarrega { get; set; }
    }
}
