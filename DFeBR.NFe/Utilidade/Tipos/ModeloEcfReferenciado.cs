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
        public enum ModeloEcfReferenciado
    {
        [XmlEnum("2B")] [Description("2B - Cupom Fiscal máquina registradora")]
        CupomRegistradora = 1,

        [XmlEnum("2C")] [Description("2C - Cupom Fiscal PDV")]
        CupomPdv = 1,

        [XmlEnum("2D")] [Description("2D - Cupom Fiscal (emitido por ECF)")]
        CupomEcf = 1
    }
}