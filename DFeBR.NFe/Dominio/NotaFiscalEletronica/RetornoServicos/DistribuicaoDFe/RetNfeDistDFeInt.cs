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
using System.ComponentModel;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.DistribuicaoDFe
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [XmlRoot("retDistDFeInt", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class RetNfeDistDFeInt 
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
        ///     B02 - Versão do leiaute
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
        ///     B08 - Último NSU pesquisado no Ambiente Nacional. Se for o caso, o solicitante pode continuar a consulta a partir
        ///     deste NSU para obter novos resultados.
        /// </summary>
        public long ultNSU { get; set; }

        /// <summary>
        ///     B09 - Maior NSU existente no Ambiente Nacional para o CNPJ/CPF informado
        /// </summary>
        public long maxNSU { get; set; }

        /// <summary>
        ///     B10 Conjunto de informações resumidas e documentos fiscais eletrônicos de interesse da pessoa física ou empresa.
        /// </summary>
        [XmlArrayItem("docZip", IsNullable = false)]
        public loteDistDFeInt[] loteDistDFeInt { get; set; }

        #endregion

      
    }
}