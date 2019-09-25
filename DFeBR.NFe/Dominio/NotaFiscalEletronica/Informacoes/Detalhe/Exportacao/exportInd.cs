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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Exportacao
{
    public class exportInd
    {
        #region Propriedades

        /// <summary>
        ///     I53 - Número do Registro de Exportação
        /// </summary>
        public string nRE { get; set; }

        /// <summary>
        ///     I54 - Chave de Acesso da NF-e recebida para exportação
        /// </summary>
        public string chNFe { get; set; }

        /// <summary>
        ///     I55 - Quantidade do item realmente exportado
        /// </summary>
        public decimal qExport
        {
            get { return _qExport; }
            set { _qExport = value.Arredondar(4); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _qExport;

        #endregion
    }
}