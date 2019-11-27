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
        public enum TipoCombustivel
    {
        [XmlEnum("01")] [Description("01 - Álcool")]
        Alcool = 01,

        [XmlEnum("02")] [Description("02 - Gasolina")]
        Gasolina = 02,

        [XmlEnum("03")] [Description("03 - Diesel")]
        Diesel = 03,

        [XmlEnum("04")] [Description("04 - Gasogênio")]
        Gasogenio = 04,

        [XmlEnum("05")] [Description("05 - Gás Metano")]
        GasMetano = 05,

        [XmlEnum("06")] [Description("06 - Elétrico/Fonte Interna")]
        EletricoInterno = 06,

        [XmlEnum("07")] [Description("07 - Elétrico/Fonte Externa")]
        EletricoExterno = 07,

        [XmlEnum("08")] [Description("08 - Gasolina/Gás Natural Combustível")]
        GasolinaGasNatural = 08,

        [XmlEnum("09")] [Description("09 - Álcool/Gás Natural Combustível")]
        AlcoolGasNatural = 09,

        [XmlEnum("10")] [Description("10 - Diesel/Gás Natural Combustível")]
        DieselGasNatural = 10,

        [XmlEnum("11")] [Description("11 - Vide/Campo/Observação")]
        VideObservacao = 11,

        [XmlEnum("12")] [Description("12 - Álcool/Gás Natural Veicular")]
        AlcoolGasNaturalVeicular = 12,

        [XmlEnum("13")] [Description("13 - Gasolina/Gás Natural Veicular")]
        GasolinaGasNaturalVeicular = 13,

        [XmlEnum("14")] [Description("14 - Diesel/Gás Natural Veicular")]
        DieselGasNaturalVeicular = 14,

        [XmlEnum("15")] [Description("15 - Gás Natural Veicular")]
        Gnv = 15,

        [XmlEnum("16")] [Description("16 - Álcool/Gasolina")]
        AlcoolGasolina = 16,

        [XmlEnum("17")] [Description("17 - Gasolina/Álcool/Gás Natural Veicular")]
        GasolinaAlcoolGasNatualVeicular = 17,

        [XmlEnum("18")] [Description("18 - Gasolina/elétrico")]
        GasolinaEletrico = 18
    }
}