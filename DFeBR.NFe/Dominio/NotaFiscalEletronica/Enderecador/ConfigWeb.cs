// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:10/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Enderecador
{
    [DataContract(Name = "nfehomo")]
    public class UrlHomNFe
    {
        #region Propriedades

        /// <summary>
        ///     Endereço url do serviços de Recepção de Evento
        /// </summary>
        [JsonProperty("recebeEvento")]
        public string RecebeEvento { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public string Inutiliza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public string ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço url de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public string StatusServico { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public string Autoriza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public string ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Cancelamento
        /// </summary>
        [JsonProperty("cancelar")]
        public string Cancelar { get; set; }

        #endregion
    }

    [DataContract(Name = "nfeprod")]
    public class UrlProdNFe
    {
        #region Propriedades

        /// <summary>
        ///     Endereço url do serviços de Recepção de Evento
        /// </summary>
        [JsonProperty("recebeEvento")]
        public string RecebeEvento { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public string Inutiliza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public string ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço url de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public string StatusServico { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public string Autoriza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public string ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Cancelamento
        /// </summary>
        [JsonProperty("cancelar")]
        public string Cancelar { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Contigência Virtual Nacional
        /// </summary>
        [JsonProperty("contingenciaSvcan")]
        public string ContingenciaSvcan { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Contigência Virtual do Rio Grande do Sul
        /// </summary>
        [JsonProperty("contingenciaSvcrs")]
        public string ContingenciaSvcrs { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Contigência de Declaração Prévia de Contigência
        /// </summary>
        [JsonProperty("contingenciaDpec")]
        public string ContingenciaDpec { get; set; }

        #endregion
    }

    [DataContract(Name = "nfcehomo")]
    public class UrlHomoNFce
    {
        #region Propriedades

        /// <summary>
        ///     Endereço url do serviços de Recepção de Evento
        /// </summary>
        [JsonProperty("recebeEvento")]
        public string RecebeEvento { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public string Inutiliza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public string ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço url de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public string StatusServico { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public string Autoriza { get; set; }

        /// <summary>
        ///     Endereço url de consulta do QRCode
        /// </summary>
        [JsonProperty("qrcodeConsulta")]
        public string QrcodeConsulta { get; set; }

        /// <summary>
        ///     Endereço url de Chave do QRCode
        /// </summary>
        [JsonProperty("qrcodeChave")]
        public string QrcodeChave { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public string ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Cancelamento
        /// </summary>
        [JsonProperty("cancelar")]
        public string Cancelar { get; set; }

        #endregion
    }

    [DataContract(Name = "nfceprod")]
    public class UrlProdNFce
    {
        #region Propriedades

        /// <summary>
        ///     Endereço url do serviços de Recepção de Evento
        /// </summary>
        [JsonProperty("recebeEvento")]
        public string RecebeEvento { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public string Inutiliza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public string ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço url de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public string StatusServico { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public string Autoriza { get; set; }

        /// <summary>
        ///     Endereço url de consulta do QRCode
        /// </summary>
        [JsonProperty("qrcodeConsulta")]
        public string QrcodeConsulta { get; set; }

        /// <summary>
        ///     Endereço url de Chave do QRCode
        /// </summary>
        [JsonProperty("qrcodeChave")]
        public string QrcodeChave { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public string ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Cancelamento
        /// </summary>
        [JsonProperty("cancelar")]
        public string Cancelar { get; set; }

        #endregion
    }

    [DataContract(Name = "nfce")]
    public class UrlNFce
    {
        #region Propriedades

        [JsonProperty("nfcehomo")] public UrlHomoNFce Homologacao { get; set; }

        [JsonProperty("nfceprod")] public UrlProdNFce Producao { get; set; }

        #endregion
    }

    [DataContract(Name = "nfe")]
    public class UrlNFe
    {
        #region Propriedades

        /// <summary>
        ///     Endereços NFe de Homologação
        /// </summary>
        [JsonProperty("nfehomo")]
        public UrlHomNFe Homologacao { get; set; }

        /// <summary>
        ///     Endereços NFe de Produção
        /// </summary>
        [JsonProperty("nfeprod")]
        public UrlProdNFe Producao { get; set; }

        #endregion
    }

    [DataContract(Name = "wsdl")]
    public class UrlWsdl
    {
        #region Propriedades

        /// <summary>
        ///     Endereço url de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public string StatusServico { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public string Autoriza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public string ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public string Inutiliza { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public string ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço url do serviços de Cancelamento
        /// </summary>
        [JsonProperty("cancelar")]
        public string Cancelar { get; set; }

        #endregion
    }

    [DataContract(Name = "schema")]
    public class Schema
    {
        #region Propriedades

        /// <summary>
        ///     Endereço schema de consulta ao status do serviço
        /// </summary>
        [JsonProperty("statusServico")]
        public List<string> StatusServico { get; set; }

        /// <summary>
        ///     Endereço schema do serviços de Autorização
        /// </summary>
        [JsonProperty("autoriza")]
        public List<string> Autoriza { get; set; }

        /// <summary>
        ///     Endereço schema do serviços de Consulta Protocolo
        /// </summary>
        [JsonProperty("consultaProtocolo")]
        public List<string> ConsultaProtocolo { get; set; }

        /// <summary>
        ///     Endereço WSDL do serviços de Inutilização
        /// </summary>
        [JsonProperty("inutiliza")]
        public List<string> Inutiliza { get; set; }

        /// <summary>
        ///     Endereço WSDL do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("consultaRecibo")]
        public List<string> ConsultaRecibo { get; set; }

        /// <summary>
        ///     Endereço WSDL do serviços de Consulta Recibo
        /// </summary>
        [JsonProperty("cancelar")]
        public List<string> Cancelar { get; set; }

        #endregion
    }

    public class ConfigServ
    {
        #region Propriedades

        [JsonProperty("nfe")] public UrlNFe UrlsNFe { get; set; }

        [JsonProperty("nfce")] public UrlNFce UrlsNFce { get; set; }

        [JsonProperty("wsdl")] public UrlWsdl UrlsWsdl { get; set; }

        [JsonProperty("schema")] public Schema Schemas { get; set; }

        #endregion
    }
}