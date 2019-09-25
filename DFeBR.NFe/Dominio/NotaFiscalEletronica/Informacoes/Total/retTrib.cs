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
    public class retTrib
    {
        #region Propriedades

        /// <summary>
        ///     W24 - Valor Retido de PIS
        /// </summary>
        public decimal? vRetPIS
        {
            get { return _vRetPis.Arredondar(2); }
            set { _vRetPis = value.Arredondar(2); }
        }

        /// <summary>
        ///     W25 - Valor Retido de COFINS
        /// </summary>
        public decimal? vRetCOFINS
        {
            get { return _vRetCofins.Arredondar(2); }
            set { _vRetCofins = value.Arredondar(2); }
        }

        /// <summary>
        ///     W26 - Valor Retido de CSLL
        /// </summary>
        public decimal? vRetCSLL
        {
            get { return _vRetCsll.Arredondar(2); }
            set { _vRetCsll = value.Arredondar(2); }
        }

        /// <summary>
        ///     W27 - Base de Cálculo do IRRF
        /// </summary>
        public decimal? vBCIRRF
        {
            get { return _vBcirrf.Arredondar(2); }
            set { _vBcirrf = value.Arredondar(2); }
        }

        /// <summary>
        ///     W28 - Valor Retido do IRRF
        /// </summary>
        public decimal? vIRRF
        {
            get { return _vIrrf.Arredondar(2); }
            set { _vIrrf = value.Arredondar(2); }
        }

        /// <summary>
        ///     W29 - Base de Cálculo da Retenção da Previdência Social
        /// </summary>
        public decimal? vBCRetPrev
        {
            get { return _vBcRetPrev.Arredondar(2); }
            set { _vBcRetPrev = value.Arredondar(2); }
        }

        /// <summary>
        ///     W30 - Valor da Retenção da Previdência Social
        /// </summary>
        public decimal? vRetPrev
        {
            get { return _vRetPrev.Arredondar(2); }
            set { _vRetPrev = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal? _vBcirrf;
        private decimal? _vBcRetPrev;
        private decimal? _vIrrf;
        private decimal? _vRetCofins;
        private decimal? _vRetCsll;
        private decimal? _vRetPis;
        private decimal? _vRetPrev;

        #endregion

        public bool ShouldSerializevRetPIS()
        {
            return vRetPIS.HasValue;
        }

        public bool ShouldSerializevRetCOFINS()
        {
            return vRetCOFINS.HasValue;
        }

        public bool ShouldSerializevRetCSLL()
        {
            return vRetCSLL.HasValue;
        }

        public bool ShouldSerializevBCIRRF()
        {
            return vBCIRRF.HasValue;
        }

        public bool ShouldSerializevIRRF()
        {
            return vIRRF.HasValue;
        }

        public bool ShouldSerializevBCRetPrev()
        {
            return vBCRetPrev.HasValue;
        }

        public bool ShouldSerializevRetPrev()
        {
            return vRetPrev.HasValue;
        }
    }
}