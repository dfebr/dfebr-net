// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Entidades;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using Newtonsoft.Json;

#endregion

namespace DFeBR.EmissorNFe.Utilidade
{
    public static class Utils
    {
        #region Funcoes Fiscais

        /// <summary>
        ///     Obtém a chave do documento fiscal
        /// </summary>
        /// <param name="ufEmitente">UF do emitente do DF-e</param>
        /// <param name="dataEmissao">Data de emissão do DF-e</param>
        /// <param name="cnpjEmitente">CNPJ do emitente do DF-e</param>
        /// <param name="modelo">Modelo do DF-e</param>
        /// <param name="serie">Série do DF-e</param>
        /// <param name="numero">Numero do DF-e</param>
        /// <param name="tipoEmissao">
        ///     Tipo de emissão do DF-e. Informar inteiro conforme consta no manual de orientação do
        ///     contribuinte para o DF-e
        /// </param>
        /// <param name="cNf">Código numérico que compõe a Chave de Acesso. Número gerado pelo emitente para cada DF-e</param>
        /// <returns>Retorna um objeto <see cref="DadosChaveFiscal" /> com os dados da chave de acesso</returns>
        public static DadosChaveFiscal ObterChave(Estado ufEmitente, DateTime dataEmissao, string cnpjEmitente, ModeloDocumento modelo,
                int serie, long numero, int tipoEmissao, int cNf)
        {
            var chave = new StringBuilder();
            chave.Append(((int)ufEmitente).ToString("D2")).Append(Convert.ToDateTime(dataEmissao).ToString("yyMM")).Append(cnpjEmitente)
                    .Append(((int)modelo).ToString("D2")).Append(serie.ToString("D3")).Append(numero.ToString("D9"))
                    .Append(tipoEmissao.ToString()).Append(cNf.ToString("D8"));
            var digitoVerificador = ObterDigitoVerificador(chave.ToString());
            chave.Append(digitoVerificador);
            return new DadosChaveFiscal(chave.ToString(), byte.Parse(digitoVerificador));
        }

        /// <summary>
        ///     Calcula e devolve o dígito verificador da chave do DF-e
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        private static string ObterDigitoVerificador(string chave)
        {
            var soma = 0; // Vai guardar a Soma
            int dv; // Vai guardar o DigitoVerificador
            var peso = 2; // vai guardar o peso de multiplicação

            //percorrendo cada caractere da chave da direita para esquerda para fazer os cálculos com o peso
            for (var i = chave.Length - 1; i != -1; i--)
            {
                var ch = Convert.ToInt32(chave[i].ToString());
                soma += ch * peso;
                //sempre que for 9 voltamos o peso a 2
                if (peso < 9)
                    peso += 1;
                else
                    peso = 2;
            }

            //Agora que tenho a soma vamos pegar o resto da divisão por 11
            var mod = soma % 11;
            //Aqui temos uma regrinha, se o resto da divisão for 0 ou 1 então o dv vai ser 0
            if (mod == 0 || mod == 1)
                dv = 0;
            else
                dv = 11 - mod;
            return dv.ToString();
        }

        /// <summary>
        ///     Informa se a chave de um DF-e é válida
        /// </summary>
        /// <param name="chaveNfe"></param>
        /// <returns></returns>
        public static bool ChaveValida(string chaveNfe)
        {
            Estado codigo;
            Enum.TryParse(chaveNfe.Substring(0, 2), out codigo);
            var anoMes = chaveNfe.Substring(2, 4);
            var ano = int.Parse(anoMes.Substring(0, 2));
            var mes = int.Parse(anoMes.Substring(2, 2));
            var anoEMesData = new DateTime(ano, mes, 1);
            var cnpj = chaveNfe.Substring(6, 14);
            ModeloDocumento modelo;
            Enum.TryParse(chaveNfe.Substring(20, 2), out modelo);
            var serie = int.Parse(chaveNfe.Substring(22, 3));
            var numeroNfe = long.Parse(chaveNfe.Substring(25, 9));
            var formaEmissao = int.Parse(chaveNfe.Substring(34, 1));
            var codigoNumerico = int.Parse(chaveNfe.Substring(35, 8));
            var digitoVerificador = chaveNfe.Substring(43, 1);
            var gerarChave = ObterChave(codigo, anoEMesData, cnpj, modelo, serie, numeroNfe, formaEmissao, codigoNumerico);
            return digitoVerificador.Equals(gerarChave.DigitoVerificador.ToString());
        }

        #endregion

        #region Funcoes Genericas

        #region Propriedades

        /// <summary>
        ///     Caminho do arquivo de Log
        /// </summary>
        private static readonly string CaminhoLog = Path.Combine(Path.GetTempPath(), "DFeBR\\Log");

