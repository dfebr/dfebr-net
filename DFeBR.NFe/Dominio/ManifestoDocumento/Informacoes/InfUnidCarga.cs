using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Informações das Unidades de Carga (Containeres/ULD/Outros) 
    /// </summary>
    public class InfUnidCarga
    {
        /// <summary>
        /// Tipo da Unidade de Carga
        /// </summary>
        [XmlElement(ElementName = "tpUnidCarga")]
        public TipoUnidadeCarga TpUnidCarga { get; set; }

        /// <summary>
        /// Identificação da Unidade de Carga 
        /// </summary>
        [XmlElement(ElementName = "idUnidCarga")]
        public string IdUnidCarga { get; set; }

        /// <summary>
        /// Lacres das Unidades de Carga 
        /// </summary>
        [XmlElement(ElementName = "lacUnidCarga")]
        public List<LacreUnidCarga> LacUnidCargas { get; set; }

        /// <summary>
        /// Quantidade rateada (Peso,Volume) 
        /// </summary>
        [XmlElement(ElementName = "qtdRat")]
        public decimal? QtdRat { get; set; }
    }
}