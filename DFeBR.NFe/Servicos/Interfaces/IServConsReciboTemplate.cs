// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:06/05/2019
// Todos os direitos reservados
// ===================================================================


#region

#endregion

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IServConsReciboTemplate
    {
        #region Propriedades

        /// <summary>
        ///     Nome do serviço
        /// </summary>
        string NomeServico { get; }

        #endregion

        /// <summary>
        ///     Executar
        /// </summary>
        /// <returns></returns>
        IRetConsRec Executar();
    }
}