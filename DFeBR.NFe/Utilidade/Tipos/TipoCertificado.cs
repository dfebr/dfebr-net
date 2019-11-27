// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Marcos Vinícius e-mail: marcos8154@gmail.com
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
        /// <summary>
    ///     Tipo de certificado
    /// </summary>
    public enum TipoCertificado
    {
        [Description("Certificado A1")] A1Repositorio = 0,

        [Description("Certificado A1 em arquivo")]
        A1Arquivo = 1,

        [Description("Certificado A3")] A3 = 2,

        [Description("Certificado A1 em byte array")]
        A1ByteArray = 3
    }
}