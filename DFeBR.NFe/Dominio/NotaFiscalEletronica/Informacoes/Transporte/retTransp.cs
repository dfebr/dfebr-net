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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Transporte
{
    public class retTransp
    {
        #region Propriedades

        /// <summary>
        ///     X12 - Valor do Serviço
        /// </summary>
        public decimal vServ
        {
            get { return _vServ; }
            set { _vServ = value.Arredondar(2); }
        }

        /// <summary>
        ///     X13 - BC da Retenção do ICMS
        /// </summary>
        public decimal vBCRet
        {
            get { return _vBcRet; }
            set { _vBcRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     X14 - Alíquota da Retenção
        /// </summary>
        public decimal pICMSRet
        {
            get { return _pIcmsRet; }
            set { _pIcmsRet = value.Arredondar(4); }
        }

        /// <summary>
        ///     X15 - Valor do ICMS Retido
        /// </summary>
        public decimal vICMSRet
        {
            get { return _vIcmsRet; }
            set { _vIcmsRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     X16 - CFOP
        /// </summary>
        public int CFOP { get; set; }

        /// <summary>
        ///     X17 - Código do município de ocorrência do fato gerador do ICMS do transporte
        /// </summary>
        public long cMunFG { get; set; }

        #endregion

        #region Variaveis Globais

        private decimal _pIcmsRet;
        private decimal _vBcRet;
        private decimal _vIcmsRet;
        private decimal _vServ;

        #endregion
    }
}