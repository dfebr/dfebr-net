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

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cobranca
{
    public class cobr
    {
        #region Propriedades

        /// <summary>
        ///     Y02 - Grupo Fatura
        /// </summary>
        public fat fat { get; set; }

        /// <summary>
        ///     Y07 - Grupo Duplicata
        ///     <para>Ocorrência: 0-120</para>
        /// </summary>
        [XmlElement("dup")]
        public List<dup> dup { get; set; }

        #endregion
    }
}