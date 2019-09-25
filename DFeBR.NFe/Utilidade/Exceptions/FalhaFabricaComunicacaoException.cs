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
using System.Collections.Generic;
using System.Net;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Exceptions
{
    #region

    #endregion

    /// <summary>
    ///     Classe responsável pelo tratamento da exceção ComunicacaoException
    /// </summary>
    public static class FalhaFabricaComunicacaoException
    {
        #region Variaveis Globais

        /// <summary>
        ///     Lista com os status de WebException que serão traduzidos para ComunicacaoException
        /// </summary>
        private static readonly List<WebExceptionStatus> ListaComunicacaoException = new List<WebExceptionStatus>
        {
                WebExceptionStatus.CacheEntryNotFound,
                WebExceptionStatus.ConnectFailure,
                WebExceptionStatus.ConnectionClosed,
                WebExceptionStatus.KeepAliveFailure,
                WebExceptionStatus.MessageLengthLimitExceeded,
                WebExceptionStatus.NameResolutionFailure,
                WebExceptionStatus.Pending,
                WebExceptionStatus.PipelineFailure,
                WebExceptionStatus.ProxyNameResolutionFailure,
                WebExceptionStatus.ReceiveFailure,
                WebExceptionStatus.RequestCanceled,
                WebExceptionStatus.RequestProhibitedByCachePolicy,
                WebExceptionStatus.RequestProhibitedByProxy,
                WebExceptionStatus.SendFailure,
                WebExceptionStatus.ServerProtocolViolation,
                WebExceptionStatus.Timeout,
                WebExceptionStatus.UnknownError,
                WebExceptionStatus.ProtocolError
        };

        #endregion

        /// <summary>
        ///     Obtém uma exceção.
        ///     Se o status da <see cref="WebException" /> estiver na lista <see cref="ListaComunicacaoException" />,
        ///     será retornada uma exceção do tipo <see cref="FalhaComunicacaoException" />,
        ///     senão será retornada a própria <see cref="WebException" /> passada no parâmetro
        /// </summary>
        /// <param name="servico"></param>
        /// <param name="webException"></param>
        /// <returns></returns>
        public static Exception ObterException(string servico, WebException webException)
        {
            if (ListaComunicacaoException.Contains(webException.Status))
                return new FalhaComunicacaoException(servico, webException);
            return webException;
        }
    }
}