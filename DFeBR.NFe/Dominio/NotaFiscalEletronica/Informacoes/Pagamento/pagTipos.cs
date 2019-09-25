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

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Pagamento
{
    /// <summary>
    ///     <para>01=Dinheiro</para>
    ///     <para>02=Cheque</para>
    ///     <para>03=Cartão de Crédito</para>
    ///     <para>04=Cartão de Débito</para>
    ///     <para>05=Crédito Loja</para>
    ///     <para>10=Vale Alimentação</para>
    ///     <para>11=Vale Refeição</para>
    ///     <para>12=Vale Presente</para>
    ///     <para>13=Vale Combustível</para>
    ///     <para>14=Duplicata Mercantil (versão 4.00)</para>
    ///     <para>15=Boleto Bancário (versão 4.00)</para>
    ///     <para>90=Sem pagamento (versão 4.00)</para>
    ///     <para>99=Outros</para>
    /// </summary>
    public enum FormaPagamento
    {
        /// <summary>
        ///     01-Dinheiro
        /// </summary>
        [Description("Dinheiro")] [XmlEnum("01")]
        fpDinheiro = 01,

        /// <summary>
        ///     02-Cheque
        /// </summary>
        [Description("Cheque")] [XmlEnum("02")]
        fpCheque = 02,

        /// <summary>
        ///     03-Cartão de Crédito
        /// </summary>
        [Description("Cartão de Crédito")] [XmlEnum("03")]
        fpCartaoCredito = 03,

        /// <summary>
        ///     04-Cartão de Débito
        /// </summary>
        [Description("Cartão de Débito")] [XmlEnum("04")]
        fpCartaoDebito = 04,

        /// <summary>
        ///     05-Crédito Loja
        /// </summary>
        [Description("Crédito Loja")] [XmlEnum("05")]
        fpCreditoLoja = 05,

        /// <summary>
        ///     10-Vale Alimentação
        /// </summary>
        [Description("Vale Alimentação")] [XmlEnum("10")]
        fpValeAlimentacao = 10,

        /// <summary>
        ///     11-Vale Refeição
        /// </summary>
        [Description("Vale Refeição")] [XmlEnum("11")]
        fpValeRefeicao = 11,

        /// <summary>
        ///     12-Vale Presente
        /// </summary>
        [Description("Vale Presente")] [XmlEnum("12")]
        fpValePresente = 12,

        /// <summary>
        ///     13-Vale Combustível
        /// </summary>
        [Description("Vale Combustível")] [XmlEnum("13")]
        fpValeCombustivel = 13,

        /// <summary>
        ///     14-Duplicata Mercantil
        ///     <para>
        ///         Na NT2016.002 (v1.50), foi excluída esta forma de pagamento na emissão de NFC-e (modelo 65),
        ///         porém para NFe (modelo 55) a SEFAZ, até o momento, ainda permite o seu uso.
        ///     </para>
        ///     <see langword="https://github.com/ZeusAutomacao/DFe.NET/issues/790"></see>
        /// </summary>
        [Description("Duplicata Mercantil")] [XmlEnum("14")]
        fpDuplicataMercantil = 14, // VERSÃO 4.00

        /// <summary>
        ///     15-Boleto Bancário
        /// </summary>
        [Description("Boleto Bancário")] [XmlEnum("15")]
        fpBoletoBancario = 15, // VERSÃO 4.00

        /// <summary>
        ///     90-Sem pagamento
        /// </summary>
        [Description("Sem pagamento")] [XmlEnum("90")]
        fpSemPagamento = 90, // VERSÃO 4.00

        /// <summary>
        ///     99-Outros
        /// </summary>
        [Description("Outros")] [XmlEnum("99")]
        fpOutro = 99
    }

    /// <summary>
    ///     <para>01=Visa</para>
    ///     <para>02=Mastercard</para>
    ///     <para>03=American Express</para>
    ///     <para>04=Sorocred</para>
    ///     <para>05=Diners Club (versão 4.00)</para>
    ///     <para>06=Elo (versão 4.00)</para>
    ///     <para>07=Hipercard (versão 4.00)</para>
    ///     <para>08=Aura (versão 4.00)</para>
    ///     <para>09=Cabal (versão 4.00)</para>
    ///     <para>99=Outros</para>
    /// </summary>
    public enum BandeiraCartao
    {
        [Description("Visa")] [XmlEnum("01")] bcVisa = 01,

        [Description("Mastercard")] [XmlEnum("02")]
        bcMasterCard = 02,

        [Description("American Express")] [XmlEnum("03")]
        bcAmericanExpress = 03,

        [Description("Sorocred")] [XmlEnum("04")]
        bcSorocred = 04,

        [Description("Diners Club")] [XmlEnum("05")]
        bcDinersClub = 05,

        [Description("Elo")] [XmlEnum("06")] Elo = 06,

        [Description("Hipercard")] [XmlEnum("07")]
        Hipercard = 07,

        [Description("Aura")] [XmlEnum("08")] Aura = 08,

        [Description("Cabal")] [XmlEnum("09")] Cabal = 09,

        [Description("Outros")] [XmlEnum("99")]
        bcOutros = 99
    }

    /// <summary>
    ///     <para>1=Pagamento integrado com o sistema de automação da empresa(Ex.: equipamento TEF, Comércio Eletrônico);</para>
    ///     <para>Pagamento não integrado com o sistema de automação da empresa(Ex.: equipamento POS);</para>
    /// </summary>
    public enum TipoIntegracaoPagamento
    {
        [XmlEnum("1")] TipIntegradoAutomacao = 1,

        [XmlEnum("2")] TipNaoIntegrado = 2
    }
}