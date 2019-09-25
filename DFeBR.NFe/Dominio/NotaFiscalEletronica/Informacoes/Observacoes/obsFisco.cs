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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Observacoes
{
    public class obsFisco
    {
        #region Propriedades

        /// <summary>
        ///     Z08 - Identificação do campo
        /// </summary>
        [XmlAttribute]
        public string xCampo { get; set; }

        /// <summary>
        ///     Z09 - Conteúdo do campo
        /// </summary>
        public string xTexto { get; set; }

        #endregion
    }
}