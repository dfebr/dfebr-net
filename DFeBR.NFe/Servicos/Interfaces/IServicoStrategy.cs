// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:11/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DFeBR.EmissorNFe.Builders;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IServicoStrategy
    {
        #region Propriedades

        /// <summary>
        ///     Certificado Digital
        /// </summary>
        X509Certificate2 X509Certificate2 { get; }

        /// <summary>
        ///     Configuracao do Emissor
        /// </summary>
        EmissorServicoConfig EmissorConfig { get; }

        #endregion

        /// <summary>
        ///     Consulta o status do Serviço de NFe
        /// </summary>
        /// <returns>Retorna status do serviço</returns>
        IRetConsStat ConsultarStatus();

        /// <summary>
        ///     Solicita autorização de uma NFe
        /// </summary>
        /// <param name="idLote">ID do Lote</param>
        /// <param name="nFeBuilder">Builder NFe</param>
        /// <param name="compactarMensagem">Define se a mensagem será enviada para a SEFAZ compactada</param>
        /// <returns></returns>
        IRetAutorz Autorizar(int idLote, List<NFe> nFeBuilder, bool compactarMensagem);

        /// <summary>
        ///     Solicita autorização de uma NFe
        /// </summary>
        /// <param name="xmlNFe">Uma string Xml Nfe </param>
        /// <param name="compactarMensagem">Define se a mensagem será enviada para a SEFAZ compactada</param>
        /// <returns></returns>
        IRetAutorz Autorizar(NFe nfeBuilder, bool compactarMensagem = false);

        /// <summary>
        ///     Solicita autorização de uma NFe
        /// </summary>
        /// <param name="xmlNFe">Uma string Xml</param>
        /// <param name="compactarMensagem">Define se a mensagem será enviada para a SEFAZ compactada</param>
        /// <returns></returns>
        IRetAutorz Autorizar(string xmlNFe, bool compactarMensagem = false);

        /// <summary>
        ///     Inutilizar número de nota
        /// </summary>
        /// <param name="cnpj">CNPJ</param>
        /// <param name="ano">Ano</param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <param name="serie">Numero de serie</param>
        /// <param name="numeroInicial">Numero inicial</param>
        /// <param name="numeroFinal">Numero final</param>
        /// <param name="justificativa">Justificativa</param>
        /// <returns></returns>
        IRetInut Inutilizar(string cnpj, int ano, string modelo, int serie, int numeroInicial, int numeroFinal, string justificativa);

        /// <summary>
        ///     Consultar NFe por sua Chave
        /// </summary>
        /// <param name="documento">Uma chave Nfe ou uma Xml Nfe bem formada</param>
        /// <param name="pelaChave">True, pesquisar pela chave, False pesquisar por um documento Xml bem formado </param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <returns></returns>
        IRetConsProt ConsultarPelaChave(string documento, bool pelaChave, string modelo);

        /// <summary>
        ///     Consultar NFe pelo número do recibo
        /// </summary>
        /// <param name="numRecibo">Número do recibo</param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <returns></returns>
        IRetConsRec ConsultarPeloRecibo(string numRecibo, string modelo);

        /// <summary>
        ///     Canelar uma NFe
        /// </summary>
        /// <param name="idlote">Número do lote</param>
        /// <param name="eventoBuilders">Dados do evento cancelar uma NFe</param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <returns></returns>
        IRetCancelar CancelarNFe(int idlote, ICollection<EventoBuilder> eventoBuilders, string modelo);
    }
}