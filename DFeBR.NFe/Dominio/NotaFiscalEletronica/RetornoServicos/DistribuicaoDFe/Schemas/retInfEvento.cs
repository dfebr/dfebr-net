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
    public class retInfEvento
    {
        #region Propriedades

        public byte tpAmb { get; set; }

        public string verAplic { get; set; }

        public byte cOrgao { get; set; }

        public byte cStat { get; set; }

        public string xMotivo { get; set; }

        public string chNFe { get; set; }

        public uint tpEvento { get; set; }

        public string xEvento { get; set; }

        public byte nSeqEvento { get; set; }

        public string CNPJDest { get; set; }

        public string emailDest { get; set; }

        public DateTime dhRegEvento { get; set; }

        public string nProt { get; set; }

        #endregion
    }
}