using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfTerminaisDescarregamento
    {
        /// <summary>
        /// Código do Terminal de Descarregamento
        /// </summary>
        [XmlElement(ElementName = "cTermDescarreg")]
        public string CTermDescarreg { get; set; }

        /// <summary>
        /// Nome do Terminal de Descarregamento
        /// </summary>
        [XmlElement(ElementName = "xTermDescarreg")]
        public string XTermDescarreg { get; set; }
    }
}
