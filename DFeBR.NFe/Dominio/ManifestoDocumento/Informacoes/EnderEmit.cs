using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class EnderEmit
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        [XmlElement(ElementName = "xLgr")]
        public string XLgr { get; set; }

        /// <summary>
        /// Número 
        /// </summary>
        [XmlElement(ElementName = "nro")]
        public string Nro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [XmlElement(ElementName = "xCpl")]
        public string XCpl { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [XmlElement(ElementName = "xBairro")]
        public string XBairro { get; set; }

        /// <summary>
        /// Código do município (utilizar a tabela do IBGE), informar 9999999 para operações com o exterior.
        /// </summary>
        [XmlElement(ElementName = "cMun")]
        public long CMun { get; set; }

        /// <summary>
        /// Nome do município, , informar EXTERIOR para operações com o exterior
        /// </summary>
        [XmlElement(ElementName = "xMun")]
        public string XMun { get; set; }

        private long _cep;

        /// <summary>
        /// Proxy para colocar zeros a esquerda no CEP 
        /// </summary>
        [XmlElement(ElementName = "CEP")]
        public string CEP
        {
            get { return _cep.ToString("D8"); }
            set { _cep = long.Parse(value); }
        }

        /// <summary>
        /// Sigla da UF, informar EX para operações com o exterior.
        /// </summary>
        [XmlIgnore]
        public Estado UF { get; set; }

        [XmlElement(ElementName = "UF")]
        public string ProxyUF
        {
            get { return UF.ToString(); }
            set { UF = value.SiglaParaEstado(); }
        }

        /// <summary>
        /// Telefone
        /// </summary>
        [XmlElement(ElementName = "fone")]
        public string Fone { get; set; }

        /// <summary>
        /// Endereço de E-mail 
        /// </summary>
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        public bool ShouldSerializeEmail => !string.IsNullOrEmpty(Email);
    }
}
