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

using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Inutilizacao
{
    /// <summary>
    ///     Pedido de inutilização de numeração de NF-e processado
    /// </summary>
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class procInutNFe
    {
        #region Propriedades

        /// <summary>
        ///     Mensagem de solicitação de inutilização de numeração de NFe.
        /// </summary>
        public inutNFe inutNFe { get; set; }

        /// <summary>
        ///     Mensagem de retorno da solicitação de inutilização de numeração de NF-e.
        /// </summary>
        public retInutNFe retInutNFe { get; set; }

        #endregion
    }
}