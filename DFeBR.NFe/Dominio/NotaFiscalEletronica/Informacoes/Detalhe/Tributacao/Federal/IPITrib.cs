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
    public class IPITrib : IPIBasico
    {
        #region Propriedades

        /// <summary>
        ///     O09 - Código da Situação Tributária do IPI:
        /// </summary>
        public CSTIPI CST { get; set; }

        /// <summary>
        ///     O10 - Valor da BC do IPI
        /// </summary>
        public decimal? vBC
        {
            get { return _vBc.Arredondar(2); }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     O13 - Alíquota do IPI
        /// </summary>
        public decimal? pIPI
        {
            get { return _pIpi.Arredondar(4); }
            set { _pIpi = value.Arredondar(4); }
        }

        /// <summary>
        ///     O11 - Quantidade total na unidade padrão para tributação (somente para os produtos tributados por unidade)
        /// </summary>
        public decimal? qUnid
        {
            get { return _qUnid.Arredondar(4); }
            set { _qUnid = value.Arredondar(4); }
        }

        /// <summary>
        ///     O12 - Valor por Unidade Tributável
        /// </summary>
        public decimal? vUnid
        {
            get { return _vUnid.Arredondar(4); }
            set { _vUnid = value.Arredondar(4); }
        }

        /// <summary>
        ///     O14 - Valor do IPI
        /// </summary>
        public decimal? vIPI
        {
            get { return _vIpi.Arredondar(2); }
            set { _vIpi = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal? _pIpi;
        private decimal? _qUnid;
        private decimal? _vBc;
        private decimal? _vIpi;
        private decimal? _vUnid;

        #endregion

        public bool ShouldSerializevBC()
        {
            return vBC.HasValue;
        }

        public bool ShouldSerializepIPI()
        {
            return pIPI.HasValue;
        }

        public bool ShouldSerializeqUnid()
        {
            return qUnid.HasValue;
        }

        public bool ShouldSerializevUnid()
        {
            return vUnid.HasValue;
        }

        public bool ShouldSerializevIPI()
        {
            return vIPI.HasValue;
        }
    }
}