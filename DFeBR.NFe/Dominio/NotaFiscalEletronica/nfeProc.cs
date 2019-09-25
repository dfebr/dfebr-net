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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Protocolo;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class nfeProc
    {
        #region Propriedades

        /// <summary>
        ///     XR02
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     XR03 - Dados da NF-e, inclusive com os dados da assinatura (Anexo I)
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public NFe NFe { get; set; }

        /// <summary>
        ///     XR05 - Dados do Protocolo de Autorização de Uso (item 4.2.2)
        /// </summary>
        public protNFe protNFe { get; set; }

        #endregion
    }
}