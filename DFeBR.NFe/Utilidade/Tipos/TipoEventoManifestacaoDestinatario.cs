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
    ///     Tipo do evento de manifestação do destinatário.
    /// </summary>
    public enum TipoEventoManifestacaoDestinatario
    {
        [Description("Confirmacao da Operacao")]
        TeMdConfirmacaoDaOperacao = 210200,

        [Description("Ciencia da Operacao")] TeMdCienciaDaEmissao = 210210,

        [Description("Desconhecimento da Operacao")]
        TeMdDesconhecimentoDaOperacao = 210220,

        [Description("Operacao nao Realizada")]
        TeMdOperacaoNaoRealizada = 210240
    }
}