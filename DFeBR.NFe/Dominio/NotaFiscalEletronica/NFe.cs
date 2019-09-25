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
using DFeBR.EmissorNFe.Dominio.Assinatura;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class NFe
    {
        #region Propriedades

        /// <summary>
        ///     A01 - Informações da Nota Fiscal Eletrônica
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public infNFe infNFe { get; set; }

        /// <summary>
        ///     ZX01 - Informações suplementares da Nota Fiscal
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public infNFeSupl infNFeSupl { get; set; }

        /// <summary>
        ///     XS01
        /// </summary>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        #endregion
    }
}