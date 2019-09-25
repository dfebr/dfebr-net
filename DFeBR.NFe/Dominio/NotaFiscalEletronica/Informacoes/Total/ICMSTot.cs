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

#endregion

using DFeBR.EmissorNFe.Utilidade;

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Total
{
    public class ICMSTot
    {
        #region Propriedades

        /// <summary>
        ///     W03 - Base de Cálculo do ICMS
        /// </summary>
        public decimal vBC
        {
            get { return _vBc.Arredondar(2); }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     W04 - Valor Total do ICMS
        /// </summary>
        public decimal vICMS
        {
            get { return _vIcms.Arredondar(2); }
            set { _vIcms = value.Arredondar(2); }
        }

        /// <summary>
        ///     W04a - Valor Total do ICMS desonerado
        /// </summary>
        public decimal? vICMSDeson
        {
            get { return _vIcmsDeson.Arredondar(2); }
            set { _vIcmsDeson = value.Arredondar(2); }
        } //Nulable por conta da v2.00

        /// <summary>
        ///     W04c - Valor total do ICMS relativo Fundo de Combate à Pobreza(FCP) da UF de destino
        /// </summary>
        public decimal? vFCPUFDest
        {
            get { return _vFcpufDest.Arredondar(2); }
            set { _vFcpufDest = value.Arredondar(2); }
        }

        /// <summary>
        ///     W04e - Valor total do ICMS Interestadual para a UF de destino
        /// </summary>
        public decimal? vICMSUFDest
        {
            get { return _vIcmsufDest.Arredondar(2); }
            set { _vIcmsufDest = value.Arredondar(2); }
        }

        /// <summary>
        ///     W04g - Valor total do ICMS Interestadual para a UF do remetente
        /// </summary>
        public decimal? vICMSUFRemet
        {
            get { return _vIcmsufRemet.Arredondar(2); }
            set { _vIcmsufRemet = value.Arredondar(2); }
        }

        /// <summary>
        ///     W04h - Valor Total do FCP (Fundo de Combate à Pobreza)
        ///     Versão 4.00
        /// </summary>
        public decimal? vFCP
        {
            get { return _vFcp.Arredondar(2); }
            set { _vFcp = value.Arredondar(2); }
        }

        public bool vFCPSpecified
        {
            get { return vFCP.HasValue; }
        }

        /// <summary>
        ///     W05 - Base de Cálculo do ICMS ST
        /// </summary>
        public decimal vBCST
        {
            get { return _vBcst.Arredondar(2); }
            set { _vBcst = value.Arredondar(2); }
        }

        /// <summary>
        ///     W06 - Valor Total do ICMS ST
        /// </summary>
        public decimal vST
        {
            get { return _vSt.Arredondar(2); }
            set { _vSt = value.Arredondar(2); }
        }

        /// <summary>
        ///     W06a - Valor Total do FCP (Vundo de Combate à Pobreza) retido por substituição tributária
        ///     Versão 4.00
        /// </summary>
        public decimal? vFCPST
        {
            get { return _vFcpst.Arredondar(2); }
            set { _vFcpst = value.Arredondar(2); }
        }

        public bool vFCPSTSpecified
        {
            get { return vFCPST.HasValue; }
        }

        /// <summary>
        ///     W06b - Valor Total do FCP retido anteriormente por Substituição Tributária
        ///     Versão 4.00
        /// </summary>
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
        ///     W07 - Valor Total dos produtos e serviços
        /// </summary>
        public decimal vProd
        {
            get { return _vProd.Arredondar(2); }
            set { _vProd = value.Arredondar(2); }
        }

        /// <summary>
        ///     W08 - Valor Total do Frete
        /// </summary>
        public decimal vFrete
        {
            get { return _vFrete.Arredondar(2); }
            set { _vFrete = value.Arredondar(2); }
        }

        /// <summary>
        ///     W09 - Valor Total do Seguro
        /// </summary>
        public decimal vSeg
        {
            get { return _vSeg.Arredondar(2); }
            set { _vSeg = value.Arredondar(2); }
        }

        /// <summary>
        ///     W10 - Valor Total do Desconto
        /// </summary>
        public decimal vDesc
        {
            get { return _vDesc.Arredondar(2); }
            set { _vDesc = value.Arredondar(2); }
        }

        /// <summary>
        ///     W11 - Valor Total do II
        /// </summary>
        public decimal vII
        {
            get { return _vIi.Arredondar(2); }
            set { _vIi = value.Arredondar(2); }
        }

        /// <summary>
        ///     W12 - Valor Total do IPI
        /// </summary>
        public decimal vIPI
        {
            get { return _vIpi.Arredondar(2); }
            set { _vIpi = value.Arredondar(2); }
        }

        /// <summary>
        ///     W12a - Valor Total do IPI devolvido
        ///     Versão 4.00
        /// </summary>
        public decimal? vIPIDevol
        {
            get { return _vIpiDevol.Arredondar(2); }
            set { _vIpiDevol = value.Arredondar(2); }
        }

        public bool vIPIDevolSpecified
        {
            get { return vIPIDevol.HasValue; }
        }

        /// <summary>
        ///     W13 - Valor do PIS
        /// </summary>
        public decimal vPIS
        {
            get { return _vPis.Arredondar(2); }
            set { _vPis = value.Arredondar(2); }
        }

        /// <summary>
        ///     W14 - Valor da COFINS
        /// </summary>
        public decimal vCOFINS
        {
            get { return _vCofins.Arredondar(2); }
            set { _vCofins = value.Arredondar(2); }
        }

        /// <summary>
        ///     W15 - Outras Despesas acessórias
        /// </summary>
        public decimal vOutro
        {
            get { return _vOutro.Arredondar(2); }
            set { _vOutro = value.Arredondar(2); }
        }

        /// <summary>
        ///     w16 - Valor Total da NF-e
        /// </summary>
        public decimal vNF
        {
            get { return _vNf.Arredondar(2); }
            set { _vNf = value.Arredondar(2); }
        }

        /// <summary>
        ///     W16a - Valor aproximado total de tributos federais, estaduais e municipais.
        /// </summary>
        public decimal vTotTrib
        {
            get { return _vTotTrib.Arredondar(2); }
            set { _vTotTrib = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vBc;
        private decimal _vBcst;
        private decimal _vCofins;
        private decimal _vDesc;
        private decimal? _vFcp;
        private decimal? _vFcpst;
        private decimal? _vFcpstRet;
        private decimal? _vFcpufDest;
        private decimal _vFrete;
        private decimal _vIcms;
        private decimal? _vIcmsDeson;
        private decimal? _vIcmsufDest;
        private decimal? _vIcmsufRemet;
        private decimal _vIi;
        private decimal _vIpi;
        private decimal? _vIpiDevol;
        private decimal _vNf;
        private decimal _vOutro;
        private decimal _vPis;
        private decimal _vProd;
        private decimal _vSeg;
        private decimal _vSt;
        private decimal _vTotTrib;

        #endregion

        public bool ShouldSerializevICMSDeson()
        {
            return vICMSDeson.HasValue;
        }

        public bool ShouldSerializevFCPUFDest()
        {
            return vFCPUFDest.HasValue;
        }

        public bool ShouldSerializevICMSUFDest()
        {
            return vICMSUFDest.HasValue;
        }

        public bool ShouldSerializevICMSUFRemet()
        {
            return vICMSUFRemet.HasValue;
        }
    }
}