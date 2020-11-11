using DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Informações das Unidades de Transporte (Carreta/Reboque/Vagão) 
    /// </summary>
    public class InfUnidTransp
    {
        /// <summary>
        /// Tipo da Unidade de Transporte 
        /// </summary>
        [XmlElement(ElementName = "tpUnidTransp")]
        public TipoUnidadeTransp TpUnidTransp { get; set; }

        /// <summary>
        /// Identificação da Unidade de Transporte
        /// </summary>
        [XmlElement(ElementName = "idUnidTransp")]
        public string IdUnidTransp { get; set; }

        /// <summary>
        /// Lacres das Unidades de Transporte
        /// </summary>
        [XmlElement(ElementName = "lacUnidTransp")]
        public List<LacreUnidTransp> LacUnidTransps { get; set; }

        /// <summary>
        /// Informações das Unidades de Carga (Containeres/ULD/Outros)
        /// </summary>
        [XmlElement(ElementName = "infUnidCarga")]
        public List<InfUnidCarga> InfUnidCargas { get; set; }

        /// <summary>
        /// Quantidade rateada (Peso,Volume) 
        /// </summary>
        [XmlElement(ElementName = "qtdRat")]
        public decimal? QtdRat { get; set; }
    }
}
