// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Net
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DFeBR.EmissorNFe.Utilidade.Entidades;
using DFeBR.EmissorNFe.Utilidade.Exceptions;
using DFeBR.EmissorNFe.Utilidade.Tipos;

namespace DFeBR.EmissorNFe.Utilidade
{
    #region

    #endregion

    /// <summary>
    ///     The certificado digital.
    /// </summary>
    internal static class CertificadoDigital
    {
        #region Propriedades

        private static readonly Dictionary<string, X509Certificate2> CacheCertificado = new Dictionary<string, X509Certificate2>();

        #endregion

        #region  Metodos

        /// <summary>
        ///     Exibe a lista de certificados instalados no PC e devolve o certificado selecionado
        /// </summary>
        /// <returns></returns>
        public static X509Certificate2Collection ListarCertificados(StoreName storeName)
        {
            try
            {
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2 certificate = new X509Certificate2();
                X509Certificate2Collection collection = store.Certificates;
                return collection;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaCertificadoDigitalException("Falha ao listar certificados digitais",ex);
            }
        }

        /// <summary>
        ///     Obtém um objeto contendo o certificado digital
        ///     <para>
        ///         Se for informado <see cref="CertificadoConfig.Arquivo" />,
        ///         o certificado digital será obtido pelo método <see cref="ObterDeArquivo(string,string)" />,
        ///         senão será obtido pelo método <see cref="ListareObterDoRepositorio" />
        ///     </para>
        ///     <para>
        ///         Para liberar os recursos do certificado, após seu uso, invoque o método
        ///         <see cref="X509Certificate2.Reset()" />
        ///     </para>
        /// </summary>
        public static X509Certificate2 ObterCertificado(CertificadoConfig configuracaoCertificado)
        {
            try
            {
                if (configuracaoCertificado == null) throw new ArgumentNullException(nameof(configuracaoCertificado), "Informar o certificado digital");

                if (!configuracaoCertificado.ManterDadosEmCache)
                    return ObterDadosCertificado(configuracaoCertificado);
                if (!string.IsNullOrEmpty(configuracaoCertificado.CacheId) && CacheCertificado.ContainsKey(configuracaoCertificado.CacheId))
                    return CacheCertificado[configuracaoCertificado.CacheId];
                var certificado = ObterDadosCertificado(configuracaoCertificado);
                var keyCertificado = string.IsNullOrEmpty(configuracaoCertificado.CacheId) ? certificado.SerialNumber : configuracaoCertificado.CacheId;
                configuracaoCertificado.CacheId = keyCertificado;
                CacheCertificado.Add(keyCertificado, certificado);
                return CacheCertificado[keyCertificado];
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaCertificadoDigitalException("Falha ao listar certificados digitais", ex);
            }
           
        }

        public static void ClearCache()
        {
            CacheCertificado.Clear();
        }

        #endregion

        #region Métodos privados

        /// <summary>
        ///     Cria e devolve um objeto <see cref="X509Store" />
        /// </summary>
        /// <param name="openFlags"></param>
        /// <returns></returns>
        private static X509Store ObterX509Store(OpenFlags openFlags)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(openFlags);
            return store;
        }

        #region Métodos para obter um certificado X509Certificate2

        /// <summary>
        ///     Obtém um certificado a partir do arquivo e da senha passados nos parâmetros
        /// </summary>
        /// <param name="arquivo">Arquivo do certificado digital</param>
        /// <param name="senha">Senha do certificado digital</param>
        /// <returns></returns>
        private static X509Certificate2 ObterDeArquivo(string arquivo, string senha)
        {
            if (!File.Exists(arquivo))
                throw new Exception(string.Format("Certificado digital {0} não encontrado!", arquivo));
            var certificado = new X509Certificate2(arquivo, senha, X509KeyStorageFlags.MachineKeySet);
            return certificado;
        }

        /// <summary>
        ///     Obtém um certificado a partir do arquivo e da senha passados nos parâmetros
        /// </summary>
        /// <param name="arrayBytes">Array de bytes do certificado digital</param>
        /// <param name="senha">Senha do certificado digital</param>
        /// <returns></returns>
        private static X509Certificate2 ObterDoArrayBytes(byte[] arrayBytes, string senha)
        {
            try
            {
                var certificado = new X509Certificate2(arrayBytes, senha, X509KeyStorageFlags.MachineKeySet);
                return certificado;
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaCertificadoDigitalException("Não foi possivel converter o stream para o certificado.", ex); 
            }
        }

