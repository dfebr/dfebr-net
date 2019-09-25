// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Download
{
    public class procNFeGrupoZip
    {
        #region Propriedades

        /// <summary>
        ///     JR18 - XML da NF-e compactado no padrão gZip, o tipo do campo é base64Binary.
        /// </summary>
        public byte[] NFeZip { get; set; }

        /// <summary>
        ///     JR19 - Protocolo de Autorização de Uso compactado no padrão gZip, o tipo do campo é base64Binary
        /// </summary>
        public byte[] protNFeZip { get; set; }

        #endregion
    }
}