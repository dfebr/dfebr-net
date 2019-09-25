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
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal
{
    public class IPI
    {
        #region Propriedades

        /// <summary>
        ///     O02 - Classe de enquadramento do IPI para Cigarros e Bebidas
        ///     Versão 3.10
        /// </summary>
        public string clEnq { get; set; }

        /// <summary>
        ///     O03 - CNPJ do produtor da mercadoria, quando diferente do emitente. Somente para os casos de exportação direta ou
        ///     indireta.
        /// </summary>
        public string CNPJProd { get; set; }

        /// <summary>
        ///     O04 - Código do selo de controle IPI
        /// </summary>
        public string cSelo { get; set; }

        /// <summary>
        ///     O05 - Quantidade de selo de controle
        /// </summary>
        public int? qSelo { get; set; }

        /// <summary>
        ///     O06 - Código de Enquadramento Legal do IPI
        /// </summary>
        public int cEnq { get; set; }

        /// <summary>
        ///     O07 (IPITrib) - Grupo do CST 00, 49, 50 e 99
        ///     O08 (IPINT) - Grupo CST 01, 02, 03, 04, 51, 52, 53, 54 e 55
        /// </summary>
        [XmlElement("IPITrib", typeof(IPITrib))]
        [XmlElement("IPINT", typeof(IPINT))]
        public IPIBasico TipoIPI { get; set; }

        #endregion

        public bool ShouldSerializeqSelo()
        {
            return qSelo.HasValue;
        }
    }
}