        /// <summary>
        ///     Nome do arquivo
        /// </summary>
        private static readonly string NomeArqErrorLog = "Error.log";

        #endregion

        #region Diversos
        /// <summary>
        ///     Formatar string para CEP
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public static string FormataCep(string cep)
        {
            try
            {
                return Convert.ToUInt64(cep).ToString(@"00000\-000");
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        ///     Formatar string para CNPJ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatarCnpj(string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                    return "";

                var str2 = str.RetirarCaracteresEspeciais();
                return string.IsNullOrWhiteSpace(str2) ? "" :
                        Convert.ToUInt64(str2).ToString(@"00\.000\.000\/0000\-00");
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// Formatar numero
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatarNumero(this decimal value)
        {
            return $"{(object)value:0.00}".Replace(",", ".").Trim();
        }

        /// <summary>
        /// Formatar CNPJ ou CPF
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static string FormatarCnpjCpf(string doc)
        {
            if (string.IsNullOrEmpty(doc))
                return doc;
            string empty = string.Empty;
            if (doc.Trim().Length < 12)
            {
                doc = doc.Trim();
                return Regex.Replace(doc, "(\\w{3})(\\w{3})(\\w{3})(\\w{2})", "$1.$2.$3-$4");
            }
            doc = doc.Trim();
            return Regex.Replace(doc, "(\\w{2})(\\w{3})(\\w{3})(\\w{4})(\\w{2})", "$1.$2.$3/$4-$5");

        }

        /// <summary>
        ///     Trunca string
        /// </summary>
        /// <param name="value">string</param>
        /// <param name="maxLength">Quantidade máxima de caracteres para exibição</param>
        /// <returns></returns>
        public static string Truncar(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lengthAfterSpace"></param>
        /// <returns></returns>
        public static string FormatarEspaco(this string text, int lengthAfterSpace)
        {
            string empty = string.Empty;
            int num = 1;
            foreach (char ch in text)
            {
                empty += ch.ToString();
                if (num == lengthAfterSpace)
                {
                    empty += " ";
                    num = 1;
                }
                else
                    ++num;
            }
            return empty.Trim();
        }

        /// <summary>
        ///     Obtém uma string Hexadecimal de uma string passada no parâmetro
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ObterHexDeString(string s)
        {
            var hex = "";
            foreach (var c in s)
            {
                int tmp = c;
                hex += $"{Convert.ToUInt32(tmp.ToString()):x2}";
            }

            return hex;
        }

        /// <summary>
        ///     Obtém uma <see cref="string" /> SHA1, no formato hexadecimal da <see cref="string" /> passada no parâmero
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ObterHexSha1DeString(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(bytes);
            return ObterHexDeByteArray(hashBytes);
        }

        /// <summary>
        ///     Obtém uma string Hexadecimal do array de bytes passado no parâmetro
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ObterHexDeByteArray(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }

        private static void CopiarPara(Stream src, Stream dest)
        {
            var bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0) dest.Write(bytes, 0, cnt);
        }

        /// <summary>
        ///     Compacta uma string para GZip
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    CopiarPara(msi, gs);
                }

                return mso.ToArray();
            }
        }

