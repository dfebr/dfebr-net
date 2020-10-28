using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class ValePedagio
    {
        /// <summary>
        /// Informações dos dispositivos do Vale Pedágio
        /// </summary>
        [XmlElement(ElementName = "disp")]
        public List<Dispositivo> Disp { get; set; }
    }
}