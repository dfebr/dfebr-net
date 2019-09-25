// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;

#endregion

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class PagamentoNFCe
    {
        #region Propriedades

        /// <summary>
        ///     Valor total em compras
        /// </summary>
        public double ValorTotal { get; set; }

        /// <summary>
        ///     Valor total em descontos
        /// </summary>
        public double ValorTotDesconto { get; set; }

        /// <summary>
        ///     Valor total devido
        /// </summary>
        public double ValorTotDevido { get; set; }

        /// <summary>
        ///     Troco devido
        /// </summary>
        public double Troco { get; set; }

        /// <summary>
        ///     Formas de pagamento
        /// </summary>
        public ICollection<FormPagNFCe> FormasPagamentos { get; set; }

   
        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public PagamentoNFCe(double valorTotal, double valorTotDesconto, double valorTotDevido, double troco, ICollection<FormPagNFCe> formasPagamentos)
        {
            ValorTotal = valorTotal;
            ValorTotDesconto = valorTotDesconto;
            ValorTotDevido = valorTotDevido;
            Troco = troco;
            FormasPagamentos = formasPagamentos;    
        }
    }
}