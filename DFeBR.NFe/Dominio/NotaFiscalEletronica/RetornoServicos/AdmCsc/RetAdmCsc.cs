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
using System.Collections.Generic;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.AdmCsc
{
    /// <summary>
    ///     AR01 - Estrutura com os dados de retorno para administrar o CSC
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("retAdmCscNFCe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class RetAdmCsc
    {
        #region Propriedades

        /// <summary>
        ///     AR04 - Identificador do tipo de operação: 1 - Consulta CSC Ativos / 2 - Solicita novo CSC / 3 - Revoga CSC Ativo
        /// </summary>
        public IdentificadorOperacaoCsc indOp { get; set; }

        /// <summary>
        ///     Mensagem XML de envio
        /// </summary>
        public string msgEnvio { get; set; }

        /// <summary>
        ///     Mensagem XML de retorno do serviço
        /// </summary>
        public string msgRetorno { get; set; }

        /// <summary>
        ///     B02 - Versão do leiaute
        /// </summary>
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
        ///     AR07 - Tag de grupo para retorno dos dados de até dois CSC
        /// </summary>
        [XmlElement("dadosCsc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public List<dadosCsc> dadosCsc { get; set; }

        #endregion
         
    }
}