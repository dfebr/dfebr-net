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
        public enum TipoEmissao
    {
        [XmlEnum("1")] [Description("1 - Emissão normal")]
        Normal = 1,

        [XmlEnum("2")] [Description("2 - Contingência FS-IA")]
        ContingenciaFs = 2,

        [XmlEnum("4")] [Description("4 - Contingência DPEC")]
        ContingenciaDpec = 4,

        [XmlEnum("5")] [Description("5 - Contingência FS-DA")]
        ContingenciaFsDa = 5,

        [XmlEnum("6")] [Description("6 - Contingência SVC-AN")]
        ContingenciaSvcAn = 6,

        [XmlEnum("7")] [Description("7 - Contingência SVC-RS")]
        ContingenciaSvcRs = 7,

        [XmlEnum("9")] [Description("9 - Contingência off-line da NFC-e")]
        ContingenciaOffLineNfce = 9
    }
}