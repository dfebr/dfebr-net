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
    public class NFref
    {
        #region Propriedades

        /// <summary>
        ///     BA02 - Chave de acesso da NF-e referenciada
        /// </summary>
        public string refNFe { get; set; }

        /// <summary>
        ///     BA03 - Informação da NF modelo 1/1A referenciada
        /// </summary>
        public refNF refNF { get; set; }

        /// <summary>
        ///     BA10 - Informações da NF de produtor rural referenciada
        /// </summary>
        public refNFP refNFP { get; set; }


        /// <summary>
        ///     BA19 - Chave de acesso do CT-e referenciado
        /// </summary>
        public string refCTe { get; set; }

        /// <summary>
        ///     BA20 - Informações do Cupom Fiscal referenciado
        /// </summary>
        public refECF refECF { get; set; }

        #endregion
    }
}