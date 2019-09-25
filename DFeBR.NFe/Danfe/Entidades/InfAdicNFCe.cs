namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    /// <summary>
    /// Informaçoes adicionais
    /// </summary>
   public class InfAdicNFCe
    {
        /// <summary>
        /// Descrição das informações adicionais
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public InfAdicNFCe(string descricao)
        {
            Descricao = descricao;  
        }
    }
}
