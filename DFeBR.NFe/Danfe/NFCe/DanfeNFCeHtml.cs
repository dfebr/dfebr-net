// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DFeBR.EmissorNFe.Danfe.Entidades;
using DFeBR.EmissorNFe.Danfe.Interfaces;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using QRCoder;

#endregion

namespace DFeBR.EmissorNFe.Danfe.NFCe
{
    public class DanfeNFCeHtml : IDanfeHtml
    {
        #region Propriedades

        /// <summary>
        ///     Tipo da DANFE
        /// </summary>
        public string TipoDanfe => "NFCe";

        /// <summary>
        ///     tipo do papel usado
        /// </summary>
        public TipoPapelNFCe TipoPapel { get; }

        /// <summary>
        ///     Cabeçalho do documento
        /// </summary>
        public CabecalhoNFCe Cabecalho { get; }

        /// <summary>
        ///     Corpo do documento
        /// </summary>
        public CorpoNFCe Corpo { get; }

        /// <summary>
        ///     Rodapé do documento
        /// </summary>
        public RodapeNFCe Rodape { get; }

        /// <summary>
        ///     True, Html possue script JS
        /// </summary>
        public bool TemScript => false;

        #endregion

        #region Construtor

        public DanfeNFCeHtml(TipoPapelNFCe tipoPapel, CabecalhoNFCe cabecalho, CorpoNFCe corpo, RodapeNFCe rodape)

        {
            TipoPapel = tipoPapel;
            Cabecalho = cabecalho;
            Corpo = corpo;
            Rodape = rodape;
        }

        #endregion

        /// <summary>
        ///     Montar página principal
        /// </summary>
        /// <param name="header"></param>
        /// <param name="body"></param>
        /// <param name="footer"></param>
        /// <returns></returns>
        private string MontagemPagina(string header, string body, string footer)
        {
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Structure,
                    new Dictionary<string, string>
                    {
                            {
                                    "#cssBody#",
                                    TipoPapel == TipoPapelNFCe.Mm80
                                            ? "width: 355px; padding: 0px 15px; font-size: 0.7em; height:auto;"
                                            : "width: 265px; font-size: 0.7em;"
                            },
                            {"#Header#", header},
                            {"#Body#", body},
                            {"#Footer#", footer}
                    });
        }

