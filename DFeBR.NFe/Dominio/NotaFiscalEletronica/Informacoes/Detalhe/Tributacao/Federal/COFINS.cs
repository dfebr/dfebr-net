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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal
{
    public class COFINS
    {
        #region Propriedades

        /// <summary>
        ///     <para>S02 (COFINSAliq) - Grupo COFINS tributado pela alíquota</para>
        ///     <para>S03 (COFINSQtde) - Grupo COFINS tributado por Qtde</para>
        ///     <para>S04 (COFINSNT) - Grupo COFINS não tributado</para>
        ///     <para>S05 (COFINSOutr) - Grupo COFINS Outras Operações</para>
        /// </summary>
        [XmlElement("COFINSAliq", typeof(COFINSAliq))]
        [XmlElement("COFINSQtde", typeof(COFINSQtde))]
        [XmlElement("COFINSNT", typeof(COFINSNT))]
        [XmlElement("COFINSOutr", typeof(COFINSOutr))]
        public COFINSBasico TipoCOFINS { get; set; }

        #endregion
    }
}