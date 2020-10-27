using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Comp
    {
        /// <summary>
        /// Tipo do Componente
        /// </summary>
        [XmlElement("tpComp")]
        public TipoComponente TpComp { get; set; }
        
        private decimal _vComp { get; set; }

        /// <summary>
        /// Valor do Componente 
        /// </summary>
        [XmlElement("vComp")]
        public decimal VComp
        {
            get { return Math.Round(_vComp, 2); }
            set { _vComp = value; }
        }

        /// <summary>
        /// Descrição do componente do tipo Outros 
        /// </summary>
        [XmlElement("xComp")]
        public string XComp { get; set; }
    }
}