using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Rodoviario : Modal
    {
        [XmlElement(ElementName = "infANTT")]
        public InfANTT InfANTT { get; set; }

        /// <summary>
        /// Registro Nacional de Transportadores Rodoviários de Carga
        /// </summary>
        [XmlElement(ElementName = "RNTRC")]
        public string RNTRC { get; set; }

        /// <summary>
        /// Código Identificador da Operação de Transporte
        /// </summary>
        [XmlElement(ElementName = "CIOT")]
        public string CIOT { get; set; }

        /// <summary>
        /// Dados do Veículo com a Tração
        /// </summary>
        [XmlElement(ElementName = "veicTracao")]
        public VeicTracao VeicTracao { get; set; }

        /// <summary>
        /// Dados dos reboques
        /// </summary>
        [XmlElement(ElementName = "veicReboque")]
        public List<VeicReboque> VeicReboque { get; set; }

        /// <summary>
        /// Informações de Vale Pedágio
        /// </summary>
        [XmlElement(ElementName = "valePed")]
        public ValePedagio ValePed { get; set; }

        /// <summary>
        /// Código de Agendamento no porto 
        /// </summary>
        [XmlElement(ElementName = "codAgPorto")]
        public string CodAgPorto { get; set; }

        [XmlElement(ElementName = "lacRodo")]
        public List<Lacre> LacRodo { get; set; }
    }
}
