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

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.ConsultaCadastro
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class ConsCad
    {
        #region Propriedades

        /// <summary>
        ///     GP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     GP03 - Dados da consulta
        /// </summary>
        public infConsEnv infCons { get; set; }

        #endregion
    }
}