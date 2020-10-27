using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Ide
    {
        public Ide()
        {
            InfMunCarrega = new List<InfMunCarrega>();
            InfPercurso = new List<InfPercurso>();
        }

        /// <summary>
        /// Código da UF do emitente do MDF-e. 
        /// </summary>
        [XmlElement(ElementName = "cUF")]
        public Estado CUF { get; set; }

        /// <summary>
        /// Tipo do Ambiente 
        /// </summary>
        [XmlElement(ElementName = "tpAmb")]
        public TipoAmbiente TpAmb { get; set; }

        /// <summary>
        /// Tipo do Emitente 
        /// </summary>
        [XmlElement(ElementName = "tpEmit")]
        public TipoEmitente TpEmit { get; set; }

        /// <summary>
        /// MDF-e 3.0
        /// Tipo do Transportador
        /// </summary>
        [XmlElement(ElementName = "tpTransp")]
        public TipoTransporte? TpTransp { get; set; }

        public bool TpTranspSpecified { get { return TpTransp.HasValue; } }

        /// <summary>
        /// Modelo do Manifesto Eletrônico
        /// </summary>
        [XmlElement(ElementName = "mod")]
        public ModeloDocumento Mod { get; set; }

        /// <summary>
        /// Série do Manifesto
        /// </summary>
        [XmlElement(ElementName = "serie")]
        public short Serie { get; set; }

        /// <summary>
        /// Número do Manifesto 
        /// </summary>
        [XmlElement(ElementName = "nMDF")]
        public long NMDF { get; set; }

        public int CMDF { get; set; }

        /// <summary>
        /// Código numérico que compõe a Chave de Acesso. 
        /// </summary>
        [XmlElement(ElementName = "cMDF")]
        public string ProxyCMDF
        {
            get { return CMDF.ToString("00000000"); }
            set { CMDF = int.Parse(value); }
        }

        /// <summary>
        /// Digito verificador da chave de acesso do Manifesto
        /// </summary>
        [XmlElement(ElementName = "cDV")]
        public byte CDV { get; set; }

        /// <summary>
        /// Modalidade de transporte 
        /// </summary>
        [XmlElement(ElementName = "modal")]
        public MDFeModal Modal { get; set; }

        /// <summary>
        /// Data e hora de emissão do Manifesto 
        /// </summary>
        [XmlIgnore]
        public DateTime DhEmi { get; set; }

        /// <summary>
        /// Proxy para dhEmi
        /// </summary>
        [XmlElement(ElementName = "dhEmi")]
        public string ProxyDhEmi
        {
            get { return DhEmi.ParaDataHoraStringUtc(); }
            set { DhEmi = DateTime.Parse(value); }
        }

        /// <summary>
        /// Forma de emissão do Manifesto (Normal ou Contingência)
        /// </summary>
        [XmlElement(ElementName = "tpEmis")]
        public Utilidade.Tipos.MDFe.TipoEmissao TpEmis { get; set; }

        /// <summary>
        /// Identificação do processo de emissão do Manifesto
        /// </summary>
        [XmlElement(ElementName = "procEmi")]
        public IdentificacaoProcessoEmissao ProcEmi { get; set; }

        /// <summary>
        /// Versão do processo de emissão 
        /// </summary>
        [XmlElement(ElementName = "verProc")]
        public string VerProc { get; set; }

        /// <summary>
        /// Sigla da UF do Carregamento 
        /// </summary>
        [XmlIgnore]
        public Estado UFIni { get; set; }

        /// <summary>
        /// Proxy para UFIni
        /// </summary>
        [XmlElement(ElementName = "UFIni")]
        public string ProxyUFIni
        {
            get { return UFIni.ToString(); }
            set { UFIni = value.SiglaParaEstado(); }
        }

        /// <summary>
        /// Sigla da UF do Descarregamento
        /// </summary>
        [XmlIgnore]
        public Estado UFFim { get; set; }

        /// <summary>
        /// Proxy para UFFim
        /// </summary>
        [XmlElement(ElementName = "UFFim")]
        public string ProxyUFFim
        {
            get { return UFFim.ToString(); }
            set { UFFim = value.SiglaParaEstado(); }
        }

        /// <summary>
        /// Informações dos Municípios de Carregamento
        /// </summary>
        [XmlElement(ElementName = "infMunCarrega")]
        public List<InfMunCarrega> InfMunCarrega { get; set; }

        /// <summary>
        /// Informações do Percurso do MDF-e 
        /// </summary>
        [XmlElement(ElementName = "infPercurso")]
        public List<InfPercurso> InfPercurso { get; set; }

        /// <summary>
        /// Data e hora previstos de inicio da viagem
        /// </summary>
        [XmlIgnore]
        public DateTime? DhIniViagem { get; set; }

        /// <summary>
        /// Proxy para dhIniViagem
        /// </summary>
        [XmlElement(ElementName = "dhIniViagem")]
        public string ProxyDhIniViagem { get; set; }

        /// <summary>
        /// Indicador de participação do Canal Verde 
        /// </summary>
        [XmlElement(ElementName = "indCanalVerde")]
        public string IndCanalVerde { get; set; }

        /// <summary>
        /// Indicador de MDF-e com inclusão da Carga posterior a emissão por evento de inclusão de DF-e
        /// </summary>
        [XmlElement(ElementName = "indCarregaPosterior")]
        public string IndCarregaPosterior { get; set; }
    }
}
