// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

#endregion

using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Pagamento
{
    public class detPag
    {
        #region Propriedades

        public IndicadorPagamentoDetalhePagamento? indPag { get; set; }

        public bool indPagSpecified
        {
            get { return indPag.HasValue; }
        }

        /// <summary>
        ///     YA02 - Forma de pagamento
        /// </summary>
        public FormaPagamento tPag { get; set; }

        public decimal vPag
        {
            get { return _vPag.Arredondar(2); }
            set { _vPag = value.Arredondar(2); }
        }

        public card card { get; set; }

        #endregion

        #region Variaveis Globais

        private decimal _vPag;

        #endregion
    }
}