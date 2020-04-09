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
    public class Pagamento
    {
        #region Propriedades

        /// <summary>
        ///     Valor total em compras
        /// </summary>
        public decimal ValorTotal { get; }

        /// <summary>
        ///     Valor total em descontos
        /// </summary>
        public decimal ValorTotDesconto { get; }

        /// <summary>
        ///     Valor total devido
        /// </summary>
        public decimal ValorTotDevido { get; }

        /// <summary>
        ///     Troco devido
        /// </summary>
        public decimal? Troco { get; }

        /// <summary>
        ///     Formas de pagamento
        /// </summary>
        public ICollection<FormPag> FormasPagamentos { get; }

   
        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public Pagamento(decimal valorTotal, decimal valorTotDesconto, decimal valorTotDevido, decimal? troco, ICollection<FormPag> formasPagamentos)
        {
            ValorTotal = valorTotal;
            ValorTotDesconto = valorTotDesconto;
            ValorTotDevido = valorTotDevido;
            Troco = troco;
            FormasPagamentos = formasPagamentos;    
        }
    }
}