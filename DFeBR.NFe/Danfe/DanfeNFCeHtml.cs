// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores:
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:27/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DFeBR.EmissorNFe.Danfe.Entidades;
using DFeBR.EmissorNFe.Danfe.Interfaces;
using DFeBR.EmissorNFe.Properties;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using QRCoder;

#endregion

namespace DFeBR.EmissorNFe.Danfe
{
    public class DanfeNFCeHtml : IDanfeHtml
    {

        #region Propriedades

        /// <summary>
        ///     Tipo da DANFE
        /// </summary>
        public string TipoDanfe => "NFe";
 

        #endregion

        #region Construtor

        public DanfeNFCeHtml(DanfeNFCe danfeNfCe, TipoPapelNFCe tipoPapel)
        {
            _danfeNfCe = danfeNfCe;
            _tipoPapel = tipoPapel;
        }

        #endregion

        private readonly DanfeNFCe _danfeNfCe;
        private readonly TipoPapelNFCe _tipoPapel;

        /// <summary>
        ///     Montar página principal
        /// </summary>
        /// <param name="header"></param>
        /// <param name="body"></param>
        /// <param name="footer"></param>
        /// <returns></returns>
        private string MontagemPagina(string header, string body, string footer)
        {
            return Substituir(Resources.Structure_Mod65,
                    new Dictionary<string, string>
                    {
                            {
                                    "#cssBody#",
                                    _tipoPapel == TipoPapelNFCe.Mm80
                                            ? "width: 355px; padding: 0px 15px; font-size: 0.7em; height:auto;"
                                            : "width: 265px; font-size: 0.7em;"
                            },
                            {"#Header#", header},
                            {"#Body#", body},
                            {"#Footer#", footer}
                    });
        }

        /// <summary>
        ///     Substituir chave pelo valor
        /// </summary>
        /// <param name="html"></param>
        /// <param name="replacesList"></param>
        /// <returns></returns>
        private string Substituir(string html, Dictionary<string, string> replacesList)
        {
            foreach (var replaces in replacesList)
                html = Regex.Replace(html, replaces.Key, replaces.Value ?? string.Empty, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 5));
            return html;
        }

        /// <summary>
        ///     Realizar a leitura de arquivo e substitui tags
        /// </summary>
        /// <param name="nomeTemplate"></param>
        /// <param name="dictionaryReplace"></param>
        /// <returns></returns>
        private string LerTemplateEsubstituirTags(string nomeTemplate, Dictionary<string, string> dictionaryReplace)
        {
            if (dictionaryReplace == null) return string.Empty;
            return !dictionaryReplace.Any() ? string.Empty : Substituir(nomeTemplate, dictionaryReplace);
        }

        #region Implementacoes

        /// <summary>
        ///     Obter Danfe
        /// </summary>
        /// <returns></returns>
        public Documento ObterDocHtml()
        {
            var cabecalho = MontarCabecalho(_danfeNfCe);
            var corpo = MontarCorpo(_danfeNfCe);
            var rodape = MontarRodape(_danfeNfCe);
            //===============================
            var str1 = MontagemPagina(cabecalho, corpo, rodape);
            return new Documento { Html = str1 };
        }

        #endregion


        #region Montagens partes do documento

        /// <summary>
        ///     Montar Rodape
        /// </summary>
        /// <param name="rodape"></param>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarRodape(DanfeNFCe entidade)
        {
            var msg = "";

            switch (entidade.Status)
            {
                case Status.Contingencia:
                    msg = "EMITIDA EM CONTINGÊNCIA<br/>Pendente de Autorização";
                    break;
                case Status.Cancelada:
                    msg = "CANCELADA";
                    break;
                case Status.NaoAuotorizada:
                    msg = "NÃO AUTORIZADA";
                    break;
                case Status.EsperandoAutorizacao:
                    msg = "PRÉ-VISUALIZAÇÃO";
                    break;
                case Status.Negada:
                    msg = "DENEGADA";
                    break;
                case Status.Recusada:
                    msg = "RECUSADA";
                    break;
            }

            var dic = new Dictionary<string, string>();
            var qrCode = MontarQrCode(entidade);
            dic.Add("#QrCode#", qrCode);

            var dadosProtocolo = "";
            if (!string.IsNullOrWhiteSpace(entidade.NumProt))
            {
                dadosProtocolo = $"Protocolo de Autorização: {entidade.NumProt} {entidade.DataEmissao:dd/MM/yyyy hh:mm:ss}";
            }
            dic.Add("#Protocolo#", dadosProtocolo);
            dic.Add("#ContingencyMessage#", msg);
            dic.Add("#Credit#", entidade.Creditos);
            return LerTemplateEsubstituirTags(Resources.Footer_Mod65, dic);
        }

