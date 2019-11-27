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
        public enum DestinoOperacao
    {
        [XmlEnum("1")] [Description("1 - Operação interna")]
        Interna = 1,

        [XmlEnum("2")] [Description("2 - Operação interestadual")]
        Interestadual = 2,

        [XmlEnum("3")] [Description("3 - Operação com exterior")]
        Exterior = 3
    }
}