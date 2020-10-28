using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Ferroviario : Modal
    {
        /// <summary>
        /// Informações da composição do trem
        /// </summary>
        [XmlElement(ElementName = "trem")]
        public Trem Trem { get; set; }

        /// <summary>
        /// Informações dos Vagões
        /// </summary>
        [XmlElement(ElementName = "vag")]
        public List<Vagoes> Vag { get; set; }
    }
}