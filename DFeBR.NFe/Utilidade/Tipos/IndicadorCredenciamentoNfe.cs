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
    ///     Indicador de contribuinte credenciado a emitir NF-e.
    ///     <para>0 - Não credenciado para emissão da NF-e;</para>
    ///     <para>1 - Credenciado;</para>
    ///     <para>2 - Credenciado com obrigatoriedade para todas operações;</para>
    ///     <para>3 - Credenciado com obrigatoriedade parcial;</para>
    ///     <para>
    ///         4 – a SEFAZ não fornece a informação. Este indicador significa apenas que o contribuinte é credenciado para
    ///         emitir NF-e na SEFAZ consultada.
    ///     </para>
    /// </summary>
    public enum IndicadorCredenciamentoNfe
    {
        [XmlEnum("0")] NaoCredenciado = 0,
        [XmlEnum("1")] Credenciado = 1,
        [XmlEnum("2")] CredenciadoTodasOperacoes = 2,
        [XmlEnum("3")] CredenciadoParcial = 3,
        [XmlEnum("4")] SemInformacaoSefaz = 4
    }
}