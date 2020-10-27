using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Vagoes
    {
        private decimal _pesoBc;

        /// <summary>
        /// Peso Base de Cálculo de Frete em Toneladas
        /// </summary>
        [XmlElement(ElementName = "pesoBC")]
        public decimal PesoBC
        {
            get { return Math.Round(_pesoBc, 3); }
            set { _pesoBc = value; }
        }

        private decimal _pesoR;

        /// <summary>
        /// Peso Real em Toneladas
        /// </summary>
        [XmlElement(ElementName = "pesoR")]
        public decimal PesoR
        {
            get { return Math.Round(_pesoR, 3); }
            set { _pesoR = value; }
        }

        /// <summary>
        /// Tipo de Vagão
        /// </summary>
        [XmlElement(ElementName = "tpVag")]
        public string TpVag { get; set; }

        /// <summary>
        /// Serie de Identificação do vagão
        /// </summary>
        [XmlElement(ElementName = "serie")]
        public short Serie { get; set; }

        /// <summary>
        /// Número de Identificação do vagão 
        /// </summary>
        [XmlElement(ElementName = "nVag")]
        public long NVag { get; set; }

        /// <summary>
        /// Sequencia do vagão na composição
        /// </summary>
        [XmlElement(ElementName = "nSeq")]
        public short? NSeq { get; set; }

        public bool NSeqSpecified => NSeq.HasValue;

        private decimal _tu;
        /// <summary>
        /// Tonelada Útil 
        /// </summary>
        [XmlElement(ElementName = "TU")]
        public decimal TU
        {
            get { return Math.Round(_tu, 3); }
            set { _tu = value; }
        }
    }
}