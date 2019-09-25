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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Observacoes
{
    public class infAdic
    {
        #region Propriedades

        /// <summary>
        ///     Z02 - Informações Adicionais de Interesse do Fisco
        /// </summary>
        public string infAdFisco { get; set; }

        /// <summary>
        ///     Z03 - Informações Complementares de interesse do Contribuinte
        /// </summary>
        public string infCpl { get; set; }

        /// <summary>
        ///     Z04 - Grupo Campo de uso livre do contribuinte
        ///     <para>Ocorrência: 0-10</para>
        /// </summary>
        [XmlElement("obsCont")]
        public List<obsCont> obsCont { get; set; }

        /// <summary>
        ///     Z07 - Grupo Campo de uso livre do Fisco
        ///     <para>Ocorrência: 0-10</para>
        /// </summary>
        [XmlElement("obsFisco")]
        public List<obsFisco> obsFisco { get; set; }

        /// <summary>
        ///     Z10 - Grupo Processo referenciado
        ///     <para>Ocorrência: 0-100</para>
        /// </summary>
        [XmlElement("procRef")]
        public List<procRef> procRef { get; set; }

        #endregion

        public bool ShouldSerializeinfCpl()
        {
            return !string.IsNullOrEmpty(infCpl);
        }
    }
}