using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class VeicTracao
    {
        /// <summary>
        /// Código interno do veículo 
        /// </summary>
        [XmlElement(ElementName = "cInt")]
        public string CInt { get; set; }

        /// <summary>
        /// Placa do veículo
        /// </summary>
        [XmlElement(ElementName = "placa")]
        public string Placa { get; set; }

        /// <summary>
        /// RENAVAM do veículo
        /// </summary>
        [XmlElement(ElementName = "RENAVAM")]
        public string RENAVAM { get; set; }

        /// <summary>
        /// Tara em KG
        /// </summary>
        [XmlElement(ElementName = "tara")]
        public int? Tara { get; set; }

        /// <summary>
        /// Capacidade em KG 
        /// </summary>
        [XmlElement(ElementName = "capKG")]
        public int? CapKG { get; set; }

        /// <summary>
        /// Capacidade em M3 
        /// </summary>
        [XmlElement(ElementName = "capM3")]
        public int? CapM3 { get; set; }

        /// <summary>
        /// Proprietários do Veículo. Só preenchido quando o veículo não pertencer à empresa emitente do MDF-e
        /// </summary>
        [XmlElement(ElementName = "prop")]
        public Proprietario Prop { get; set; }

        /// <summary>
        /// Informações do(s) Condutor(s) do veículo
        /// </summary>
        [XmlElement(ElementName = "condutor")]
        public List<Condutor> Condutor { get; set; }

        /// <summary>
        /// Tipo de Rodado 
        /// </summary>
        [XmlElement(ElementName = "tpRod")]
        public TipoRodado TpRod { get; set; }

        /// <summary>
        /// Tipo de Carroceria 
        /// </summary>
        [XmlElement(ElementName = "tpCar")]
        public TipoCarroceria TpCar { get; set; }

        /// <summary>
        /// UF em que veículo está licenciado 
        /// </summary>
        [XmlIgnore]
        public Estado UF { get; set; }

        /// <summary>
        /// Proxy para obter a sigla uf
        /// </summary>
        [XmlElement(ElementName = "UF")]
        public string ProxyUF
        {
            get { return UF.ToString(); }
            set { UF = value.SiglaParaEstado(); }
        }

        public bool CapKGSpecified => CapKG.HasValue;
        public bool CapM3Specified => CapM3.HasValue;
    }
}