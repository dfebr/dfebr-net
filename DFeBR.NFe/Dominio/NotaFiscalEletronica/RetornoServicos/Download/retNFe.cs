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
    public class retNFe
    {
        #region Propriedades

        /// <summary>
        ///     JR09 - Chave de acesso da NF-e
        /// </summary>
        public string chNFe { get; set; }
        /// <summary>
        ///     JR13 - Estrutura “procNFe”, compactado no padrão gZip, o tipo do campo é base64Binary.
        ///     JR14 - Estrutura “procNFe”, descompactada
        ///     JR17 - Grupo contendo a NF-e compactada e o Protocolo de Autorização compactado
        /// </summary>
        [XmlElement("procNFe", typeof(procNFe))]
        [XmlElement("procNFeGrupoZip", typeof(procNFeGrupoZip))]
        [XmlElement("procNFeZip", typeof(byte[]), DataType = "base64Binary")]
        public object XmlNfe { get; set; }

        #endregion
    }
}