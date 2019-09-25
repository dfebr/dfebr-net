// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.AdmCsc
{
    /// <summary>
    ///     AP01 - Estrutura com os dados para administrar o CSC
    /// </summary>
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class admCscNFCe
    {
        #region Propriedades



       

        /// <summary>
        ///     AP05 - Raiz do CNPJ do contribuinte
        /// </summary>
        public string raizCNPJ { get; set; }

        /// <summary>
        ///     AP06 - Dados do CSC a ser revogado
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public dadosCsc dadosCsc { get; set; }

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

        #endregion
    }
}