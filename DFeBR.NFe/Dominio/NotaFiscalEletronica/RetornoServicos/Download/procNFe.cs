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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Download
{
    public class procNFe
    {
        #region Propriedades

        /// <summary>
        ///     JR15 - Identificação do Schema XML Exemplo: procNFe_v1.10.xsd.
        /// </summary>
        [XmlAttribute]
        public string schema { get; set; }

        /// <summary>
        ///     JR16 - Estrutura genérica do procNFe, informada com um XML conforme consta no atributo schema acima
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public nfeProc nfeProc { get; set; }

        #endregion
    }
}