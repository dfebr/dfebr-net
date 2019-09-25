// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Interfaces
{
    public interface IDanfeHtml
    {
        /// <summary>
        ///     Tipo da DANFE
        /// </summary>
        string TipoDanfe { get; }

        /// <summary>
        /// Obter Danfe
        /// </summary>
        /// <returns></returns>
        Documento ObterDocHtml();
    }
}