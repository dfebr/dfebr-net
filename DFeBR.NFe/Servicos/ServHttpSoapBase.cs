// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:25/04/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Servicos.Interfaces;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Exceptions;

#endregion

namespace DFeBR.EmissorNFe.Servicos
{
    /// <summary>
    ///     Disponibiliza uma Base para chamada aos serviços Web Soap
    /// </summary>
    internal class ServHttpSoapBase : IServHttpSoapBase
    {
        private string _urlServ;

        #region Construtor

        /// <summary>
        /// </summary>
        /// <param name="emissorServicoConfig">Configuração do emissor</param>
        /// <param name="certificado">Certificado Digital</param>
        /// <param name="nomeServivo">Nome do serviço</param>
        public ServHttpSoapBase(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, string nomeServivo)
        {
            _emissorServicoConfig = emissorServicoConfig ?? throw new ArgumentNullException(nameof(emissorServicoConfig));
            _certificado = certificado ?? throw new ArgumentNullException(nameof(certificado));
            _nomeServico = nomeServivo;
        }

        #endregion

        private readonly string _nomeServico;

        private readonly EmissorServicoConfig _emissorServicoConfig;
        private readonly X509Certificate2 _certificado;
        
        /// <summary>
        ///     Obter instancia do serviço web
        /// </summary>
        /// <param name="url">Endereco Url do serviço</param>
        /// <param name="soapXml">Mensagem body padrão SOAP e especificação SEFAZ</param>
        /// <returns></returns>
        public HttpWebRequest ObterRequisicaoSoap(string url, string soapXml)
        {
            
            try
            {
                _urlServ = url;
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(_urlServ);
                httpWebRequest.Host = httpWebRequest.RequestUri.Host;
                httpWebRequest.ContentType = "application/soap+xml; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Timeout = _emissorServicoConfig.TimeOut;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                httpWebRequest.ContentLength = Encoding.UTF8.GetByteCount(soapXml);
                var servico = ObterServicoAlvo(_urlServ); //Obter nome do serviço
                httpWebRequest.Headers.Add("SOAPAction", $"/{servico}");

                foreach (var clientCertificate in httpWebRequest.ClientCertificates)
                    httpWebRequest.ClientCertificates.Remove(clientCertificate);
                //Adicionar certificado digital
                httpWebRequest.ClientCertificates.Add(_certificado);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(soapXml);
                    streamWriter.Flush();
                }

                return httpWebRequest;
            }
            catch (Exception ex)
            {
                var msg = $"Ocorreu uma falha ao executar o serviço [{_nomeServico}]";
                Utils.TraceException(ex, msg); 
                throw new FalhaCriacaoServicoWebException(msg,ex);
            }
        }

        /// <summary>
        ///     Determina o alvo da requisição
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string ObterServicoAlvo(string url)
        {
            var reg1 = "[^/]+(?=(?:\\.[^.]+)?$)";
            var regex = new Regex(reg1);
            var nomeComExtensao = regex.Match(url);
            var t1 = "([^\\.]*)";
            var regex2 = new Regex(t1);
            var nome = regex2.Match(nomeComExtensao.Value);
            return nome.Value;
        }

        /// <summary>
        ///     Obtem resposta do serviço
        ///     <para>Um arquivo Xml com o nó [nfeResultMsg] é retornado</para>
        /// </summary>
        /// <param name="webRequest"></param>
        /// <returns></returns>
        public async Task<string> ObterRespostaAsync(HttpWebRequest webRequest)
        {
            try
            {
                var httpResponse = (HttpWebResponse) await webRequest.GetResponseAsync();
                using (var responseStream = httpResponse.GetResponseStream())
                {
                    var resposta = new StreamReader(responseStream ?? throw new InvalidOperationException()).ReadToEnd();
                    var nfeResultMsg = Utils.ObterNodeDeStringXml("nfeResultMsg", resposta);
                    return nfeResultMsg;
                }
            }
            catch (WebException ex)
            {
                var msg = $"Ocorreu uma falha ao executar o serviço [{_nomeServico}]";
                Utils.TraceException(ex,msg);
                throw FalhaFabricaComunicacaoException.ObterException(_nomeServico, ex);
            }
        }

        /// <summary>
        ///     Obtem resposta do serviço
        ///     <para>Um arquivo Xml com o nó [nfeResultMsg] é retornado</para>
        /// </summary>
        /// <param name="webRequest"></param>
        /// <returns></returns>
        public string ObterResposta(HttpWebRequest webRequest)
        { 
           
            try
            {
                using (var response = webRequest.GetResponse())
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var resposta = streamReader.ReadToEnd();
                        var nfeResultMsg = Utils.ObterNodeDeStringXml("nfeResultMsg", resposta);
                        return nfeResultMsg;
                    }
                }
            }

            
            catch (WebException ex)
            {
                var msg = $"Ocorreu uma falha ao executar o serviço [{_nomeServico}]";
                Utils.TraceException(ex, msg); 
                throw FalhaFabricaComunicacaoException.ObterException(_nomeServico, ex);
            }

            catch (Exception ex)
            {
                var msg = $"Ocorreu uma falha ao executar o serviço [{_nomeServico}]";
                Utils.TraceException(ex, msg);
                throw new FalhaContingenciaWebException(_nomeServico, ex);
            }
        }
    }
}

 