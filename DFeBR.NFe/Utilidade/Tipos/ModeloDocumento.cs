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
        public enum ModeloDocumento
    {
        [XmlEnum("55")] [Description("55 - NFe")]
        NFe = 55,

        [XmlEnum("58")] [Description("58 - MDFe")]
        MdFe = 58,

        [XmlEnum("65")] [Description("65 - NFCe")]
        NfCe = 65,

        [XmlEnum("57")] [Description("57 - CTe")]
        CTe = 57,

        [XmlEnum("67")] [Description("67 - CTeOS")]
        CteOs = 67
    }
}