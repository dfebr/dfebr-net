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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Consulta
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class procEventoNFe
    {
        #region Propriedades

        /// <summary>
        ///     ZR02
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     ZR03
        /// </summary>
        [XmlElement("evento")]
        public evento Evento { get; set; }
         

        #endregion
    }
}