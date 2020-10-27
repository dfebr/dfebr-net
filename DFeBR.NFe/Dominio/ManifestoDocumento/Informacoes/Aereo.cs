using DFeBR.EmissorNFe.Utilidade;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Aereo : Modal
    {
        /// <summary>
        /// Marca da Nacionalidade da aeronave 
        /// </summary>
        [XmlElement(ElementName = "nac")]
        public string Nac { get; set; }

        /// <summary>
        /// Marca de Matrícula da aeronave 
        /// </summary>
        [XmlElement(ElementName = "matr")]
        public string Matr { get; set; }

        /// <summary>
        /// Número do Voo 
        /// </summary>
        [XmlElement(ElementName = "nVoo")]
        public string NVoo { get; set; }

        /// <summary>
        /// Aeródromo de Embarque 
        /// </summary>
        [XmlElement(ElementName = "cAerEmb")]
        public string CAerEmb { get; set; }

        /// <summary>
        /// Aeródromo de Destino 
        /// </summary>
        [XmlElement(ElementName = "cAerDes")]
        public string CAerDes { get; set; }

        /// <summary>
        /// Data do Voo 
        /// </summary>
        [XmlIgnore]
        public DateTime DVoo { get; set; }

        /// <summary>
        /// Proxy para converter DVoo em string yyyy-MM-dd
        /// </summary>
        [XmlElement(ElementName = "dVoo")]
        public string ProxyDVoo
        {
            get { return DVoo.ParaDataString(); }
            set { DVoo = DateTime.Parse(value); }
        }
    }
}
