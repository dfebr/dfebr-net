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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal.Tipos
{
    /// <summary>
    ///     <para>00-Entrada com recuperação de crédito</para>
    ///     <para>49 - Outras entradas</para>
    ///     <para>50-Saída tributada</para>
    ///     <para>99-Outras saídas</para>
    ///     <para>01-Entrada tributada com alíquota zero</para>
    ///     <para>02-Entrada isenta</para>
    ///     <para>03-Entrada não-tributada</para>
    ///     <para>04-Entrada imune</para>
    ///     <para>05-Entrada com suspensão</para>
    ///     <para>51-Saída tributada com alíquota zero</para>
    ///     <para>52-Saída isenta</para>
    ///     <para>53-Saída não-tributada</para>
    ///     <para>54-Saída imune</para>
    ///     <para>55-Saída com suspensão</para>
    /// </summary>
    public enum CSTIPI
    {
        /// <summary>
        ///     00 - Entrada com recuperação de crédito
        /// </summary>
        [XmlEnum("00")] ipi00,

        /// <summary>
        ///     49 - Outras entradas
        /// </summary>
        [XmlEnum("49")] ipi49,

        /// <summary>
        ///     50 - Saída tributada
        /// </summary>
        [XmlEnum("50")] ipi50,

        /// <summary>
        ///     99 - Outras saídas
        /// </summary>
        [XmlEnum("99")] ipi99,

        /// <summary>
        ///     01 - Entrada tributada com alíquota zero
        /// </summary>
        [XmlEnum("01")] ipi01,

        /// <summary>
        ///     02 - Entrada isenta
        /// </summary>
        [XmlEnum("02")] ipi02,

        /// <summary>
        ///     03 - Entrada não-tributada
        /// </summary>
        [XmlEnum("03")] ipi03,

        /// <summary>
        ///     04 - Entrada imune
        /// </summary>
        [XmlEnum("04")] ipi04,

        /// <summary>
        ///     05 - Entrada com suspensão
        /// </summary>
        [XmlEnum("05")] ipi05,

        /// <summary>
        ///     51 - Saída tributada com alíquota zero
        /// </summary>
        [XmlEnum("51")] ipi51,

        /// <summary>
        ///     52 - Saída isenta
        /// </summary>
        [XmlEnum("52")] ipi52,

        /// <summary>
        ///     53 - Saída não-tributada
        /// </summary>
        [XmlEnum("53")] ipi53,

        /// <summary>
        ///     54 - Saída imune
        /// </summary>
        [XmlEnum("54")] ipi54,

        /// <summary>
        ///     55 - Saída com suspensão
        /// </summary>
        [XmlEnum("55")] ipi55
    }
}