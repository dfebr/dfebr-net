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
        public enum Finalidade
    {
        [XmlEnum("1")] [Description("1 - NF-e normal")]
        Normal = 1,

        [XmlEnum("2")] [Description("2 - NF-e complementar")]
        Complementar = 2,

        [XmlEnum("3")] [Description("3 - NF-e de ajuste")]
        Ajuste = 3,

        [XmlEnum("4")] [Description("4 - Devolução")]
        Devolucao = 4
    }
}