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
    ///     A11 - Grupo para consultar uma NF-e pela chave de acesso
    /// </summary>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class consChNFe
    {
        #region Propriedades

        /// <summary>
        ///     A12 - Chave de acesso específica
        /// </summary>
        public string chNFe { get; set; }

        #endregion
    }
}