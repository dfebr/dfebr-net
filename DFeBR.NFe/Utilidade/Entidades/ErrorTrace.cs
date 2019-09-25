// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Utilidade.Entidades
{
    /// <summary>
    ///     The error trace.
    /// </summary>
    public class ErrorTrace
    {
        #region Propriedades

        /// <summary>
        ///     Data do erro
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        ///     Detalhe do erro
        /// </summary>
        public string Detalhe { get; set; }

        /// <summary>
        ///     Rastreamento do Erro
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        ///     Mensagem customizada
        /// </summary>
        public string Mensagem { get; set; }

        #endregion
    }
}