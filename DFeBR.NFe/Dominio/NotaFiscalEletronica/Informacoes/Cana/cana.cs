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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cana
{
    public class cana
    {
        #region Propriedades

        /// <summary>
        ///     ZC02 - Identificação da safra
        /// </summary>
        public string safra { get; set; }

        /// <summary>
        ///     ZC03 - Mês e ano de referência
        /// </summary>
        public string @ref { get; set; }

        /// <summary>
        ///     ZC04 - Grupo Fornecimento diário de cana
        /// </summary>
        [XmlElement("forDia")]
        public List<forDia> forDia { get; set; }

        /// <summary>
        ///     ZC10 - Grupo Deduções – Taxas e Contribuições
        /// </summary>
        [XmlElement("deduc")]
        public List<deduc> deduc { get; set; }

        #endregion
    }
}