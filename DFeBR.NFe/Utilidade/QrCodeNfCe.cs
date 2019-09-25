// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:24/04/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Utilidade
{
    internal static class QrCodeNfCe
    {
        /// <summary>
        ///     Obtém a URL para uso no QR-Code, versão 2.0 - leiaute 4.00
        /// </summary>
        /// <param name="nfe">Nota Fiscal</param>
        /// <param name="cIdToken">Código ID 000001</param>
        /// <param name="csc">Código CSC</param>
        /// <param name="urlQrCode">Endereco Urldo QRCode</param>
        /// <returns></returns>
        public static string ObterUrlQrCode2(NFe nfe, string cIdToken, string csc, string urlQrCode)
        {
            if (nfe == null) throw new ArgumentNullException(nameof(nfe));
            if (cIdToken == null) throw new ArgumentNullException(nameof(cIdToken));
            if (csc == null) throw new ArgumentNullException(nameof(csc));
            if (urlQrCode == null) throw new ArgumentNullException(nameof(urlQrCode));

            #region 1ª parte

            var url = ObterUrlQrCode2ComParametro(urlQrCode);

            #endregion

            #region 2ª parte

            const string pipe = "|";

            //Chave de Acesso da NFC-e 
            var chave = nfe.infNFe.Id.Substring(3);

            //Identificação do Ambiente (1 – Produção, 2 – Homologação) 
            var ambiente = (int) nfe.infNFe.ide.tpAmb;

            //Identificador do CSC (Código de Segurança do Contribuinte no Banco de Dados da SEFAZ). Informar sem os zeros não significativos
            var idCsc = Convert.ToInt16(cIdToken);
            string dadosBase;
            if (nfe.infNFe.ide.tpEmis == TipoEmissao.ContingenciaOffLineNfce)
            {
                var diaEmi = nfe.infNFe.ide.dhEmi.Day.ToString("D2");
                var valorNfce = nfe.infNFe.total.ICMSTot.vNF.ToString("0.00").Replace(',', '.');
                var digVal = Utils.ObterHexDeString(nfe.Signature.SignedInfo.Reference.DigestValue);
                dadosBase = string.Concat(chave, pipe, 2, pipe, ambiente, pipe, diaEmi, pipe, valorNfce, pipe, digVal, pipe, idCsc);
            }
            else
            {
                dadosBase = string.Concat(chave, pipe, 2, pipe, ambiente, pipe, idCsc);
            }

            var dadosSha1 = string.Concat(dadosBase, csc);
            var sh1 = Utils.ObterHexSha1DeString(dadosSha1);
            return string.Concat(url, dadosBase, pipe, sh1);

            #endregion

        }

        /// <summary>
        ///     Obtém a URL para o QR-Code versão 2.0 com o tratamento de parâmetro query no final da url
        /// </summary>
        /// <returns></returns>
        private static string ObterUrlQrCode2ComParametro(string urlQrCode)
        {
            if (urlQrCode == null) throw new ArgumentNullException(nameof(urlQrCode));
            const string interrogacao = "?";
            const string parametro = "p=";
            if (!urlQrCode.EndsWith(interrogacao))
                urlQrCode += interrogacao;
            if (!urlQrCode.EndsWith(parametro))
                urlQrCode += parametro;
            return urlQrCode;
        }
    }
}