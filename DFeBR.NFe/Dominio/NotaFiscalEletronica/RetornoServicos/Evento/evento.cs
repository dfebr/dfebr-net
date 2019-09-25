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
using DFeBR.EmissorNFe.Dominio.Assinatura;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento
{
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class evento
    {
        #region Propriedades

        /// <summary>
        ///     HP05 - Versão do leiaute do evento
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     HP06 - Grupo de informações do registro do Evento
        /// </summary>
        public infEventoEnv infEvento { get; set; }

        /// <summary>
        ///     HP22 - Assinatura Digital do documento XML, a assinatura deverá ser aplicada no elemento infEvento
        /// </summary>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        #endregion
    }
}