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

using System;
using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.DistribuicaoDFe.Schemas
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class eventoInfEvento
    {
        #region Propriedades

        public byte cOrgao { get; set; }

        public byte tpAmb { get; set; }

        public string CNPJ { get; set; }

        public string chNFe { get; set; }

        public DateTime dhEvento { get; set; }

        public uint tpEvento { get; set; }

        public byte nSeqEvento { get; set; }

        public decimal verEvento { get; set; }

        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public detEvento detEvento { get; set; }

        [XmlAttribute] public string Id { get; set; }

        #endregion
    }
}