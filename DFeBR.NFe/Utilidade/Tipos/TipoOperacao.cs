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
    ///     1=Venda concessionária,
    ///     2=Faturamento direto para consumidor final
    ///     3=Venda direta para grandes consumidores (frotista, governo, ...)
    ///     0=Outros
    /// </summary>
    public enum TipoOperacao
    {
        [XmlEnum("1")] [Description("1 - Venda concessionária")]
        Concessionaria = 1,

        [XmlEnum("2")] [Description("2 - Faturamento direto")]
        Direto = 2,

        [XmlEnum("3")] [Description("3 - Venda direta para grandes consumidores")]
        GrandesConsumidores = 3,

        [XmlEnum("0")] [Description("0 - Outros")]
        Outros = 0
    }
}