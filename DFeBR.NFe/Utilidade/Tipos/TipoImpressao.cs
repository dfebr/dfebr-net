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
        public enum TipoImpressao
    {
        [XmlEnum("0")] [Description("0 - Sem geração de DANFE")]
        SemDanfe = 0,

        [XmlEnum("1")] [Description("1 - DANFE normal, Retrato")]
        NormalRetrato = 1,

        [XmlEnum("2")] [Description("2 - DANFE normal, Paisagem")]
        NormalPaisagem = 2,

        [XmlEnum("3")] [Description("3 - DANFE Simplificado")]
        Simplificado = 3,

        [XmlEnum("4")] [Description("4 - DANFE NFC-e")]
        Nfce = 4,

        [XmlEnum("5")] [Description("5 - DANFE NFC-e em mensagem eletrônica")]
        MensagemEletronica = 5
    }
}