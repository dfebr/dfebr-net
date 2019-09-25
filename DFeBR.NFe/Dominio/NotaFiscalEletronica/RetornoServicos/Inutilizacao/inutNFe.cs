// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


using System.Xml.Serialization;
using DFeBR.EmissorNFe.Dominio.Assinatura;

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Inutilizacao
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class inutNFe
    {
        #region Propriedades

        /// <summary>
        ///     DP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     DP03 - Dados do Pedido
        ///     TAG a ser assinada
        /// </summary>
        public infInutEnv infInut { get; set; }

        /// <summary>
        ///     DP15 - Assinatura XML do grupo identificado pelo atributo “Id”
        /// </summary>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        #endregion
    }
}