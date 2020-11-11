using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Tot
    {                      
        /// <summary>
        /// Quantidade total de CT-e relacionados no Manifesto
        /// </summary>
        [XmlElement(ElementName = "qCTe")]
        public int? QCTe { get; set; }

        /// <summary>
        /// Quantidade total de NF-e relacionadas no Manifesto
        /// </summary>
        [XmlElement(ElementName = "qNFe")]
        public int? QNFe { get; set; }

        /// <summary>
        /// Quantidade total de MDF-e relacionados no Manifesto Aquaviário
        /// </summary>
        [XmlElement(ElementName = "qMDFe")]
        public int? QMDFe { get; set; }

        private decimal _vCarga;

        // <summary>
        /// Valor total da carga / mercadorias transportadas
        /// </summary>
        [XmlElement(ElementName = "vCarga")]
        public decimal VCarga
        {
            get { return Math.Round(_vCarga, 2); }
            set { _vCarga = value; }
        }

        /// <summary>
        /// Codigo da unidade de medida do Peso Bruto da Carga / Mercadorias transportadas
        /// </summary>
        [XmlElement(ElementName = "cUnid")]
        public CodigoUnidadePeso CUnid { get; set; }

        private decimal _qCarga;
        /// <summary>
        /// Peso Bruto Total da Carga / Mercadorias transportadas
        /// </summary>
        [XmlElement(ElementName = "qCarga")]
        public decimal QCarga
        {
            get { return Math.Round(_qCarga, 4); }
            set { _qCarga = value; }
        }

        public bool QCTeSpecified => QCTe.HasValue;

        public bool QNFeSpecified => QNFe.HasValue;

        public bool QMDFeSpecified => QMDFe.HasValue;
    }
}
