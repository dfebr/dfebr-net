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

using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using DFeBR.EmissorNFe.Utilidade;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal
{
    public class COFINSAliq : COFINSBasico
    {
        #region Propriedades

        /// <summary>
        ///     S06 - Código de Situação Tributária da COFINS
        /// </summary>
        public CSTCOFINS CST { get; set; }

        /// <summary>
        ///     S07 - Valor da Base de Cálculo da COFINS
        /// </summary>
        public decimal vBC
        {
            get { return _vBc; }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     S08 - Alíquota da COFINS (em percentual)
        /// </summary>
        public decimal pCOFINS
        {
            get { return _pCofins; }
            set { _pCofins = value.Arredondar(4); }
        }

        /// <summary>
        ///     S09 - Valor da COFINS
        /// </summary>
        public decimal vCOFINS
        {
            get { return _vCofins; }
            set { _vCofins = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _pCofins;
        private decimal _vBc;
        private decimal _vCofins;

        #endregion
    }
}