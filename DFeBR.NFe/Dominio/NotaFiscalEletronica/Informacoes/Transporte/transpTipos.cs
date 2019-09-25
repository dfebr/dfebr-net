// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Transporte
{
    /// <summary>
    ///     Versão 3.10
    ///     Versão 4.00
    /// </summary>
    public enum ModalidadeFrete
    {
        /// <summary>
        ///     <para>0=Por conta do emitente [NFe 3.10]</para>
        ///     <para>0=Contratação do Frete por conta do Remetente (CIF) [NFe 4.00]</para>
        /// </summary>
        [XmlEnum("0")] mfContaEmitenteOumfContaRemetente = 0, // Versão 3.1 ou 4.00 com objetivos diferentes e claro

        /// <summary>
        ///     <para>1=Por conta do destinatário/remetente [NFe 3.10]</para>
        ///     <para>1=Contratação do Frete por conta do Destinatário (FOB) [NFe 4.00]</para>
        /// </summary>
        [XmlEnum("1")] mfContaDestinatario = 1,

        /// <summary>
        ///     <para>2=Por conta de terceiros [NFe 3.10]</para>
        ///     <para>2=Contratação do Frete por conta de Terceiros [NFe 4.00]</para>
        /// </summary>
        [XmlEnum("2")] mfContaTerceiros = 2,

        /// <summary>
        ///     3=Transporte Próprio por conta do Remetente [NFe 4.00]
        /// </summary>
        [XmlEnum("3")] mfProprioContaRemente = 3, // Versão 4.00

        /// <summary>
        ///     4=Transporte Próprio por conta do Destinatário [NFe 4.00]
        /// </summary>
        [XmlEnum("4")] mfProprioContaDestinatario = 4, // Versão 4.00

        /// <summary>
        ///     <para>9=Sem frete [NFe 3.10]</para>
        ///     <para>9=Sem Ocorrência de Transporte [NFe 4.00]</para>
        /// </summary>
        [XmlEnum("9")] mfSemFrete = 9
    }
}