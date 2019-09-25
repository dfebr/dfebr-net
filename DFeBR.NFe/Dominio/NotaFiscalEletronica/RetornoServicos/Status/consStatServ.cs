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
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Status
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class consStatServ
    {
        #region Propriedades

        /// <summary>
        ///     FP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     FP03 - Identificação do Ambiente: 1 – Produção / 2 - Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     FP04 - Código da UF consultada
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     Serviço solicitado 'STATUS'
        /// </summary>
        public string xServ { get; set; }

        #endregion

        #region Construtor

        public consStatServ()
        {
            xServ = "STATUS";
        }

        #endregion
    }
}