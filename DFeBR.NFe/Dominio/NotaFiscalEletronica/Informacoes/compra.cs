// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes
{
    public class compra
    {
        #region Propriedades

        /// <summary>
        ///     ZB02 - Nota de Empenho
        /// </summary>
        public string xNEmp { get; set; }

        /// <summary>
        ///     ZB03 - Pedido
        /// </summary>
        public string xPed { get; set; }

        /// <summary>
        ///     ZB04 - Contrato
        /// </summary>
        public string xCont { get; set; }

        #endregion
    }
}