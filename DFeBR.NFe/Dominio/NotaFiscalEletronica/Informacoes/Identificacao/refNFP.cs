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

using DFeBR.EmissorNFe.Utilidade.Tipos;

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Identificacao
{
    public class refNFP
    {
        #region Propriedades

        /// <summary>
        ///     BA11 - Código da UF do emitente
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     BA12 - Ano e Mês de emissão da NF-e
        /// </summary>
        public string AAMM { get; set; }

        /// <summary>
        ///     BA13 - CNPJ do emitente
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     BA14 - CPF do emitente
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        ///     BA15 - IE do emitente
        /// </summary>
        public string IE { get; set; }

        /// <summary>
        ///     BA16 - Modelo do Documento Fiscal
        /// </summary>
        public string mod { get; set; }

        /// <summary>
        ///     BA17 - Série do Documento Fiscal
        /// </summary>
        public int serie { get; set; }

        /// <summary>
        ///     BA18 - Número do Documento Fiscal
        /// </summary>
        public int nNF { get; set; }

        #endregion
    }
}