namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public  class ImpostosNFCe
    {
        /// <summary>
        ///     Valor total em impostos federais
        /// </summary>
        public decimal ValorImpFederal { get;}

        /// <summary>
        ///     Valor total em impostos estaduais
        /// </summary>
        public decimal ValorImpEstadual { get; }

        /// <summary>
        ///     Valor total em impostos municipais
        /// </summary>
        public decimal ValorImpMunicipal { get;}

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ImpostosNFCe(decimal valorImpFederal, decimal valorImpEstadual, decimal valorImpMunicipal)
        {
            ValorImpFederal = valorImpFederal;
            ValorImpEstadual = valorImpEstadual;
            ValorImpMunicipal = valorImpMunicipal;  
        }

    }
}
