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
       public enum Estado
    {
        [XmlEnum("12")] Ac = 12,

        [XmlEnum("27")] Al = 27,

        [XmlEnum("16")] Ap = 16,

        [XmlEnum("13")] Am = 13,

        [XmlEnum("29")] Ba = 29,

        [XmlEnum("23")] Ce = 23,

        [XmlEnum("53")] Df = 53,

        [XmlEnum("32")] Es = 32,

        [XmlEnum("52")] Go = 52,

        [XmlEnum("21")] Ma = 21,

        [XmlEnum("51")] Mt = 51,

        [XmlEnum("50")] Ms = 50,

        [XmlEnum("31")] Mg = 31,

        [XmlEnum("15")] Pa = 15,

        [XmlEnum("25")] Pb = 25,

        [XmlEnum("41")] Pr = 41,

        [XmlEnum("26")] Pe = 26,

        [XmlEnum("22")] Pi = 22,

        [XmlEnum("33")] Rj = 33,

        [XmlEnum("24")] Rn = 24,

        [XmlEnum("43")] Rs = 43,

        [XmlEnum("11")] Ro = 11,

        [XmlEnum("14")] Rr = 14,

        [XmlEnum("42")] Sc = 42,

        [XmlEnum("35")] Sp = 35,

        [XmlEnum("28")] Se = 28,

        [XmlEnum("17")] To = 17,

        [XmlEnum("91")] An = 91,

        [XmlEnum("99")] Ex = 99
    }
}