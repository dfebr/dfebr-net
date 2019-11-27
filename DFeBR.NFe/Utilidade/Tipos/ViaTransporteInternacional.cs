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
        public enum ViaTransporteInternacional
    {
        [XmlEnum("1")] [Description("1 - Marítima")]
        Maritima = 1,

        [XmlEnum("2")] [Description("2 - Fluvial")]
        Fluvial = 2,

        [XmlEnum("3")] [Description("3 - Lacustre")]
        Lacustre = 3,

        [XmlEnum("4")] [Description("4 - Aérea")]
        Aerea = 4,

        [XmlEnum("5")] [Description("5 - Postal")]
        Postal = 5,

        [XmlEnum("6")] [Description("6 - Ferroviária")]
        Ferroviaria = 6,

        [XmlEnum("7")] [Description("7 - Rodoviária")]
        Rodoviaria = 7,

        [XmlEnum("7")] [Description("8 - Conduto / Rede Transmissão")]
        Conduto = 7,

        [XmlEnum("9")] [Description("9 - Meios Próprios")]
        Proprio = 9
    }
}