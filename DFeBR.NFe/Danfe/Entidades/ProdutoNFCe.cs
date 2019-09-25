namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class ProdutoNFCe
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Unidade do produto
        /// </summary>
        public string Unidade { get; set; }
        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public double Quantidade { get; set; }
        /// <summary>
        /// Valor unitário do produto
        /// </summary>
        public double ValorUnitario { get; set; }
        /// <summary>
        /// Valor total do produto 
        /// </summary>
        public double ValorTotal { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public ProdutoNFCe(string codigo, string descricao, string unidade, double quantidade, double valorUnitario, double valorTotal)
        {
            Codigo = codigo;
            Descricao = descricao;
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;    
        }
    }
}
