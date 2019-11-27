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
    ///     1=Importação por conta própria;
    ///     2=Importação por conta e ordem;
    ///     3=Importação por encomenda;
    /// </summary>
    public enum TipoIntermediacao
    {
        /// <summary>
        ///     1=Importação por conta própria
        /// </summary>
        [XmlEnum("1")] ContaPropria = 1,

        /// <summary>
        ///     2=Importação por conta e ordem
        /// </summary>
        [XmlEnum("2")] ContaeOrdem = 2,

        /// <summary>
        ///     3=Importação por encomenda
        /// </summary>
        [XmlEnum("3")] PorEncomenda = 3
    }
}