        /// <summary>
        ///     Montar QrCode
        /// </summary>
        /// <returns></returns>
        private string MontarQrCode(DanfeNFCe entidade, int pixelsPerModule = 25)
        {
            try
            {
                using (var qrCodeGenerator = new QRCodeGenerator())
                {
                    return "data:image/png;base64, " +
                           new Base64QRCode(qrCodeGenerator.CreateQrCode(entidade.StrQrCode, QRCodeGenerator.ECCLevel.M)).GetGraphic(
                                   pixelsPerModule);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Não foi possível gerar o QrCode\nRazão:{ex.Message}");
            }
        }


        /// <summary>
        ///     Montar cabeçalho da DANFE
        /// </summary>
        /// <param name="cabecalho"></param>
        /// <returns></returns>
        private string MontarCabecalho(DanfeNFCe entidade)
        {
            var list = new Dictionary<string, string>();
            var endereco = entidade.Emitente.Endereco;
            var emitente = entidade.Emitente;
            var ender = $"{endereco.NomeEnd},{endereco.Num} - {endereco.Cidade}," + $" {endereco.Estado} CEP: {endereco.Cep}";
            list.Add("#cssDadosEmissor#",
                    _tipoPapel == TipoPapelNFCe.Mm80
                            ? "width: 100%; height:80px; float: left;"
                            : "width: 80%; height:80px; float: left; font-align: center;");
            list.Add("#CompanyName#", emitente.Nome ?? string.Empty);
            list.Add("#CNPJ#", Utils.FormatarCnpj(emitente.CnpjCpf));
            list.Add("#IE#", emitente.Ie);
            list.Add("#Address#", ender);
            return LerTemplateEsubstituirTags(Resources.Header_Mod65, list);
        }

        private string MontarCorpo(DanfeNFCe entidade)
        {
            var list = new Dictionary<string, string>();
            list.Add("#EmissionType#",
                    entidade.EmitidaEmContigencia ? "EMITIDA EM CONTINGÊNCIA<br/>Pendente de Autorização" : "EMISSÃO NORMAL");
            var produtos = MontarProdutos(entidade);
            list.Add("#Products#", produtos);
            var pagamento = MontarPagamentos(entidade);
            list.Add("#TotalsProducts#", pagamento);
            var impostos = MontarImpostos(entidade);
            list.Add("#Taxes#", impostos);
            var infAdd = MontarInfAdicionais(entidade);
            list.Add("#AdditionalInformations#", infAdd);
            var data = MontarDadosDocumento(entidade);
            list.Add("#Data#", data);
            var destinatario = MontarDestinatario(entidade);
            list.Add("#Recipient#", destinatario);
            return LerTemplateEsubstituirTags(Resources.Body_Mod65, list);
        }

        /// <summary>
        ///     Montar dados do destinatário
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarDestinatario(DanfeNFCe entidade)
        {

            var list = new Dictionary<string, string>();
            if (entidade.Destinatario == null)
            {
                list.Add("#Recipient#", "CONSUMIDOR NÃO IDENTIFICADO");
                list.Add("#Data#", "");
                list.Add("#Address#", "");
                return LerTemplateEsubstituirTags(Resources.Recipient_Mod65, list);
            }

            var destinatario = entidade.Destinatario;
            list.Add("#Recipient#", destinatario.Nome?.ToUpper());
            var doc = string.IsNullOrWhiteSpace(destinatario.CnpjCpf) ? "" : $"<span>CNPJ/CPF - {destinatario.CnpjCpf}</span>";
            list.Add("#Data#", doc);

            var endereco = "";
            if (destinatario.Endereco != null)
            {
                endereco = $"{destinatario.Endereco.NomeEnd} {destinatario.Endereco.Cidade}";
            }
            list.Add("#Address#", endereco);

            return LerTemplateEsubstituirTags(Resources.Recipient_Mod65, list);

        }

        /// <summary>
        ///     Montar dados do documento NFCe
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarDadosDocumento(DanfeNFCe entidade)
        {
            var str1 = "";
            if (!entidade.Producao)
                str1 = "EMITIDA EM AMBIENTE DE HOMOLOGAÇÃO - SEM VALOR FISCAL";


            var list = new Dictionary<string, string>();

            list.Add("#WithOutValue#", $"{str1}");
            list.Add("#DocumentNumber#", entidade.NumeroDocumento);
            list.Add("#Serie#", entidade.Serie);
            list.Add("#Emission#", entidade.DataEmissao.ToString("dd/MM/yyyy hh:mm:ss"));
            list.Add("#URL#", entidade.UrlConsulta);
            list.Add("#NFeID#", entidade.Chave);
            return LerTemplateEsubstituirTags(Resources.Data_Mod65, list);
        }

        /// <summary>
        ///     Montar informações adicionais
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarInfAdicionais(DanfeNFCe entidade)
        {
            if (entidade.InfAdicionais == null) return "";

            var list = new Dictionary<string, string>();
            var str = Regex
                    .Replace(Regex.Replace(entidade.InfAdicionais.Replace("\r\n", string.Empty), "Trib aprox: (.*?) IBPT", string.Empty),
                            "Val Aprox Tributos: (.*?) IBPT", string.Empty).Replace("|", "<br/>");
            list.Add("#Informations#", str);
            return LerTemplateEsubstituirTags(Resources.AdditionalInformation_Mod65, list);
        }

        /// <summary>
        ///     Montar impostos
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarImpostos(DanfeNFCe entidade)
        {
            var list2 = new Dictionary<string, string>();
            list2.Add("#Taxes#", entidade.DadosTributos);
            return LerTemplateEsubstituirTags(Resources.Taxes_Mod65, list2);
        }

        private string MontarPagamentos(DanfeNFCe entidade)
        {
            var list = new Dictionary<string, string>();
            list.Add("#Quantity#", entidade.Produtos.Count.ToString());
            list.Add("#TotalValue#", entidade.Pagamento.ValorTotal.FormatarNumeroDanfe());
            list.Add("#TotalDiscount#", entidade.Pagamento.ValorTotDesconto.FormatarNumeroDanfe());
            list.Add("#TotalDue#", entidade.Pagamento.ValorTotDevido.FormatarNumeroDanfe());
            list.Add("#ValorTroco#", entidade.Pagamento.Troco == null ? string.Empty : entidade.Pagamento.Troco.Value.FormatarNumeroDanfe());

            if (entidade.Pagamento.Troco == null)
                list.Add("#StyleTroco#", "style=\"display: none;\"");

            var formasPag = MontarFormasPagamento(entidade.Pagamento.FormasPagamentos);
            list.Add("#Payments#", formasPag);
            return LerTemplateEsubstituirTags(Resources.Total_Mod65, list);
        }

        /// <summary>
        ///     Montar formas de pagmento
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        private string MontarFormasPagamento(ICollection<FormPag> entidade)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in entidade)
            {
                var dic = new Dictionary<string, string> { { "#Description#", item.Forma }, { "#Value#", item.Valor.FormatarNumeroDanfe() } };
                stringBuilder.Append(LerTemplateEsubstituirTags(Resources.Payments_Mod65, dic));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Montar pagamentos
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarProdutos(DanfeNFCe entidade)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in entidade.Produtos)
            {
                var dic = new Dictionary<string, string>
                {
                        {"#Code#", item.Codigo},
                        {
                                "#Description#",
                                entidade.Producao
                                        ? item.Descricao?.Trim()
                                        : "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                        },
                        {"#Unit#", item.Unidade?.ToUpper()},
                        {"#Quantity#", item.Quantidade.ToString("N3")}, // FormatarNumeroQuantidadeDanfe()},
                        {"#UnityValue#", item.ValorUnitario.ToString("C")}, //FormatarNumeroDanfe()},
                        {"#Amount#", item.ValorTotal.ToString("C")} //.FormatarNumeroDanfe()}
                };
                stringBuilder.Append(LerTemplateEsubstituirTags(Resources.Products_Mod65, dic));
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}