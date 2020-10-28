using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    ///  Informações dos Municípios de descarregamento
    /// </summary>
    public class InfMunDescarga
    {
        /// <summary>
        /// Código do Município de Descarregamento
        /// </summary>
        [XmlElement(ElementName = "cMunDescarga")]
        public string CMunDescarga { get; set; }

        /// <summary>
        /// Nome do Município de Descarregamento
        /// </summary>
        [XmlElement(ElementName = "xMunDescarga")]
        public string XMunDescarga { get; set; }

        /// <summary>
        /// Conhecimentos de Tranporte - usar este grupo quando for prestador de serviço de transporte
        /// </summary>
        [XmlElement(ElementName = "infCTe")]
        public List<InfCTe> InfCTe { get; set; }

        /// <summary>
        /// Nota Fiscal Eletronica
        /// </summary>
        [XmlElement(ElementName = "infNFe")]
        public List<InfNFe> InfNFe { get; set; }

        /// <summary>
        /// Manifesto Eletrônico de Documentos Fiscais.Somente para modal Aquaviário (vide regras MOC)
        /// </summary>
        [XmlElement(ElementName = "infMDFeTransp")]
        public List<InfMDFeTransp> InfMdFeTransps { get; set; }
    }
}