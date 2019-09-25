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
using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.DistribuicaoDFe
{
    /// <summary>
    ///     A09 - Grupo para consultar um DF-e a partir de um NSU específico
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class consNSU
    {
        #region Propriedades

        /// <summary>
        ///     A10 - Número Sequencial Único. Geralmente esta consulta será utilizada quando identificado pelo interessado um NSU
        ///     faltante.
        ///     O Web Service retornará o documento ou informará que o NSU não existe no Ambiente Nacional.
        ///     Assim, esta consulta fechará a lacuna do NSU identificado como faltante.
        /// </summary>
        public string NSU { get; set; }

        #endregion
    }
}