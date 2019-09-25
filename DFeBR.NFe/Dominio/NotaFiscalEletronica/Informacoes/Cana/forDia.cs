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

using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cana
{
    public class forDia
    {
        #region Propriedades

        /// <summary>
        ///     ZC05 - Dia
        /// </summary>
        [XmlAttribute]
        public int dia { get; set; }

        /// <summary>
        ///     ZC06 - Quantidade
        /// </summary>
        public decimal qtde
        {
            get { return _qtde; }
            set { _qtde = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC07 - Quantidade Total do Mês
        /// </summary>
        public decimal qTotMes
        {
            get { return _qTotMes; }
            set { _qTotMes = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC08 - Quantidade Total Anterior
        /// </summary>
        public decimal qTotAnt
        {
            get { return _qTotAnt; }
            set { _qTotAnt = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC09 - Quantidade Total Geral
        /// </summary>
        public decimal qTotGer
        {
            get { return _qTotGer; }
            set { _qTotGer = value.Arredondar(10); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _qtde;
        private decimal _qTotAnt;
        private decimal _qTotGer;
        private decimal _qTotMes;

        #endregion
    }
}