        /// <summary>
        /// Substituir chave pelo valor
        /// </summary>
        /// <param name="html"></param>
        /// <param name="replacesList"></param>
        /// <returns></returns>
        private string Substituir(string html, Dictionary<string, string> replacesList)
        {
            foreach (KeyValuePair<string, string> replaces in replacesList)
                html = Regex.Replace(html, replaces.Key, replaces.Value ?? string.Empty, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 5));
            return html;
        }

        /// <summary>
        ///     Realizar a leitura de arquivo e substitui tags
        /// </summary>
        /// <param name="printing"></param>
        /// <param name="dictionaryReplace"></param>
        /// <returns></returns>
        private string LerTemplateEsubstituirTags(TemplateDanfeNFCe printing, Dictionary<string, string> dictionaryReplace)
        {
            if (dictionaryReplace == null) return string.Empty;
            return !dictionaryReplace.Any() ? string.Empty : Substituir(LerTemplate(printing), dictionaryReplace);
        }

        /// <summary>
        ///     Ler template HTML
        /// </summary>
        /// <param name="templatePath"></param>
        /// <returns></returns>
        private string LerTemplate(TemplateDanfeNFCe templatePath)
        {
            var caminho = $@"{Environment.CurrentDirectory}\Danfe\TemplateHtml\NFCe\{templatePath}.html";
            try
            {
                using (StreamReader streamReader = new StreamReader(caminho))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Não foi possível processar ou encontrar o arquivo {templatePath}.html");
            }
        }

        #region Implementacoes

        /// <summary>
        ///     Obter Danfe
        /// </summary>
        /// <returns></returns>
        public Documento ObterDocHtml()
        {
            var cabecalho = MontarCabecalho(Cabecalho);
            var corpo = MontarCorpo(Corpo);
            var rodape = MontarRodape(Rodape, Corpo);
            //===============================
            string str1 = MontagemPagina(cabecalho, corpo, rodape);
            string str2 = TemScript ? LerTemplate(TemplateDanfeNFCe.Script) : null;
            return new Documento {Html = str1, Script = str2, ReplaceJsTags = new List<ReplaceJsTags>()};
        }

        #endregion

        #region Montagens partes do documento
        /// <summary>
        ///     Montar Rodape
        /// </summary>
        /// <param name="rodape"></param>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarRodape(RodapeNFCe rodape, CorpoNFCe corpo)
        {
            string str1;
            var str2 = "";
            switch (corpo.Status)
            {
                case Status.Autorizada:
                    str1 = "";
                    break;
                case Status.Cancelada:
                    str1 = "NOTA FISCAL CANCELADA";
                    break;
                case Status.NaoAuotorizada:
                    str1 = "NOTA FISCAL DENEGADA";
                    break;
                case Status.EsperandoAutorizacao:
                    str1 = "PRÉ-VISUALIZAÇÃO";
                    str2 = "SEM VALOR FISCAL";
                    break;
                case Status.Negada:
                    str1 = "NOTA FISCAL DENEGADA";
                    break;
                case Status.Recusada:
                    str1 = "SEM VALOR FISCAL";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!corpo.Producao)
            {
                str1 = "HOMOLOGAÇÃO";
                str2 = "SEM VALOR FISCAL";
            }

            var list = new Dictionary<string, string>();
            var msg = corpo.Status == Status.Autorizada
                    ? ""
                    : "<div class=\\\"content100 bold\\\" style=\\\"float: none; margin: auto; text - align: center; margin - top: 10px; \\\">EMITIDA EM CONTINGÊNCIA<br/>Pendente de Autorização</div>";
            list.Add("#ContingencyMessage#", msg);
            var qrCode = MontarQrCode(rodape);
            list.Add("#QrCode#", qrCode);
            list.Add("#Protocol#", rodape.NumProt);
            list.Add("#Date#", corpo.DataEmissao.ToString("dd/MM/yyyy hh:mm:ss"));
            list.Add("#WaterMark#", str1);
            list.Add("#WithOutValue#", str2);
            list.Add("#Credit#", rodape.Creditos);
            
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Footer, list);
        }

        /// <summary>
        ///     Montar QrCode
        /// </summary>
        /// <returns></returns>
        private string MontarQrCode(RodapeNFCe rodape, int pixelsPerModule = 25)
        {
            try
            {
                using (var qrCodeGenerator = new QRCodeGenerator())
                {
                    return "data:image/png;base64, " +
                           new Base64QRCode(qrCodeGenerator.CreateQrCode(rodape.StrQrCode, QRCodeGenerator.ECCLevel.M))
                                   .GetGraphic(pixelsPerModule);
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
        private string MontarCabecalho(CabecalhoNFCe cabecalho)
        {
            var list = new Dictionary<string, string>();
            var ender = $"{cabecalho.Endereco},{cabecalho.Numero} - {cabecalho.Cidade}," + $" {Cabecalho.Estado} CEP: {cabecalho.Cep}";
            list.Add("#cssDadosEmissor#",
                    TipoPapel == TipoPapelNFCe.Mm80
                            ? "width: 78%; height:80px; float: left;"
                            : "width: 100%; height:80px; float: left; font-align: center;");
            list.Add("#CompanyName#", cabecalho.NomeFantasia ?? string.Empty);
            list.Add("#CNPJ#", Utils.FormatarCnpj(cabecalho.Cnpj));
            list.Add("#IE#", cabecalho.Ie);
            list.Add("#Address#", ender);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Header, list);
        }

        private string MontarCorpo(CorpoNFCe corpo)
        {
            var list = new Dictionary<string, string>();
            list.Add("#EmissionType#",
                    corpo.EmitidaEmContigencia ? "EMITIDA EM CONTINGÊNCIA<br/>Pendente de Autorização" : "EMISSÃO NORMAL");
            var produtos = MontarProdutos(Corpo.Produtos, corpo);
            list.Add("#Products#", produtos);
            var pagamento = MontarPagamentos(corpo);
            list.Add("#TotalsProducts#", pagamento);
            var impostos = MontarImpostos(corpo);
            list.Add("#Taxes#", impostos);
            var infAdd = MontarInfAdicionais(corpo);
            list.Add("#AdditionalInformations#", infAdd);
            var data = MontarDadosDocumento(corpo);
            list.Add("#Data#", data);
            var destinatario = MontarDestinatario(corpo);
            list.Add("#Recipient#", destinatario);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Body, list);
        }

        /// <summary>
        ///     Montar dados do destinatário
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarDestinatario(CorpoNFCe corpo)
        {
            var list = new Dictionary<string, string>();
            var nome = string.IsNullOrWhiteSpace(corpo.Destinatario.NomeConsumidor)
                    ? "CONSUMIDOR NÃO IDENTIFICADO"
                    : corpo.Destinatario.NomeConsumidor?.ToUpper();
            list.Add("#Recipient#", nome);

            var doc = string.IsNullOrWhiteSpace(corpo.Destinatario.Doc)?"":$"<span>CNPJ/CPF - {corpo.Destinatario.Doc}</span>";
            list.Add("#Data#", doc);
            list.Add("#Address#", corpo.Destinatario.Endereco);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Recipient, list);
        }

        /// <summary>
        ///     Montar dados do documento NFCe
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarDadosDocumento(CorpoNFCe corpo)
        {
            var list = new Dictionary<string, string>();
            list.Add("#DocumentNumber#", corpo.NumeroDocumento);
            list.Add("#Serie#", corpo.Serie);
            list.Add("#Emission#", corpo.DataEmissao.ToString("dd/MM/yyyy hh:mm:ss"));
            list.Add("#URL#", corpo.UrlConsulta);
            list.Add("#NFeID#", corpo.Chave);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Data, list);
        }

        /// <summary>
        ///     Montar informações adicionais
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarInfAdicionais(CorpoNFCe corpo)
        {
            var list = new Dictionary<string, string>();
            var str = Regex
                    .Replace(
                            Regex.Replace(corpo.InfAdicionais.Descricao.Replace("\r\n", string.Empty), "Trib aprox: (.*?) IBPT",
                                    string.Empty), "Val Aprox Tributos: (.*?) IBPT", string.Empty).Replace("|", "<br/>");
            list.Add("#Informations#", str);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.AdditionalInformation, list);
        }

        /// <summary>
        ///     Montar impostos
        /// </summary>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarImpostos(CorpoNFCe corpo)
        {
            var list = new List<string>();
            list.Add($"{corpo.Imposto.ValorImpFederal:N2} Federal");
            list.Add($"{corpo.Imposto.ValorImpEstadual:N2} Estadual");
            list.Add($"{corpo.Imposto.ValorImpMunicipal:N2} Municipal");
            var str = string.Join(", ", list);
            var list2 = new Dictionary<string, string>();
            list2.Add("#Taxes#", str);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Taxes, list2);
        }

        private string MontarPagamentos(CorpoNFCe corpo)
        {
            var list = new Dictionary<string, string>();
            list.Add("#Quantity#", corpo.Produtos.Count.ToString());
            list.Add("#TotalValue#", corpo.Pagamento.ValorTotal.FormatarNumeroDanfe());
            list.Add("#TotalDiscount#", corpo.Pagamento.ValorTotDesconto.FormatarNumeroDanfe());
            list.Add("#TotalDue#", corpo.Pagamento.ValorTotDevido.FormatarNumeroDanfe());
            list.Add("#ValorTroco#", corpo.Pagamento.Troco.FormatarNumeroDanfe());
            list.Add("#StyleTroco#", "style=\"display: none;\"");
            var formasPag = MontarFormasPagamento(corpo.Pagamento.FormasPagamentos);
            list.Add("#Payments#", formasPag);
            return LerTemplateEsubstituirTags(TemplateDanfeNFCe.Total, list);
        }

        /// <summary>
        ///     Montar formas de pagmento
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        private string MontarFormasPagamento(ICollection<FormPagNFCe> entidade)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in entidade)
            {
                var dic = new Dictionary<string, string> {{"#Description#", item.Forma}, {"#Value#", item.Valor.FormatarNumeroDanfe()}};
                stringBuilder.Append(LerTemplateEsubstituirTags(TemplateDanfeNFCe.Payments, dic));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Montar pagamentos
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="corpo"></param>
        /// <returns></returns>
        private string MontarProdutos(ICollection<ProdutoNFCe> entidade, CorpoNFCe corpo)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in entidade)
            {
                var dic = new Dictionary<string, string>
                {
                        {"#Code#", item.Codigo},
                        {
                                "#Description#",
                                corpo.Producao
                                        ? item.Descricao?.Trim()
                                        : "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                        },
                        {"#Unit#", item.Unidade?.ToUpper()},
                        {"#Quantity#", item.Quantidade.FormatarNumeroDanfe()},
                        {"#UnityValue#", item.ValorUnitario.FormatarNumeroDanfe()},
                        {"#Amount#", item.ValorTotal.FormatarNumeroDanfe()}
                };
                stringBuilder.Append(LerTemplateEsubstituirTags(TemplateDanfeNFCe.Products, dic));
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}