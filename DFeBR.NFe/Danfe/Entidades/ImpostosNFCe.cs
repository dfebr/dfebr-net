namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public  class ImpostosNFCe
    {
        /// <summary>
        ///     Valor total em impostos federais
        /// </summary>
        public double ValorImpFederal { get; set; }

        /// <summary>
        ///     Valor total em impostos estaduais
        /// </summary>
        public double ValorImpEstadual { get; set; }

        /// <summary>
        ///     Valor total em impostos municipais
        /// </summary>
        public double ValorImpMunicipal { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ImpostosNFCe(double valorImpFederal, double valorImpEstadual, double valorImpMunicipal)
        {
            ValorImpFederal = valorImpFederal;
            ValorImpEstadual = valorImpEstadual;
            ValorImpMunicipal = valorImpMunicipal;  
        }

    }
}
