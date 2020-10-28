using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    /// <summary>
    /// Informações dos Documentos fiscais vinculados ao manifesto
    /// </summary>
    public class InfDoc
    {
        /// <summary>
        /// Informações dos Municípios de descarregamento
        /// </summary>
        [XmlElement(ElementName = "infMunDescarga")]
        public List<InfMunDescarga> InfMunDescarga { get; set; }
    }
}
