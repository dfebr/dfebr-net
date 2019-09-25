// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:11/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento
{
    public class EventoBuilder
    {
        #region Propriedades

        /// <summary>
        /// Sequencial do evento
        /// </summary>
        public int SeqEvento { get; private set; }
        /// <summary>
        ///     Protocolo de Autorização
        /// </summary>
        public string ProtAutorizacao { get; private set; }

        /// <summary>
        ///     Chave da NFe
        /// </summary>
        public string ChaveNFe { get; private set; }

        /// <summary>
        ///     Justificativa
        /// </summary>
        public string Justificativa { get; private set; }

        /// <summary>
        ///     Documento CPF ou CNPJ
        /// </summary>
        public string Cpfcnpj { get; private set; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public EventoBuilder(int seqEvento, string protAutorizacao, string chaveNFe, string justificativa, string cpfcnpj)
        {
            SeqEvento = seqEvento;
            ProtAutorizacao = protAutorizacao;
            ChaveNFe = chaveNFe;
            Justificativa = justificativa;
            Cpfcnpj = cpfcnpj;  
        }
    }
}