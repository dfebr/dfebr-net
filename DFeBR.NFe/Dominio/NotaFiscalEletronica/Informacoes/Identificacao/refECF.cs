// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Identificacao
{
    public class refECF
    {
        #region Propriedades

        /// <summary>
        ///     BA21 - Modelo do Documento Fiscal
        /// </summary>
        public string mod { get; set; }

        /// <summary>
        ///     BA22 - Número de ordem sequencial do ECF
        /// </summary>
        public int nECF { get; set; }

        /// <summary>
        ///     BA23 - Número do Contador de Ordem de Operação - COO
        /// </summary>
        public int nCOO { get; set; }

        #endregion
    }
}