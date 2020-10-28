using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class LacreUnidTransp
    {
        /// <summary>
        /// 6 - Número do lacre 
        /// </summary>
        [XmlElement(ElementName = "nLacre")]
        public string NLacre { get; set; }
    }
}