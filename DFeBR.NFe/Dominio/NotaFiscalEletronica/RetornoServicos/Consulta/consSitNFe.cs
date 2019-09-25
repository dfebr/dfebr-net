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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Consulta
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class consSitNFe
    {
        #region Propriedades

        /// <summary>
        ///     EP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     EP03 - Identificação do Ambiente: 1 – Produção / 2 - Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     Serviço solicitado "CONSULTAR"
        /// </summary>
        public string xServ { get; set; }

        /// <summary>
        ///     EP05 - Chave de Acesso da NF-e.
        /// </summary>
        public string chNFe { get; set; }

        #endregion

        #region Construtor

        public consSitNFe()
        {
            xServ = "CONSULTAR";
        }

        #endregion
    }
}