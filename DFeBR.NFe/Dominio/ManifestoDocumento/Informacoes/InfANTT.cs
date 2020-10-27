using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfANTT
    {
        /// <summary>
        /// Registro Nacional dos Transportadores Rodoviários de Carga
        /// </summary>
        [XmlElement(ElementName = "RNTRC")]
        public string RNTRC { get; set; }

        /// <summary>
        /// Dados do CIOT
        /// </summary>
        [XmlElement(ElementName = "infCIOT")]
        public List<InfCIOT> InfCIOT { get; set; }

        /// <summary>
        /// Informações de Vale Pedágio 
        /// </summary>
        [XmlElement(ElementName = "valePed")]
        public ValePedagio ValePed { get; set; }

        /// <summary>
        /// Grupo de informações dos contratantes do serviço de transporte
        /// </summary>
        [XmlElement(ElementName = "infContratante")]
        public List<InfContratante> InfContratante { get; set; }

        /// <summary>
        /// Informações do Pagamento do Frete 
        /// </summary>
        [XmlElement(ElementName = "infPag")]
        public List<InfPag> InfPag { get; set; }
    }
}