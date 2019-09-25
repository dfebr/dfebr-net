// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Exportacao
{
    public class detExport
    {
        #region Propriedades

        /// <summary>
        ///     I51 - Número do ato concessório de Drawback
        /// </summary>
        public string nDraw { get; set; }

        /// <summary>
        ///     I52 - Grupo sobre exportação indireta
        /// </summary>
        public exportInd exportInd { get; set; }

        #endregion
    }
}