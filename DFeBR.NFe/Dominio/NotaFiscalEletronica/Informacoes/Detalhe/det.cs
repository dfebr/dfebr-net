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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe
{
    public class det
    {
        #region Propriedades

        /// <summary>
        ///     H02 - Número do item do NF
        /// </summary>
        [XmlAttribute]
        public int nItem { get; set; }

        /// <summary>
        ///     I01 - Detalhamento de Produtos e Serviços
        /// </summary>
        public prod prod { get; set; }

        /// <summary>
        ///     M01 - Tributos incidentes no Produto ou Serviço
        /// </summary>
        public imposto imposto { get; set; }

        /// <summary>
        ///     UA01 - Informação do Imposto devolvido
        /// </summary>
        public impostoDevol impostoDevol { get; set; }

        /// <summary>
        ///     V01 - Informações Adicionais do Produto
        /// </summary>
        public string infAdProd { get; set; }

        #endregion
    }
}