        /// <summary>
        ///     Obtém um objeto <see cref="X509Certificate2" /> pelo serial passado no parÂmetro
        /// </summary>
        /// <param name="serial">
        ///     Numero serial.
        /// </param>
        /// <param name="opcoesDeAbertura">
        ///     Opções de Abertura.
        /// </param>
        /// <returns>
        /// </returns>
        private static X509Certificate2 ObterDoRepositorio(string serial, OpenFlags opcoesDeAbertura)
        {
            if (string.IsNullOrEmpty(serial))
                throw new ArgumentException("O número de série do certificado digital não foi informado!");
            X509Certificate2 certificado = null;
            var store = ObterX509Store(opcoesDeAbertura);
            try
            {
                foreach (var item in store.Certificates)
                    if (item.SerialNumber != null && item.SerialNumber.ToUpper().Equals(serial?.ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                        certificado = item;
                if (certificado == null)
                    throw new Exception(string.Format("Certificado digital nº {0} não encontrado!", serial.ToUpper()));
            }
            catch (Exception ex)
            {
                Utils.TraceException(ex);
                throw new FalhaCertificadoDigitalException("Não foi possivel obter certificado digital do repositorio.", ex);
            }
            finally
            {
                store.Close();
            }

            return certificado;
        }

        /// <summary>
        ///     Obtém um objeto <see cref="X509Certificate2" /> pelo serial passado no parâmetro e com opção de definir o PIN
        /// </summary>
        /// <param name="serial"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        private static X509Certificate2 ObterDoRepositorioPassandoPin(string serial, string senha = null)
        {
            var certificado = ObterDoRepositorio(serial, OpenFlags.ReadOnly);
            if (string.IsNullOrEmpty(senha)) return certificado;
            certificado.DefinirPinParaChavePrivada(senha);
            return certificado;
        }

        #endregion

        /// <summary>
        ///     Define o PIN para chave privada de um objeto <see cref="X509Certificate2" /> passado no parâmetro
        /// </summary>
        private static void DefinirPinParaChavePrivada(this X509Certificate2 certificado, string pin)
        {
            if (certificado == null) throw new ArgumentNullException("certificado");
            var key = (RSACryptoServiceProvider)certificado.PrivateKey;
            var providerHandle = IntPtr.Zero;
            var pinBuffer = Encoding.ASCII.GetBytes(pin);
            MetodosNativos.Executar(
                    () => MetodosNativos.CryptAcquireContext(ref providerHandle, key.CspKeyContainerInfo.KeyContainerName, key.CspKeyContainerInfo.ProviderName, key.CspKeyContainerInfo.ProviderType, MetodosNativos.CryptContextFlags.Silent));
            MetodosNativos.Executar(() => MetodosNativos.CryptSetProvParam(providerHandle, MetodosNativos.CryptParameter.KeyExchangePin, pinBuffer, 0));
            MetodosNativos.Executar(() => MetodosNativos.CertSetCertificateContextProperty(certificado.Handle, MetodosNativos.CertificateProperty.CryptoProviderHandle, 0, providerHandle));
        }

        /// <summary>
        ///     Busca o certificado de acordo com o <see cref="TipoCertificado" />
        /// </summary>
        /// <returns></returns>
        private static X509Certificate2 ObterDadosCertificado(CertificadoConfig configuracaoCertificado)
        {
            switch (configuracaoCertificado.TipoCertificado)
            {
                case TipoCertificado.A1Repositorio:
                    return ObterDoRepositorio(configuracaoCertificado.Serial, OpenFlags.MaxAllowed);
                case TipoCertificado.A1ByteArray:
                    return ObterDoArrayBytes(configuracaoCertificado.ArrayBytesArquivo, configuracaoCertificado.Senha);
                case TipoCertificado.A1Arquivo:
                    return ObterDeArquivo(configuracaoCertificado.Arquivo, configuracaoCertificado.Senha);
                case TipoCertificado.A3:
                    return ObterDoRepositorioPassandoPin(configuracaoCertificado.Serial, configuracaoCertificado.Senha);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }

    internal static class MetodosNativos
    {
        internal enum CryptContextFlags
        {
            None = 0,

            Silent = 0x40
        }

        internal enum CertificateProperty
        {
            None = 0,

            CryptoProviderHandle = 0x1
        }

        internal enum CryptParameter
        {
            None = 0,

            KeyExchangePin = 0x20
        }

        #region  Metodos

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptAcquireContext(ref IntPtr hProv, string containerName, string providerName, int providerType, CryptContextFlags flags);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CryptSetProvParam(IntPtr hProv, CryptParameter dwParam, [In] byte[] pbData, uint dwFlags);

        [DllImport("CRYPT32.DLL", SetLastError = true)]
        internal static extern bool CertSetCertificateContextProperty(IntPtr pCertContext, CertificateProperty propertyId, uint dwFlags, IntPtr pvData);

        public static void Executar(Func<bool> action)
        {
            if (!action()) throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        #endregion
    }

    
}