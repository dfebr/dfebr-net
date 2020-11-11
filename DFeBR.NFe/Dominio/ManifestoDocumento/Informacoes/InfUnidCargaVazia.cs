using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfUnidCargaVazia
    {
        /// <summary>
        /// Identificação da unidades de carga vazia
        /// </summary>
        [XmlElement(ElementName = "idUnidCargaVazia")]
        public string IdUnidCargaVazia { get; set; }

        /// <summary>
        /// Tipo da unidade de carga vazia 
        /// </summary>
        [XmlElement(ElementName = "tpUnidCargaVazia")]
        public TipoUnidCargaVazia TpUnidCargaVazia { get; set; }
    }
}
