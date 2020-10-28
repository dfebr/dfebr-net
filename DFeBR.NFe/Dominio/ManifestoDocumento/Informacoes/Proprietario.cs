using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class Proprietario
    {
        /// <summary>
        /// Número do CPF 
        /// </summary>
        [XmlElement(ElementName = "CPF")]
        public string CPF { get; set; }

        /// <summary>
        /// Número do CNPJ 
        /// </summary>
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Registro Nacional dos Transportadores Rodoviários de Carga
        /// </summary>
        [XmlElement(ElementName = "RNTRC")]
        public string RNTRC { get; set; }

        /// <summary>
        /// Razão Social ou Nome do proprietário 
        /// </summary>
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }

        /// <summary>
        /// Inscrição Estadual 
        /// </summary>
        [XmlElement(ElementName = "IE")]
        public string IE { get; set; }

        /// <summary>
        /// UF
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

        /// <summary>
        /// Tipo Proprietário 
        /// </summary>
        [XmlElement(ElementName = "tpProp")]
        public TipoProprietario MDFeTpProp { get; set; }
    }
}