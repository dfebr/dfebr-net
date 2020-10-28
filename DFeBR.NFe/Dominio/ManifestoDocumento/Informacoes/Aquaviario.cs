using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Aquaviario : Modal
    {
        [XmlElement(ElementName = "irin")]
        public string Irin { get; set; }

        /// <summary>
        /// CNPJ da Agência de Navegação
        /// </summary>
        [XmlElement(ElementName = "CNPJAgeNav")]
        public string CNPJAgeNav { get; set; }

        /// <summary>
        /// Código do tipo de embarcação 
        /// </summary>
        [XmlElement(ElementName = "tpEmb")]
        public byte TpEmb { get; set; }

        /// <summary>
        /// Código da embarcação
        /// </summary>
        [XmlElement(ElementName = "cEmbar")]
        public string CEmbar { get; set; }

        /// <summary>
        /// Nome da embarcação 
        /// </summary>
        [XmlElement(ElementName = "xEmbar")]
        public string XEmbar { get; set; }

        /// <summary>
        /// Número da Viagem 
        /// </summary>
        [XmlElement(ElementName = "nViag")]
        public string NViag { get; set; }

        /// <summary>
        /// Código do Porto de Embarque 
        /// </summary>
        [XmlElement(ElementName = "cPrtEmb")]
        public string CPrtEmb { get; set; }

        /// <summary>
        /// Código do Porto de Destino 
        /// </summary>
        [XmlElement(ElementName = "cPrtDest")]
        public string CPrtDest { get; set; }

        [XmlElement(ElementName = "prtTrans")]
        public string PrtTrans { get; set; }

        /// <summary>
        /// Tipo de Navegação 
        /// </summary>
        [XmlElement(ElementName = "tpNav")]
        public TipoNavegacao? TpNav { get; set; }

        /// <summary>
        /// Grupo de informações dos terminais de carregamento.
        /// </summary>
        [XmlElement(ElementName = "infTermCarreg")]
        public List<InfTerminaisCarregamento> InfTermCarregs { get; set; }

        /// <summary>
        /// Grupo de informações dos terminais de descarregamento.
        /// </summary>
        [XmlElement(ElementName = "infTermDescarreg")]
        public List<InfTerminaisDescarregamento> InfTermDescarregs { get; set; }

        /// <summary>
        /// Informações das Embarcações do Comboio
        /// </summary>
        [XmlElement(ElementName = "infEmbComb")]
        public List<InfEmbComb> InfEmbCombs { get; set; }

        /// <summary>
        /// Informações das Undades de Carga vazias
        /// </summary>
        [XmlElement(ElementName = "infUnidCargaVazia")]
        public List<InfUnidCargaVazia> InfUnidCargaVazias { get; set; }

        /// <summary>
        /// Informações das Unidades de Transporte vazias
        /// </summary>
        [XmlElement(ElementName = "infUnidTranspVazia")]
        public List<InfUnidTranspVazia> InfUnidTranspVazia { get; set; }
    }
}