// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:25/04/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IRetBasico
    {
        #region Propriedades

        /// <summary>
        ///     String Xml contendo dados de retorno
        /// </summary>
        string XmlRecebido { get; set; }

        /// <summary>
        ///     Quantidade de solicitações processadas
        /// </summary>
        int Processadas { get; set; }

        /// <summary>
        ///     Quantidade de solicitações rejeitadas ou denegadas
        /// </summary>
        int Rejeitadas { get; set; }

        /// <summary>
        ///     String XML contendo dados enviados
        /// </summary>
        string XmlEnviado { get; set; }

        #endregion
    }
}