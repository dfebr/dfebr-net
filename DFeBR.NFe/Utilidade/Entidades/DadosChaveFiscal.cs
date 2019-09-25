// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Utilidade.Entidades
{
    /// <summary>
    ///     Classe com dados da Chave do DF-e
    /// </summary>
    public class DadosChaveFiscal
    {
        #region Propriedades

        /// <summary>
        ///     Chave de acesso do DF-e
        /// </summary>
        public string Chave { get; }

        /// <summary>
        ///     Dígito verificador da chave de acesso do DF-e
        /// </summary>
        public byte DigitoVerificador { get; }

        #endregion

        #region Construtor

        public DadosChaveFiscal(string chave, byte digitoVerificador)
        {
            Chave = chave;
            DigitoVerificador = digitoVerificador;
        }

        #endregion
    }
}