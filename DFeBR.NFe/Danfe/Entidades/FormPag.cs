// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Entidades
{

    /// <summary>
    /// Formas de pagamento
    /// </summary>
    public class FormPag
    {
        #region Propriedades

        /// <summary>
        ///     Forma de pagamento
        ///     <para>Dinheiro, Cartão, Débito, etc...</para>
        /// </summary>
        public string Forma { get; set; }

        /// <summary>
        ///     Valor
        /// </summary>
        public decimal Valor { get; set; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public FormPag(string forma, decimal valor)
        {
            Forma = forma;
            Valor = valor;  
        }
    }
}