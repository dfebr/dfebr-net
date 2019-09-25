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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.ProdEspecifico
{
    public class encerrante
    {
        #region Propriedades

        /// <summary>
        ///     LA12 - Número de identificação do bico utilizado no abastecimento
        /// </summary>
        public int nBico { get; set; }

        /// <summary>
        ///     LA13 - Número de identificação da bomba ao qual o bico está interligado
        /// </summary>
        public int? nBomba { get; set; }

        /// <summary>
        ///     LA14 - Número de identificação do tanque ao qual o bico está interligado
        /// </summary>
        public int nTanque { get; set; }

        /// <summary>
        ///     LA15 - Valor do Encerrante no início do abastecimento
        /// </summary>
        public decimal vEncIni
        {
            get { return _vEncIni; }
            set { _vEncIni = value.Arredondar(3); }
        }

        /// <summary>
        ///     LA16 - Valor do Encerrante no final do abastecimento
        /// </summary>
        public decimal vEncFin
        {
            get { return _vEncFin; }
            set { _vEncFin = value.Arredondar(3); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vEncFin;
        private decimal _vEncIni;

        #endregion

        public bool ShouldSerializenBomba()
        {
            return nBomba.HasValue;
        }
    }
}