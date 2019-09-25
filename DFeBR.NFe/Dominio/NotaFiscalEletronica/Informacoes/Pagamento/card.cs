// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Pagamento
{
    public class card
    {
        #region Propriedades

        /// <summary>
        ///     YA04a - Tipo de Integração para pagamento
        /// </summary>
        public TipoIntegracaoPagamento? tpIntegra { get; set; }

        /// <summary>
        ///     YA05 - CNPJ da Credenciadora de cartão de crédito e/ou débito
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     YA06 - Bandeira da operadora de cartão de crédito e/ou débito
        /// </summary>
        public BandeiraCartao? tBand { get; set; }

        /// <summary>
        ///     YA07 - Número de autorização da operação cartão de crédito e/ou débito
        /// </summary>
        public string cAut { get; set; }

        #endregion

        public bool ShouldSerializetpIntegra()
        {
            return tpIntegra.HasValue;
        }

        public bool ShouldSerializetBand()
        {
            return tBand.HasValue;
        }
    }
}