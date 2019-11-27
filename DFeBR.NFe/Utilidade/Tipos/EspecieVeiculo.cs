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
        public enum EspecieVeiculo
    {
        [XmlEnum("01")] [Description("1-PASSAGEIRO")]
        Passageiro = 01,

        [XmlEnum("02")] [Description("2-CARGA")]
        Carga = 02,

        [XmlEnum("03")] [Description("3-MISTO")]
        Misto = 03,

        [XmlEnum("04")] [Description("4-CORRIDA")]
        Corrida = 04,

        [XmlEnum("05")] [Description("5-TRAÇÃO")]
        Tracao = 05,

        [XmlEnum("06")] [Description("6-ESPECIAL")]
        Especial = 06
    }
}