        /// <summary>
        ///     Descompacta uma string GZip
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopiarPara(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        /// <summary>
        ///     Criar pasta no caminho indicador
        /// </summary>
        /// <param name="caminho">caminho do arquivo</param>
        public static bool CriarPasta(string caminho)
        {
            // Tentar criar diretorio
            Directory.CreateDirectory(caminho);
            return true;
        }

        /// <summary>
        ///     Criar pasta se não existir
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        /// <returns></returns>
        public static void CriarPastaSeNaoExistir(string caminho)
        {
            if (!ExisteDiretorio(caminho)) CriarPasta(caminho);
        }

        /// <summary>
        ///     Verificar se o diretorio existe
        /// </summary>
        /// <param name="caminho">caminho do arquivo</param>
        /// <returns></returns>
        public static bool ExisteDiretorio(string caminho)
        {
            // Determinar se o diretorio existe
            if (Directory.Exists(caminho))
                return true;
            return false;
        }

        /// <summary>
        ///     Listar todos os arquivos referente a extensão desejada, no respectivo diretorio
        /// </summary>
        /// <param name="caminho">Diretório</param>
        /// <param name="extensao">Uma extensão, exemplo: *.txt</param>
        /// <returns></returns>
        public static ICollection<string> ListarArquivos(string caminho, string extensao = "*.*")
        {
            if (!ExisteDiretorio(caminho)) throw new DirectoryNotFoundException("Diretório não encontrado");
            var list = Directory.GetFiles(caminho, extensao);
            return list;
        }

        /// <summary>
        ///     Deletar arquivos presentes da pasta
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        public static void DeletarArquivosDaPasta(string caminho)
        {
            // Deletar todos os arquivos se houver.... 
            var diretorio = new DirectoryInfo(caminho);
            foreach (var file in diretorio.GetFiles())
                file.Delete();
        }

        /// <summary>
        ///     Deletar arquivo
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        public static void DelatarArquivo(string caminho, string nomeArquivo)
        {
            var c1 = Path.Combine(caminho, nomeArquivo);
            File.Delete(c1);
        }

        /// <summary>
        ///     Escrever arquivo em modo stream, assincronamente
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <param name="conteudo">Conteudo</param>
        public static void EscreverArquivo(string caminho, string nomeArquivo, string conteudo)
        {
            if (caminho == null)
                throw new ArgumentNullException(nameof(caminho), "O caminho do arquivo deve ser informado");
            if (nomeArquivo == null)
                throw new ArgumentNullException(nameof(nomeArquivo), "O nome do arquivo deve ser informado");
            if (conteudo == null)
                throw new ArgumentNullException(nameof(conteudo), "O conteúdo do arquivo deve ser informado");
            CriarPastaSeNaoExistir(caminho);
            var encodedText = Encoding.UTF8.GetBytes(conteudo);
            var c1 = Path.Combine(caminho, nomeArquivo); // Combina caminho do arquivo como nome do arquivo
            using (var sourceStream = new FileStream(c1, FileMode.Append, FileAccess.Write, FileShare.None, 4096, true))
            {
                sourceStream.Write(encodedText, 0, encodedText.Length);
                sourceStream.Close();
            }
        }

        /// <summary>
        ///     Ler arquivo
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        public static string LerArquivo(string caminho, string nomeArquivo)
        {
            var c1 = Path.Combine(caminho, nomeArquivo); // Combina caminho do arquivo como nome do arquivo
            if (File.Exists(c1) == false)
                throw new FileNotFoundException("Arquivo não encontrado");

            // Lendo arquivo
            string str;
            using (var sourceStream = new StreamReader(c1, Encoding.UTF8))
            {
                str = sourceStream.ReadToEnd();
                sourceStream.Close();
            }

            return str;
        }

        /// <summary>
        ///     Testar conexão com internet
        /// </summary>
        /// <returns></returns>
        public static bool TestarConexaoInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Ler arquivo
        /// </summary>
        /// <param name="caminho">Caminho do arquivo</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        public static byte[] LerArquivoStream(string caminho, string nomeArquivo)
        {
            var c1 = Path.Combine(caminho, nomeArquivo); // Combina caminho do arquivo como nome do arquivo
            if (File.Exists(c1) == false)
                throw new FileNotFoundException("Arquivo não encontrado");

            // Lendo arquivo
            byte[] stream;
            using (var sourceStream = new FileStream(c1, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                stream = new byte[sourceStream.Length];
            }

            return stream;
        }

        /// <summary>
        ///     Enviar email
        /// </summary>
        /// <param name="email">E-mail</param>
        /// <param name="nomeUsuario">Nome do usuário</param>
        /// <returns></returns>
        public static void EnviarEmail(Email email, string nomeUsuario)
        {
            try
            {
                var smtpClient = new SmtpClient();
                var basicCredential = new NetworkCredential(email.Usuario, email.Senha);
                smtpClient.EnableSsl = email.UsarSsl;
                smtpClient.Host = email.ServidorEmail;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.Port = Convert.ToInt32(email.Porta);
                smtpClient.Timeout = string.IsNullOrEmpty(email.TimeOut) ? 100000 : Convert.ToInt32(email.TimeOut);
                var fromAddress = new MailAddress(email.EmailRemetente, email.NomeRemetente);
                var vMessage = new MailMessage();
                vMessage.From = fromAddress;
                vMessage.IsBodyHtml = true;
                vMessage.Subject = email.Assunto;
                foreach (var destinatario in email.EmailDestinatario)
                {
                    if (string.IsNullOrEmpty(destinatario.Trim()))
                        continue;
                    vMessage.To.Add(destinatario);
                }

                if (vMessage.To.Count == 0)
                    throw new Exception("Informar um destinatário");
                email.Mensagem = email.Mensagem.Replace("\n", "<br />");
                vMessage.Body = email.Mensagem;

                // Anexos
                if (email.Anexos != null)
                    for (var i = 0; i < email.Anexos.Count; i++)
                    {
                        Stream stream = new MemoryStream(email.Anexos[i]);
                        stream.Position = 0;
                        vMessage.Attachments.Add(new Attachment(stream, "Anexo" + i, MediaTypeNames.Application.Octet));
                    }

                smtpClient.Send(vMessage);
            }
            catch (Exception ex)
            {
                TraceException(ex);
                throw new Exception("Uma falha ocorreu ao enviar email", ex);
            }
        }

        #endregion

        #region Trace Exception

        /// <summary>
        ///     Obtém uma exceção.
        ///     Se o status da <see cref="WebException" /> estiver na lista <see cref="ListaComunicacaoException" />,
        ///     será retornada uma exceção do tipo <see cref="FalhaComunicacaoException" />,
        ///     senão será retornada a própria <see cref="WebException" /> passada no parâmetro
        /// </summary>
        /// <param name="servico"></param>
        /// <param name="webException"></param>
        /// <returns></returns>
        public static Exception ObterFalhaComunicacaoException(string servico, WebException webException)
        {
            if (ListaComunicacaoException.Contains(webException.Status))
                return new FalhaComunicacaoException(servico, webException);
            return webException;
        }

        /// <summary>
        ///     Lista com os status de WebException que serão traduzidos para ComunicacaoException
        /// </summary>
        private static readonly List<WebExceptionStatus> ListaComunicacaoException = new List<WebExceptionStatus>
        {
                WebExceptionStatus.CacheEntryNotFound,
                WebExceptionStatus.ConnectFailure,
                WebExceptionStatus.ConnectionClosed,
                WebExceptionStatus.KeepAliveFailure,
                WebExceptionStatus.MessageLengthLimitExceeded,
                WebExceptionStatus.NameResolutionFailure,
                WebExceptionStatus.Pending,
                WebExceptionStatus.PipelineFailure,

                //WebExceptionStatus.ProtocolError,
                WebExceptionStatus.ProxyNameResolutionFailure,
                WebExceptionStatus.ReceiveFailure,
                WebExceptionStatus.RequestCanceled,
                WebExceptionStatus.RequestProhibitedByCachePolicy,
                WebExceptionStatus.RequestProhibitedByProxy,
                //WebExceptionStatus.SecureChannelFailure,
                WebExceptionStatus.SendFailure,
                WebExceptionStatus.ServerProtocolViolation,
                //WebExceptionStatus.Success,
                WebExceptionStatus.Timeout,
                //WebExceptionStatus.TrustFailure,
                WebExceptionStatus.UnknownError
        };


        /// <summary>
        ///     Registra erros do sistema
        /// </summary>
        /// <param name="ex"></param>
        public static void TraceException(Exception ex)
        {
            TraceException(ex, string.Empty);
        }

        /// <summary>
        ///     Registra erros do sistema
        /// </summary>
        /// <param name="ex">Um Exception</param>
        /// <param name="msg">Uma mensagem adicional</param>
        public static void TraceException(Exception ex, string msg)
        {
            var str = new StringBuilder();
            var error = new ErrorTrace
            {
                Data = DateTime.Now.ToString("g"),
                Detalhe = ex.GetType().Name,
                Mensagem = $"{ex.Message}.{msg}",
                StackTrace = ex.StackTrace
            };
            var content = JsonSerialize(error);
            str.Append(content);
            str.Append("?");
            str.Append(Environment.NewLine);
            EscreverArquivo(CaminhoLog, NomeArqErrorLog, str.ToString());
        }

        /// <summary>
        ///     Obter lista de erros gravados
        /// </summary>
        /// <returns></returns>
        public static ICollection<ErrorTrace> ListarTraceExceptions()
        {
            try
            {
                var lst = new List<ErrorTrace>();
                var c1 = LerArquivo(CaminhoLog, NomeArqErrorLog);
                var d1 = c1.Split(new[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in d1)
                {
                    var str = item.Replace(Environment.NewLine, string.Empty);
                    if (!string.IsNullOrWhiteSpace(str))
                        lst.Add(JsonConvert.DeserializeObject<ErrorTrace>(str,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore,
                                    MissingMemberHandling = MissingMemberHandling.Ignore,
                                    Formatting = Formatting.Indented
                                }));
                }

                return lst;
            }
            catch (Exception ex)
            {
                // Limpar arquivos de erros para poder obter dados da proxima vez...
                DelatarArquivo(CaminhoLog, NomeArqErrorLog);
                TraceException(ex);

                // Deserializa
                return new List<ErrorTrace>();
            }
        }

        /// <summary>
        ///     Deletar arquivo de Log
        /// </summary>
        public static void DeletarArquivoLog()
        {
            DelatarArquivo(CaminhoLog, NomeArqErrorLog);
        }

        #endregion

        #region Json

        /// <summary>
        ///     Converte objeto em JSON
        /// </summary>
        /// <param name="entity">Entidade de dominio</param>
        /// <returns></returns>
        public static string JsonSerialize(object entity)
        {
            var jsonconverter = JsonConvert.SerializeObject(entity, Formatting.Indented,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, Formatting = Formatting.Indented });
            return jsonconverter;
        }

        /// <summary>
        ///     Converte JSON em objeto
        /// </summary>
        /// <typeparam name="T">Tipo a ser convertido</typeparam>
        /// <param name="json">String Json</param>
        /// <returns></returns>
        public static object JsonDeserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion

        #region Xml

        /// <summary>
        ///     Converte uma instancia de objeto para uma string XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static string ObterStringXML<T>(this T objeto)
        {
            XElement xml;
            var keyNomeClasseEmUso = typeof(T).FullName;
            var ser = BuscarNoCache(keyNomeClasseEmUso, typeof(T));
            using (var memory = new MemoryStream())
            {
                using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
                {
                    ser.Serialize(memory, objeto);
                    memory.Position = 0;
                    xml = XElement.Load(tr);
                    xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
                }
            }

            return XElement.Parse(xml.ToString()).ToString(SaveOptions.DisableFormatting);
        }

        /// <summary>
        ///     Deserializa a classe a partir de uma String contendo a estrutura XML daquela classe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T ConverterXMLParaClasse<T>(this string input) where T : class
        {
            try
            {
                var keyNomeClasseEmUso = typeof(T).FullName;
                var ser = BuscarNoCache(keyNomeClasseEmUso, typeof(T));
                using (var sr = new StringReader(input))
                {
                    ser.UnknownElement += (sender, e) =>
                    {
                       return;
                    };
                    return (T)ser.Deserialize(sr);
                }
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Aconteceu um erro ao tentar deserializar o XML, o erro foi: {ex.Message} com as exception: {ex.ToString()}");
            }

        }

        /// <summary>
        ///     Carrega o objeto da classe com dados do arquivo XML (Deserializa a classe). Atenção o XML deve ter a mesma
        ///     estrutura da classe
        /// </summary>
        /// <typeparam name="T">Classe</typeparam>
        /// <param name="arquivo">Arquivo XML</param>
        /// <returns>Retorna a classe</returns>
        public static T ArquivoXmlParaClasse<T>(string arquivo) where T : class
        {
            if (!File.Exists(arquivo)) throw new FileNotFoundException("Arquivo " + arquivo + " não encontrado!");
            var keyNomeClasseEmUso = typeof(T).FullName;
            var serializador = BuscarNoCache(keyNomeClasseEmUso, typeof(T));
            var stream = new FileStream(arquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                return (T)serializador.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }
        }

        /// <summary>
        ///     Copia a estrutura e os dados da classe passada para um arquivo XML (Serializa a classe). Use try catch para tratar
        ///     a possível exceção "DirectoryNotFoundException"
        /// </summary>
        /// <typeparam name="T">Classe</typeparam>
        /// <param name="objeto">Objeto da Classe</param>
        /// <param name="arquivo">Arquivo XML</param>
        public static void ClasseParaArquivoXml<T>(T objeto, string arquivo)
        {
            var dir = Path.GetDirectoryName(arquivo);
            if (dir != null && !Directory.Exists(dir))
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");
            var xml = ObterStringXML(objeto);
            try
            {
                var stw = new StreamWriter(arquivo);
                stw.WriteLine(xml);
                stw.Close();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo " + arquivo + "!");
            }
        }

        public static void SalvarStringXmlParaArquivoXml(string xml, string arquivo)
        {
            var dir = Path.GetDirectoryName(arquivo);
            if (dir != null && !Directory.Exists(dir))
                throw new DirectoryNotFoundException("Diretório " + dir + " não encontrado!");
            try
            {
                var stw = new StreamWriter(arquivo);
                stw.WriteLine(xml);
                stw.Close();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível criar o arquivo " + arquivo + "!");
            }
        }

        /// <summary>
        ///     Obtém um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="nomeDoNode"></param>
        /// <param name="stream"></param>
        /// <returns>Retorna a string contendo o node XML cujo strem foi passado no parâmetro nomeDoNode</returns>
        public static string ObterNodeDeStream(string nomeDoNode, StreamReader stream)
        {
            var xmlDoc = XDocument.Load(stream);
            var xmlString = (from d in xmlDoc.Descendants() where d.Name.LocalName == nomeDoNode select d).FirstOrDefault();
            if (xmlString == null)
                throw new Exception($"Nenhum objeto {nomeDoNode} encontrado no stream!");
            return xmlString.ToString();
        }

        /// <summary>
        ///     Obtém um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="nomeDoNode"></param>
        /// <param name="arquivoXml"></param>
        /// <returns>Retorna a string contendo o node XML cujo nome foi passado no parâmetro nomeDoNode</returns>
        public static string ObterNodeDeArquivoXml(string nomeDoNode, string arquivoXml)
        {
            var xmlDoc = XDocument.Load(arquivoXml);
            var xmlString = (from d in xmlDoc.Descendants() where d.Name.LocalName == nomeDoNode select d).FirstOrDefault();
            if (xmlString == null)
                throw new Exception($"Nenhum objeto {nomeDoNode} encontrado no arquivo {arquivoXml}!");
            return xmlString.ToString();
        }

        /// <summary>
        ///     Obtém o valor de um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML
        ///     contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="tagXml"></param>
        /// <returns></returns>
        public static string ObterValorNodeStringXml(string xml, string tagXml)
        {
            var s = xml;
            var xmlDoc = XDocument.Parse(s);
            var xmlString = (from d in xmlDoc.Descendants() where d.Name.LocalName == tagXml select d).FirstOrDefault();
            if (xmlString == null)
                throw new Exception($"Nenhum objeto {tagXml} encontrado no xml!");
            return xmlString.Value;
        }

        /// <summary>
        ///     Obtém um node XML no formato string de um arquivo XML. Util por exemplo, para extrair uma NFe de um XML contendo um
        ///     nfeproc, enviNFe, etc.
        /// </summary>
        /// <param name="nomeDoNode"></param>
        /// <param name="stringXml"></param>
        /// <returns>Retorna a string contendo o node XML cujo nome foi passado no parâmetro nomeDoNode</returns>
        public static string ObterNodeDeStringXml(string nomeDoNode, string stringXml)
        {
            var s = stringXml;
            var xmlDoc = XDocument.Parse(s);
            var xmlString = (from d in xmlDoc.Descendants() where d.Name.LocalName == nomeDoNode select d).FirstOrDefault();
            if (xmlString == null)
                throw new Exception($"Nenhum objeto {nomeDoNode} encontrado no xml!");
            return xmlString.ToString();
        }

        private static readonly Hashtable CacheSerializers = new Hashtable();

        private static XmlSerializer BuscarNoCache(string chave, Type type)
        {
            if (CacheSerializers.Contains(chave)) return (XmlSerializer)CacheSerializers[chave];
            var ser = XmlSerializer.FromTypes(new[] { type })[0];
            CacheSerializers.Add(chave, ser);
            return ser;
        }

        #endregion

        #endregion

        #region Metodos de Extensão

        #region Tipos Enums

        /// <summary>
        ///     Obter uma string a partir de uma versao do serviço
        /// </summary>
        /// <param name="versaoServico"></param>
        /// <returns></returns>
        public static string ObterVersaoServico(this VersaoServico versaoServico)
        {
            switch (versaoServico)
            {
                case VersaoServico.Ve310:
                    return "3.10";
                case VersaoServico.Ve400:
                    return "4.00";
                case VersaoServico.Ve100:
                    return "1.00";
                case VersaoServico.Ve200:
                    return "2.00";
                default:
                    throw new IndexOutOfRangeException("Não foi encontrado um serviço implementado.");
            }
        }

        #endregion

        #region  Certificado Digital

        /// <summary>
        ///     Extenção para certificado digital
        ///     <para>Verificar validade do certificado digital, se vencido dispara ArgumentException</para>
        /// </summary>
        /// <param name="x509Certificate2"></param>
        public static void VerificaValidade(this X509Certificate2 x509Certificate2)
        {
            var dataExpiracao = Convert.ToDateTime(x509Certificate2.GetExpirationDateString());
            if (dataExpiracao <= DateTime.Now)
                throw new ArgumentException("Certificado digital vencido na data => " + dataExpiracao);
        }

        /// <summary>
        ///     Extensão para retornar o número de dias válidos do certificado
        /// </summary>
        /// <param name="x509Certificate2"></param>
        /// <returns>Número de dias válidos</returns>
        public static int VerificaDiasValidade(this X509Certificate2 x509Certificate2)
        {
            var dtExp = Convert.ToDateTime(x509Certificate2.GetExpirationDateString().Substring(0, 10));
            var dt = dtExp.Subtract(DateTime.Today);
            return dt.Days;
        }

        /// <summary>
        ///     Extenção para certificado digital
        ///     <para>Se usado ele retorna true se for um hardware, se for PenDriver ou SmartCard</para>
        /// </summary>
        /// <param name="x509Certificate2"></param>
        /// <returns>bool</returns>
        public static bool IsA3(this X509Certificate2 x509Certificate2)
        {
            if (x509Certificate2 == null)
                return false;
            var result = false;
            try
            {
                var service = x509Certificate2.PrivateKey as RSACryptoServiceProvider;
                if (service != null)
                    if (service.CspKeyContainerInfo.Removable && service.CspKeyContainerInfo.HardwareDevice)
                        result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        #endregion

        #region String
        /// <summary>
        /// Formatar numero para exibição da DANFE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatarNumeroDanfe(this decimal value)
        {
            var str = FormatarNumero(value);
            str = str.Replace(".", ",");
            double result = 0.0;
            double.TryParse(str, out result);
            return result.ToString("C");
        }

        /// <summary>
        /// Formatar numero para exibição da DANFE
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatarNumeroQuantidadeDanfe(this decimal value)
        {
            var str = FormatarNumero(value);
            str = str.Replace(".", ",");
            double result = 0.0;
            double.TryParse(str, out result);
            return result.ToString("#.000").Trim();
        }
        public static string RemoverAcentos(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return valor;
            valor = Regex.Replace(valor, "[áàâãª]", "a");
            valor = Regex.Replace(valor, "[ÁÀÂÃÄ]", "A");
            valor = Regex.Replace(valor, "[éèêë]", "e");
            valor = Regex.Replace(valor, "[ÉÈÊË]", "E");
            valor = Regex.Replace(valor, "[íìîï]", "i");
            valor = Regex.Replace(valor, "[ÍÌÎÏ]", "I");
            valor = Regex.Replace(valor, "[óòôõöº]", "o");
            valor = Regex.Replace(valor, "[ÓÒÔÕÖ]", "O");
            valor = Regex.Replace(valor, "[úùûü]", "u");
            valor = Regex.Replace(valor, "[ÚÙÛÜ]", "U");
            valor = Regex.Replace(valor, "[Ç]", "C");
            valor = Regex.Replace(valor, "[ç]", "c");
            return valor;
        }

        /// <summary>
        ///     Converte uma cadeia de caracteres para UTF8
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertParaEncodingUtf8(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            var bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///     Retira caracteres especias da string
        /// </summary>
        /// <param name="str">Uma string</param>
        /// <returns></returns>
        public static string RetirarCaracteresEspeciais(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            var novastring = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return novastring.Replace(str, string.Empty);
        }

        /// <summary>
        ///     Retirar letras da string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RetirarLetras(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            var novastring = new Regex("[a-z A-Z]", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return novastring.Replace(str, string.Empty);
        }

        #endregion

        #region Data

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataString(this DateTimeOffset data)
        {
            return data == DateTimeOffset.MinValue ? null : data.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataString(this DateTimeOffset? data)
        {
            if (data == null) return null;
            return data == DateTimeOffset.MinValue ? null : data.Value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringUtc(this DateTimeOffset data)
        {
            return data == DateTimeOffset.MinValue ? null : data.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:dd
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringSemUtc(this DateTimeOffset data)
        {
            return data == DateTimeOffset.MinValue ? null : data.ToString("yyyy-MM-ddTHH:mm:dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:dd
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringSemUtc(this DateTimeOffset? data)
        {
            return ParaDataHoraStringSemUtc(data.GetValueOrDefault());
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringUtc(this DateTimeOffset? data)
        {
            return ParaDataHoraStringUtc(data.GetValueOrDefault());
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD HH:mm:ss
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraString(this DateTimeOffset data)
        {
            return data.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataString(this DateTime data)
        {
            return data == DateTime.MinValue ? null : data.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataString(this DateTime? data)
        {
            if (data == null) return null;
            return data == DateTime.MinValue ? null : data.Value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringUtc(this DateTime data)
        {
            return data == DateTime.MinValue ? null : data.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:dd
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringSemUtc(this DateTime data)
        {
            return data == DateTime.MinValue ? null : data.ToString("yyyy-MM-ddTHH:mm:dd");
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:dd
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringSemUtc(this DateTime? data)
        {
            return ParaDataHoraStringSemUtc(data.GetValueOrDefault());
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraStringUtc(this DateTime? data)
        {
            return ParaDataHoraStringUtc(data.GetValueOrDefault());
        }

        /// <summary>
        ///     Retorna uma string no formato AAAA-MM-DD HH:mm:ss
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ParaDataHoraString(this DateTime data)
        {
            return data.ToString("yyyyMMddHHmmss");
        }

        public static string ParaHoraString(this TimeSpan hora)
        {
            return hora.ToString(@"hh\:mm\:ss");
        }

        #endregion

        #region Estado/UF
        public static Estado SiglaParaEstado(this string sigla)
        {
            var enumValues = Enum.GetValues(typeof(Estado)).Cast<Estado>().FirstOrDefault(e => e.ToString() == sigla);
            return enumValues;
        }
        #endregion

        #region Enums

        /// <summary>
        ///     Função de extensão de Enums.
        ///     Obtém um atributo associado ao Enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ObterAtributo<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        /// <summary>
        ///     Função de extensão de Enums.
        ///     Obtém a descrição definida no atributo [Description("xx")] para o Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Descricao(this Enum value)
        {
            var attribute = value.ObterAtributo<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        ///     Função de extensão de Enums.
        ///     Obtém a XmlEnum definida no atributo [XmlEnum("xx")]para o Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string XmlDescricao(this Enum value)
        {
            var attribute = value.ObterAtributo<XmlEnumAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        #endregion

        #region Numeros

        /// <summary>
        ///     Arredonda valores
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="casasDecimais"></param>
        /// <returns></returns>
        public static decimal Arredondar(this decimal valor, int casasDecimais)
        {
            var valorNovo = decimal.Round(valor, casasDecimais, MidpointRounding.AwayFromZero);
            var valorNovoStr = valorNovo.ToString("F" + casasDecimais, CultureInfo.CurrentCulture);
            return decimal.Parse(valorNovoStr);
        }

        public static decimal? Arredondar(this decimal? valor, int casasDecimais)
        {
            if (valor == null) return null;
            return Arredondar(valor.Value, casasDecimais);
        }

        public static decimal ArredondarParaBaixo(this decimal valor, int casasDecimais)
        {
            var divisor = (decimal)Math.Pow(10, casasDecimais);
            var dividendo = (int)Math.Truncate(divisor * valor);
            return dividendo / divisor;
        }

        #endregion

        #region Reflexao

        /// <summary>
        ///     Copia o valor das propriedades comuns entre dois objetos
        /// </summary>
        /// <typeparam name="TOrigem"></typeparam>
        /// <typeparam name="TDestino"></typeparam>
        /// <param name="objetoOrigem"></param>
        /// <param name="objetoDestino"></param>
        public static void CopiarPropriedades<TDestino, TOrigem>(this TDestino objetoDestino, TOrigem objetoOrigem)
                where TDestino : class where TOrigem : class
        {
            foreach (var attributo in objetoOrigem.GetType().GetProperties().Where(p => p.CanRead))
            {
                var propertyInfo = objetoDestino.GetType().GetProperty(attributo.Name, BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null && propertyInfo.CanWrite)
                    propertyInfo.SetValue(objetoDestino, attributo.GetValue(objetoOrigem, null), null);
            }
        }

        /// <summary>
        ///     Obtém informações de uma propriedade de um objeto.
        ///     <example>var propinfo = Funcoes.ObterPropriedadeInfo(_cfgServico, c => c.DiretorioSalvarXml);</example>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyLambda"></param>
        /// <returns>Retorna um objeto do tipo PropertyInfo com as informações da propriedade, como nome, tipo, etc</returns>
        public static PropertyInfo ObterPropriedadeInfo<TSource, TProperty>(this TSource source,
                Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);
            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException($"A expressão '{propertyLambda}' se refere a um método, não a uma propriedade!");
            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"A expressão '{propertyLambda}' se refere a um campo, não a uma propriedade!");
            if (propInfo.ReflectedType != null && type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException($"A expressão '{propertyLambda}' refere-se a uma propriedade, mas não é do tipo {type}!");
            return propInfo;
        }

        /// <summary>
        ///     Obtém as propriedades de um determinado objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns>Retorna um objeto Dictionary contendo o nome da propriedade e seu valor</returns>
        public static Dictionary<string, object> LerPropriedades<T>(this T objeto) where T : class
        {
            // A função pode ser melhorada para trazer recursivamente as propriedades dos objetos filhos
            var dicionario = new Dictionary<string, object>();
            foreach (var attributo in objeto.GetType().GetProperties())
            {
                var value = attributo.GetValue(objeto, null);
                dicionario.Add(attributo.Name, value);
            }

            return dicionario;
        }

        /// <summary>
        ///     Obtém uma lista contendo os nomes das propriedades cujo valor não foi definido ou está vazio, de um determinado
        ///     objeto
        ///     passado como parâmetro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns>Retorna uma lista de strings</returns>
        public static List<string> ObterPropriedadesEmBranco<T>(this T objeto)
        {
            return (from attributo in objeto.GetType().GetProperties()
                    let value = attributo.GetValue(objeto, null)
                    where value == null || string.IsNullOrEmpty(value.ToString())
                    select attributo.Name).ToList();
        }

        #endregion

        #endregion
    }
}