using DFeBR.EmissorNFe.Utilidade;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Trem
    {
        /// <summary>
        /// Prefixo do Trem 
        /// </summary>
        [XmlElement(ElementName = "xPref")]
        public string XPref { get; set; }

        /// <summary>
        /// Data e hora de liberação do trem na origem
        /// </summary>
        [XmlIgnore]
        public DateTime? DhTrem { get; set; }

        [XmlElement(ElementName = "dhTrem")]
        public string ProxyDhTrem
        {
            get { return DhTrem.ParaDataHoraStringUtc(); }
            set { DhTrem = DateTime.Parse(value); }
        }

        /// <summary>
        /// Origem do Trem 
        /// </summary>
        [XmlElement(ElementName = "xOri")]
        public string XOri { get; set; }

        /// <summary>
        /// Destino do Trem 
        /// </summary>
        [XmlElement(ElementName = "xDest")]
        public string XDest { get; set; }

        /// <summary>
        /// Quantidade de vagões carregados 
        /// </summary>
        [XmlElement(ElementName = "qVag")]
        public short QVag { get; set; }
    }
}