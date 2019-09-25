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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cobranca
{
    public class fat
    {
        #region Propriedades

        /// <summary>
        ///     Y03 - Número da Fatura
        /// </summary>
        public string nFat { get; set; }

        /// <summary>
        ///     Y04 - Valor Original da Fatura
        /// </summary>
        public decimal? vOrig
        {
            get { return _vOrig.Arredondar(2); }
            set { _vOrig = value.Arredondar(2); }
        }

        /// <summary>
        ///     Y05 - Valor do desconto
        /// </summary>
        public decimal? vDesc
        {
            get { return _vDesc.Arredondar(2); }
            set { _vDesc = value.Arredondar(2); }
        }

        /// <summary>
        ///     Y06 - Valor Líquido da Fatura
        /// </summary>
        public decimal? vLiq
        {
            get { return _vLiq.Arredondar(2); }
            set { _vLiq = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal? _vDesc;
        private decimal? _vLiq;
        private decimal? _vOrig;

        #endregion

        public bool ShouldSerializevOrig()
        {
            return vOrig.HasValue;
        }

        public bool ShouldSerializevDesc()
        {
            return vDesc.HasValue;
        }

        public bool ShouldSerializevLiq()
        {
            return vLiq.HasValue;
        }
    }
}