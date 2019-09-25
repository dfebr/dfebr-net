// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:04/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Recepcao.Retorno
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class consReciNFe
    {
        #region Propriedades

        /// <summary>
        ///     BP02 - Versão do leiaute
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     BP03 - Identificação do Ambiente: 1 – Produção / 2 – Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     BP04 - Número do Recibo Número gerado pelo Portal da Secretaria de Fazenda Estadual (vide item 5.5).
        /// </summary>
        public string nRec { get; set; }

        #endregion
    }
}