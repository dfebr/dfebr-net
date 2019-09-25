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
    ///     A07 - Grupo para distribuir DF-e de interesse
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class distNSU
    {
        #region Propriedades

        /// <summary>
        ///     A08 - Último NSU recebido pelo ator.
        ///     Caso seja informado com zero, ou com um NSU muito antigo, a consulta retornará unicamente as informações resumidas
        ///     e
        ///     documentos fiscais eletrônicos que tenham sido recepcionados pelo Ambiente Nacional nos últimos 3 meses.
        /// </summary>
        public string ultNSU { get; set; }

        #endregion
    }
}