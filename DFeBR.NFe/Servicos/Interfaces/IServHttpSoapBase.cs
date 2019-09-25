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


using System.Net;
using System.Threading.Tasks;

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IServHttpSoapBase
    {
        /// <summary>
        ///     Obter instancia do serviço web
        /// </summary>
        /// <param name="url">Endereco Url do serviço</param>
        /// <param name="soapXml">Mensagem body padrão SOAP e especificação SEFAZ</param>
        /// <returns></returns>
        HttpWebRequest ObterRequisicaoSoap(string url, string soapXml);

        /// <summary>
        ///     Obtem resposta do serviço
        ///     <para>Um arquivo Xml com o nó [nfeResultMsg] é retornado</para>
        /// </summary>
        /// <param name="webRequest"></param>
        /// <returns></returns>
        Task<string> ObterRespostaAsync(HttpWebRequest webRequest);

        /// <summary>
        ///     Obtem resposta do serviço
        ///     <para>Um arquivo Xml com o nó [nfeResultMsg] é retornado</para>
        /// </summary>
        /// <param name="webRequest"></param>
        /// <returns></returns>
        string ObterResposta(HttpWebRequest webRequest);
    }
}