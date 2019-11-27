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
        public enum TipoVeiculo
    {
        [XmlEnum("02")] [Description("02 CICLOMOTO")]
        Ciclomoto = 02,

        [XmlEnum("03")] [Description("03 MOTONETA")]
        Motoneta = 03,

        [XmlEnum("04")] [Description("04 MOTOCICLO")]
        Motociclo = 04,

        [XmlEnum("05")] [Description("05 TRICICLO")]
        Triciclo = 05,

        [XmlEnum("06")] [Description("06 AUTOMÓVEL")]
        Automovel = 06,

        [XmlEnum("07")] [Description("07 MICROÔNIBUS")]
        Microonibus = 07,

        [XmlEnum("08")] [Description("08 ÔNIBUS")]
        Onibus = 08,

        [XmlEnum("10")] [Description("10 REBOQUE")]
        Reboque = 10,

        [XmlEnum("13")] [Description("13 CAMINHONETA")]
        Caminhoneta = 13,

        [XmlEnum("14")] [Description("14 CAMINHÃO")]
        Caminhao = 14,

        [XmlEnum("17")] [Description("17 C. TRATOR")]
        Ctrator = 14,

        [XmlEnum("22")] [Description("22 ESP / ÔNIBUS")]
        EspOnibus = 14,

        [XmlEnum("23")] [Description("23 MISTO / CAM")]
        MistoCam = 14,

        [XmlEnum("24")] [Description("24 CARGA / CAM")]
        CargaCam = 14
    }
}