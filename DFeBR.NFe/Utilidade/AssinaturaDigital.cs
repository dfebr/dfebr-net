// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:22/04/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using Signature = DFeBR.EmissorNFe.Dominio.Assinatura.Signature;

#endregion

namespace DFeBR.EmissorNFe.Utilidade
{
    internal   static class AssinaturaDigital
    {
        /// <summary>
        ///     Assina um arquivo XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <param name="id"></param>
        /// <param name="certificado"></param>
        /// <param name="metodoAssinatura"></param>
        /// <param name="metodoDigest"></param>
        /// <returns></returns>
        public static Signature AssinarNFe<T>(T objeto, string id, X509Certificate2 certificado,
                string metodoAssinatura = "http://www.w3.org/2000/09/xmldsig#rsa-sha1",
                string metodoDigest = "http://www.w3.org/2000/09/xmldsig#sha1") where T : class
        {
            try
            {
                var objetoLocal = objeto;
                if (id == null)
                    throw new Exception("Não é possível assinar um objeto evento sem sua respectiva Id!");
                var documento = new XmlDocument {PreserveWhitespace = true};
                documento.LoadXml(Utils.ClasseParaXmlString(objetoLocal));
                var docXml = new SignedXml(documento) {SigningKey = certificado.PrivateKey};
                docXml.SignedInfo.SignatureMethod = metodoAssinatura;
                var reference = new Reference {Uri = "#" + id, DigestMethod = metodoDigest};

                // adicionando EnvelopedSignatureTransform a referencia
                var envelopedSigntature = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(envelopedSigntature);
                var c14Transform = new XmlDsigC14NTransform();
                reference.AddTransform(c14Transform);
                docXml.AddReference(reference);

                // carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo
                var keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(certificado));
                docXml.KeyInfo = keyInfo;
                docXml.ComputeSignature();

                //// recuperando a representacao do XML assinado
                var xmlDigitalSignature = docXml.GetXml();
                var assinatura = Utils.XmlStringParaClasse<Signature>(xmlDigitalSignature.OuterXml);
                return assinatura;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaAssinaturaException("Erro ao assinar arquivo Xml", ex);
            }
        }
    }
}