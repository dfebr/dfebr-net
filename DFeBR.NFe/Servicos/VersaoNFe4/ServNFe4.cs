// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:08/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;
using DFeBR.EmissorNFe.Servicos.Interfaces;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

#endregion

namespace DFeBR.EmissorNFe.Servicos.VersaoNFe4
{
    public class ServNFe4 : IServicoStrategy
    {
        #region Propriedades

        /// <summary>
        ///     Configuracao do Emissor
        /// </summary>
        public EmissorServicoConfig EmissorConfig { get; }

        /// <summary>
        ///     Certificado Digital
        /// </summary>
        public X509Certificate2 X509Certificate2 { get; }

        #endregion

        #region Construtor

        public ServNFe4(EmissorServicoConfig emissorConfig)
        {
            EmissorConfig = emissorConfig ?? throw new ArgumentNullException(nameof(emissorConfig));
            EmissorConfig = emissorConfig;
            //Setar dados de configuração do serviço apropriado para NFe 4.0
            EmissorConfig.VersaoServico = VersaoServico.Ve400;
            //Obter certificado Digital
            X509Certificate2 = CertificadoDigital.ObterCertificado(EmissorConfig.Certificado);
        }

        #endregion

        #region Implementacoes

        /// <summary>
        ///     Consulta o status do Serviço de NFe
        /// </summary>
        /// <returns>Retorna status do serviço</returns>
        public IRetConsStat ConsultarStatus()
        {
            var n2 = new ServConsStatNfe4(EmissorConfig, X509Certificate2,
                VersaoServico.Ve400);
            return n2.Executar();
        }

        /// <summary>
        ///     Solicita autorização de uma NFe
        /// </summary>
        /// <param name="idLote">ID do Lote</param>
        /// <param name="nfes">Builder NFe</param>
        /// <param name="compactarMensagem">Define se a mensagem será enviada para a SEFAZ compactada</param>
        /// <returns></returns>
        public IRetAutorz Autorizar(int idLote, List<NFe> nfes,
            bool compactarMensagem = false)
        {
            var n2 = new ServAutorzNfe4(EmissorConfig, X509Certificate2,
                idLote, nfes, VersaoServico.Ve400, compactarMensagem);
            return n2.Executar();
        }

        /// <summary>
        ///     Solicita autorização de uma NFe
        /// </summary>
        /// <param name="xmlNFe">Uma string Xml</param>
        /// <param name="compactarMensagem">Define se a mensagem será enviada para a SEFAZ compactada</param>
        /// <returns></returns>
        public IRetAutorz Autorizar(NFe nfe, bool compactarMensagem = false)
        {
            string xmlNFe = nfe.ObterStringXML();
            var n2 = new ServAutorzNfe4(EmissorConfig, X509Certificate2,
                xmlNFe, VersaoServico.Ve400, compactarMensagem);
            return n2.Executar();
        }

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
        public IRetInut Inutilizar(string cnpj, int ano, string modelo,
            int serie, int numeroInicial, int numeroFinal, string justificativa)
        {
            var modeloDoc = ModeloDocumento(modelo);
            var n2 = new ServInutNfe4(EmissorConfig, X509Certificate2, cnpj, ano, 
                modeloDoc, serie, numeroInicial, numeroFinal, justificativa);
            return n2.Executar();
        }

        /// <summary>
        ///     Consultar NFe por sua Chave
        /// </summary>
        /// <param name="documento">Uma chave Nfe ou uma Xml Nfe bem formada</param>
        /// <param name="pelaChave">True, pesquisar pela chave, False pesquisar por um documento Xml bem formado </param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        public IRetConsProt ConsultarPelaChave(string documento, bool pelaChave, string modelo)
        {
            var modeloDoc = ModeloDocumento(modelo);
            var docProc = pelaChave ? DocumentoProtocolo.Chave : DocumentoProtocolo.Xml;
            var n2 = new ServConsProtNfe4(EmissorConfig, X509Certificate2,
                documento, VersaoServico.Ve400, docProc, modeloDoc);
            return n2.Executar();
        }

        /// <summary>
        ///     Consultar NFe pelo número do recibo
        /// </summary>
        /// <param name="numRecibo">Número do recibo</param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <returns></returns>
        public IRetConsRec ConsultarPeloRecibo(string numRecibo, string modelo)
        {
            var modeloDoc = ModeloDocumento(modelo);
            var n2 = new ServConsRecNfe4(EmissorConfig, X509Certificate2,
                numRecibo, VersaoServico.Ve400, modeloDoc);
            return n2.Executar();
        }

        private static ModeloDocumento ModeloDocumento(string modelo)
        {
            if (modelo != "55" && modelo != "65")
                throw new FalhaValidacaoException("Os modelos válidos são 55 ou 65");
            var modeloDoc = (ModeloDocumento)Enum.Parse(typeof(ModeloDocumento), modelo);
            return modeloDoc;
        }

        /// <summary>
        /// Canelar uma NFe
        /// </summary>
        /// <param name="idlote">Número do lote</param>
        /// <param name="eventoBuilders">Dados do evento cancelar uma NFe</param>
        /// <param name="modelo">Modelo do documento 55 ou 65</param>
        /// <returns></returns>
        public IRetCancelar CancelarNFe(int idlote,
            ICollection<EventoBuilder> eventoBuilders, string modelo)
        {
            var modeloDoc = ModeloDocumento(modelo);
            var n2 = new ServCancNfe4(EmissorConfig,
                X509Certificate2, idlote, eventoBuilders,
                VersaoServico.Ve100, modeloDoc);
            return n2.Executar();
        }

        #endregion
    }
}