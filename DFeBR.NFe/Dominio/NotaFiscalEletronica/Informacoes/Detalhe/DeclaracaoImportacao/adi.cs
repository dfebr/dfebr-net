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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.DeclaracaoImportacao
{
    public class adi
    {
        #region Propriedades

        /// <summary>
        ///     I26 - Numero da Adição
        /// </summary>
        public int nAdicao { get; set; }

        /// <summary>
        ///     I27 - Numero sequencial do item dentro da Adição
        /// </summary>
        public int nSeqAdic { get; set; }

        /// <summary>
        ///     I28 - Código do fabricante estrangeiro
        /// </summary>
        public string cFabricante { get; set; }

        /// <summary>
        ///     I29 - Valor do desconto do item da DI – Adição
        /// </summary>
        public decimal? vDescDI
        {
            get { return _vDescDi.Arredondar(2); }
            set { _vDescDi = value.Arredondar(2); }
        }

        /// <summary>
        ///     I29a - Número do ato concessório de Drawback
        /// </summary>
        public string nDraw { get; set; }

        #endregion

        #region Variaveis Globais

        private decimal? _vDescDi;

        #endregion

        public bool ShouldSerializevDescDI()
        {
            return vDescDI.HasValue;
        }
    }
}