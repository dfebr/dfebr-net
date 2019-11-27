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
    ///     Indicador do tipo de Operação do CSC
    ///     <para>1 - Consulta CSC Ativos;</para>
    ///     <para>2 - Solicita novo CSC;</para>
    ///     <para>3 - Revoga CSC Ativo</para>
    /// </summary>
    public enum IdentificadorOperacaoCsc
    {
        [XmlEnum("1")] IoConsultaCscAtivos = 1,
        [XmlEnum("2")] IoSolicitaNovoCsc = 2,
        [XmlEnum("3")] IoRevogaCscAtivo = 3
    }
}