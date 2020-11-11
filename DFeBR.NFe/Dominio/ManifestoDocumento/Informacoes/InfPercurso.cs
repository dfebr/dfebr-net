using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfPercurso
    {
        /// <summary>
        /// Sigla das Unidades da Federação do percurso do veículo.
        /// </summary>
        [XmlIgnore]
        public Estado UFPer { get; set; }

        [XmlElement(ElementName = "UFPer")]
        public string ProxyUFPer
        {
            get { return UFPer.ToString(); }
            set { UFPer = value.SiglaParaEstado(); }
        }
    }
}
