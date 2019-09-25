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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cana
{
    public class deduc
    {
        #region Propriedades

        /// <summary>
        ///     ZC11 - Descrição da Dedução
        /// </summary>
        public string xDed { get; set; }

        /// <summary>
        ///     ZC12 - Valor da Dedução
        /// </summary>
        public decimal vDed
        {
            get { return _vDed; }
            set { _vDed = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC13 - Valor dos Fornecimentos
        /// </summary>
        public decimal vFor
        {
            get { return _vFor; }
            set { _vFor = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC14 - Valor Total da Dedução
        /// </summary>
        public decimal vTotDed
        {
            get { return _vTotDed; }
            set { _vTotDed = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC15 - Valor Líquido dos Fornecimentos
        /// </summary>
        public decimal vLiqFor
        {
            get { return _vLiqFor; }
            set { _vLiqFor = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vDed;
        private decimal _vFor;
        private decimal _vLiqFor;
        private decimal _vTotDed;

        #endregion
    }
}