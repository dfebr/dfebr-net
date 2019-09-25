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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal
{
    public class II
    {
        #region Propriedades

        /// <summary>
        ///     P02 - Valor BC do Imposto de Importação
        /// </summary>
        public decimal vBC
        {
            get { return _vBc; }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     P03 - Valor despesas aduaneiras
        /// </summary>
        public decimal vDespAdu
        {
            get { return _vDespAdu; }
            set { _vDespAdu = value.Arredondar(2); }
        }

        /// <summary>
        ///     P04 - Valor Imposto de Importação
        /// </summary>
        public decimal vII
        {
            get { return _vIi; }
            set { _vIi = value.Arredondar(2); }
        }

        /// <summary>
        ///     P05 - Valor Imposto sobre Operações Financeiras
        /// </summary>
        public decimal vIOF
        {
            get { return _vIof; }
            set { _vIof = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vBc;
        private decimal _vDespAdu;
        private decimal _vIi;
        private decimal _vIof;

        #endregion
    }
}