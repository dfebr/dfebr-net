// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Total
{
    public class total
    {
        #region Propriedades

        /// <summary>
        ///     W02 - Grupo Totais referentes ao ICMS
        /// </summary>
        public ICMSTot ICMSTot { get; set; }

        /// <summary>
        ///     W17 - Grupo Totais referentes ao ISSQN
        /// </summary>
        public ISSQNtot ISSQNtot { get; set; }

        /// <summary>
        ///     W23 - Grupo Retenções de Tributos
        /// </summary>
        public retTrib retTrib { get; set; }

        #endregion
    }
}