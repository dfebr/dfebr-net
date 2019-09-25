// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:27/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.ConsultaCadastro
{

    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class RetNfeConsultaCadastro 
    {
        #region Propriedades

        /// <summary>
        ///     Mensagem XML de envio
        /// </summary>
        public string msgEnvio { get; set; }

        /// <summary>
        ///     Mensagem XML de retorno do serviço
        /// </summary>
        public string msgRetorno { get; set; }

        /// <summary>
        ///     GR02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     B03 - Identificação do Ambiente: 1=Produção /2=Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     B04 - Versão do aplicativo que processou a consulta
        /// </summary>
        public string verAplic { get; set; }

        /// <summary>
        ///     B05 - Código do status da resposta (vide item 5)
        /// </summary>
        public int cStat { get; set; }

        /// <summary>
        ///     B06 - Descrição literal do status da resposta
        /// </summary>
        public string xMotivo { get; set; }

        /// <summary>
        ///     B07 - Data e hora da mensagem de Resposta
        /// </summary>
        public DateTime dhResp { get; set; }

        /// <summary>
        ///     GR03 - Dados da consulta
        /// </summary>
        public infConsRet infCons { get; set; }

        #endregion

         
    }
}