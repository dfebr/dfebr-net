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
    public class IPIDevolvido
    {
        #region Propriedades

        /// <summary>
        ///     UA04 - Valor do IPI devolvido
        /// </summary>
        public decimal vIPIDevol
        {
            get { return _vIpiDevol; }
            set { _vIpiDevol = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vIpiDevol;

        #endregion
    }
}