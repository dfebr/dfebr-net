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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe
{
    public class impostoDevol
    {
        #region Propriedades

        /// <summary>
        ///     UA02 - Percentual da mercadoria devolvida
        /// </summary>
        public decimal pDevol
        {
            get { return _pDevol; }
            set { _pDevol = value.Arredondar(2); }
        }

        /// <summary>
        ///     UA03 - Informação do IPI devolvido
        /// </summary>
        public IPIDevolvido IPI { get; set; }

        #endregion

        #region Variaveis Globais

        private decimal _pDevol;

        #endregion
    }
}