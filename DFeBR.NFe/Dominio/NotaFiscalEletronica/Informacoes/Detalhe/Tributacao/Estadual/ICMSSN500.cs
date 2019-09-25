// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System.Xml.Serialization;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using DFeBR.EmissorNFe.Utilidade;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMSSN500 : ICMSBasico
    {
        #region Propriedades

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        [XmlElement(Order = 1)]
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12a - Código de Situação da Operação – Simples Nacional
        /// </summary>
        [XmlElement(Order = 2)]
        public Csosnicms CSOSN { get; set; }

        /// <summary>
        ///     N26 - Valor da BC do ICMS ST retido
        /// </summary>
        [XmlElement(Order = 3)]
        public decimal? vBCSTRet
        {
            get { return _vBcstRet.Arredondar(2); }
            set { _vBcstRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N26a  - Alíquota suportada pelo Consumidor Final
        /// </summary>
        [XmlElement(Order = 4)]
        public decimal? pST
        {
            get { return _pSt.Arredondar(4); }
            set { _pSt = value.Arredondar(4); }
        }

        public bool pSTSpecified
        {
            get { return _pSt.HasValue; }
        }

        /// <summary>
        ///     N26b - Valor ICMS próprio do substituto cobrado em operação anterior
        /// </summary>
        [XmlElement(Order = 5)]
        public decimal? vICMSSubstituto
        {
            get { return _vIcmsSubstituto.Arredondar(2); }
            set { _vIcmsSubstituto = value.Arredondar(2); }
        }

        public bool ShouldSerializevICMSSubstituto()
        {
            return _vIcmsSubstituto.HasValue;
        }

        /// <summary>
        ///     N27 - Valor do ICMS ST retido
        /// </summary>
        [XmlElement(Order = 6)]
        public decimal? vICMSSTRet
        {
            get { return _vIcmsstRet.Arredondar(2); }
            set { _vIcmsstRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N27a - Valor da Base de Cálculo do FCP
        ///     Versão 4.00
        /// </summary>
        [XmlElement(Order = 7)]
        public decimal? vBCFCPSTRet
        {
            get { return _vBcfcpstRet.Arredondar(2); }
            set { _vBcfcpstRet = value.Arredondar(2); }
        }

        public bool vBCFCPSTRetSpecified
        {
            get { return vBCFCPSTRet.HasValue; }
        }

        /// <summary>
        ///     N27b - Percentual do FCP retido anteriormente por Substituição Tributária
        /// </summary>
        [XmlElement(Order = 8)]
        public decimal? pFCPSTRet
        {
            get { return _pFcpstRet.Arredondar(4); }
            set { _pFcpstRet = value.Arredondar(4); }
        }

        public bool pFCPSTRetSpecified
        {
            get { return pFCPSTRet.HasValue; }
        }

        /// <summary>
        ///     N27d - Valor do FCP retido anteriormente por Substituição Tributária
        /// </summary>
        [XmlElement(Order = 9)]
        public decimal? vFCPSTRet
        {
            get { return _vFcpstRet.Arredondar(2); }
            set { _vFcpstRet = value.Arredondar(2); }
        }

        public bool vFCPSTRetSpecified
        {
            get { return vFCPSTRet.HasValue; }
        }

        /// <summary>
        ///     N34 - Percentual de redução da base de cálculo efetiva
        /// </summary>
        [XmlElement(Order = 10)]
        public decimal? pRedBCEfet
        {
            get { return _pRedBCEfet.Arredondar(4); }
            set { _pRedBCEfet = value.Arredondar(4); }
        }

        /// <summary>
        ///     N35 - Valor da base de cálculo efetiva
        /// </summary>
        [XmlElement(Order = 11)]
        public decimal? vBCEfet
        {
            get { return _vBCEfet.Arredondar(2); }
            set { _vBCEfet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N36 - Alíquota do ICMS efetiva
        /// </summary>
        [XmlElement(Order = 12)]
        public decimal? pICMSEfet
        {
            get { return _pICMSEfet.Arredondar(4); }
            set { _pICMSEfet = value.Arredondar(4); }
        }

        /// <summary>
        ///     N37 - Valor do ICMS efetivo
        /// </summary>
        [XmlElement(Order = 13)]
        public decimal? vICMSEfet
        {
            get { return _vICMSEfet.Arredondar(2); }
            set { _vICMSEfet = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal? _pFcpstRet;
        private decimal? _pICMSEfet;
        private decimal? _pRedBCEfet;
        private decimal? _pSt;
        private decimal? _vBCEfet;
        private decimal? _vBcfcpstRet;
        private decimal? _vBcstRet;
        private decimal? _vFcpstRet;
        private decimal? _vICMSEfet;
        private decimal? _vIcmsstRet;
        private decimal? _vIcmsSubstituto;

        #endregion

        public bool ShouldSerializevBCSTRet()
        {
            return vBCSTRet.HasValue;
        }

        public bool ShouldSerializevICMSSTRet()
        {
            return vICMSSTRet.HasValue;
        }

        public bool ShouldSerializepRedBCEfet()
        {
            return pRedBCEfet.HasValue;
        }

        public bool ShouldSerializevBCEfet()
        {
            return vBCEfet.HasValue;
        }

        public bool ShouldSerializepICMSEfet()
        {
            return pICMSEfet.HasValue;
        }

        public bool ShouldSerializevICMSEfet()
        {
            return vICMSEfet.HasValue;
        }
    }
}