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
    public class exporta
    {
        #region Propriedades

        /// <summary>
        ///     ZA02 - Sigla da UF de Embarque ou de transposição de fronteira
        /// </summary>
        public string UFSaidaPais { get; set; }

        /// <summary>
        ///     ZA03 - Descrição do Local de Embarque ou de transposição de fronteira
        /// </summary>
        public string xLocExporta { get; set; }

        /// <summary>
        ///     ZA04 - Descrição do local de despacho
        /// </summary>
        public string xLocDespacho { get; set; }

        #endregion
    }
}