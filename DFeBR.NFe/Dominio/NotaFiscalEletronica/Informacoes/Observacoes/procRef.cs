// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Observacoes
{
    public class procRef
    {
        #region Propriedades

        /// <summary>
        ///     Z11 - Identificador do processo ou ato concessório
        /// </summary>
        public string nProc { get; set; }

        /// <summary>
        ///     Z12 - Indicador da origem do processo
        /// </summary>
        public IndicadorProcesso indProc { get; set; }

        #endregion
    }
}