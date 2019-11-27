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
    ///     Informa-se o veículo tem VIN (chassi) remarcado. R=Remarcado; N=Normal
    /// </summary>
    public enum CondicaoVin
    {
        [XmlEnum("R")] [Description("R-Remarcado")]
        Ciclomoto = 0,

        [XmlEnum("N")] [Description("N-Normal")]
        Motoneta = 1
    }
}