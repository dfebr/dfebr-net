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
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class infProt
    {
        #region Propriedades

        public byte tpAmb { get; set; }

        public decimal verAplic { get; set; }

        [XmlElement(DataType = "integer")] public string chNFe { get; set; }

        public DateTime dhRecbto { get; set; }

        public ulong nProt { get; set; }

        public string digVal { get; set; }

        public byte cStat { get; set; }

        public string xMotivo { get; set; }

        [XmlAttribute] public string Id { get; set; }

        #endregion
    }
}