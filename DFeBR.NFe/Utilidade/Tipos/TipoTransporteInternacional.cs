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
    ///     1=Marítima;
    ///     2=Fluvial;
    ///     3=Lacustre;
    ///     4=Aérea;
    ///     5=Postal
    ///     6=Ferroviária;
    ///     7=Rodoviária;
    ///     8=Conduto / Rede Transmissão;
    ///     9=Meios Próprios;
    ///     10=Entrada / Saída ficta; 11=Courier; 12=Handcarry. (NT 2013/005 v 1.10).
    /// </summary>
    public enum TipoTransporteInternacional
    {
        /// <summary>
        ///     1=Marítima
        /// </summary>
        [XmlEnum("1")] Maritima = 1,

        /// <summary>
        ///     2=Fluvial
        /// </summary>
        [XmlEnum("2")] Fluvial = 2,

        /// <summary>
        ///     3=Lacustre
        /// </summary>
        [XmlEnum("3")] Lacustre = 3,

        /// <summary>
        ///     4=Aérea
        /// </summary>
        [XmlEnum("4")] Aerea = 4,

        /// <summary>
        ///     5=Postal
        /// </summary>
        [XmlEnum("5")] Postal = 5,

        /// <summary>
        ///     6=Ferroviária
        /// </summary>
        [XmlEnum("6")] Ferroviaria = 6,

        /// <summary>
        ///     7=Rodoviária
        /// </summary>
        [XmlEnum("7")] Rodoviaria = 7,

        /// <summary>
        ///     8=Conduto / Rede de Transmissão
        /// </summary>
        [XmlEnum("8")] CondutoRedeTransmissão = 8,

        /// <summary>
        ///     9=Meios Próprios
        /// </summary>
        [XmlEnum("9")] MeiosProprios = 9,

        /// <summary>
        ///     10=Entrada / Saída ficta
        /// </summary>
        [XmlEnum("10")] EntradaSaidaficta = 10,

        /// <summary>
        ///     11=Courier
        /// </summary>
        [XmlEnum("11")] Courier = 11,

        /// <summary>
        ///     12=Handcarry (NT 2013/005 v 1.10)
        /// </summary>
        [XmlEnum("12")] Handcarry = 12
    }
}