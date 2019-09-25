// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Exceptions
{
    #region

    #endregion

    /// <summary>
    ///     Utilize essa classe para determinar se houve problemas com a internet, durante o envio dos dados para um webservice
    ///     da NFe
    /// </summary>
    public class FalhaComunicacaoException : Exception
    {
        #region Construtor

        /// <summary>
        ///     Houve problemas com a internet, durante o envio dos dados para um webservice da NFe
        /// </summary>
        /// <param name="servico">Serviço que gerou o erro</param>
        /// <param name="ex">Exception</param>
        public FalhaComunicacaoException(string servico, Exception ex) : base(
                $"Sem comunicação com o serviço [ {servico} ]\nRazão:{ex.Message}")
        {
        }

        #endregion
    }
}