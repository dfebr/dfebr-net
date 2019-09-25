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
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Entidades
{
    public class CertificadoConfig
    {
        #region Propriedades

        /// <summary>
        ///     Tipo de certificado a ser usado
        /// </summary>
        public TipoCertificado TipoCertificado
        {
            get => _tipoCertificado;
            set
            {
                Serial = null;
                Arquivo = null;
                Senha = null;
                ArrayBytesArquivo = null;
                _tipoCertificado = value;
            }
        }

        /// <summary>
        ///     Nº de série do certificado digital
        /// </summary>
        public string Serial
        {
            get => _serial;
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado == TipoCertificado.A1Arquivo)
                    throw new Exception(
                            $"Para {TipoCertificado.Descricao()} o {this.ObterPropriedadeInfo(c => c.Serial).Name} não deve ser informado.");
                if (value == _serial) return;
                _serial = value;
                if (!string.IsNullOrEmpty(value))
                    Arquivo = null;
            }
        }

        /// <summary>
        ///     Array de bytes do certificado
        /// </summary>
        public byte[] ArrayBytesArquivo
        {
            get => _arrayBytesArquivo;
            set
            {
                if (value == _arrayBytesArquivo) return;
                _arrayBytesArquivo = value;
            }
        }


        /// <summary>
        ///     Arquivo do certificado digital
        /// </summary>
        public string Arquivo
        {
            get => _arquivo;
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado != TipoCertificado.A1Arquivo)
                    throw new Exception(
                            $"Para {TipoCertificado.Descricao()} o {this.ObterPropriedadeInfo(c => c.Arquivo).Name} não deve ser informado!");
                if (value == _arquivo) return;
                _arquivo = value;
                if (!string.IsNullOrEmpty(value))
                    Serial = null;
            }
        }

        /// <summary>
        ///     Senha do certificado digital
        ///     <para>
        ///         Informe a senha se desejar que o usuário não precise digitá-la toda vez que for iniciada uma nova instância da
        ///         aplicação.
        ///         Não informe a senha para certificado A1, exceto se configurar para usar o arquivo .pfx usando o atributo
        ///         <see cref="Arquivo" />
        ///     </para>
        /// </summary>
        public string Senha
        {
            get => _senha;
            set
            {
                if (!string.IsNullOrEmpty(value) && TipoCertificado == TipoCertificado.A1Repositorio)
                    throw new Exception(string.Format("Para {0} o {1} não deve ser informada!", TipoCertificado.Descricao(),
                            this.ObterPropriedadeInfo(c => c.Senha).Name));
                if (value == _senha) return;
                _senha = value;
            }
        }

        /// <summary>
        ///     Id do certificado no cache do Zeus
        /// </summary>
        public string CacheId
        {
            get => _cacheId;
            set
            {
                if (value == _cacheId) return;
                _cacheId = value;
            }
        }

        /// <summary>
        ///     Manter/Não manter os dados do certificado em Cache, enquanto a aplicação que consome a biblioteca estiver aberta
        ///     <para>
        ///         Manter os dados do certificado em cache, aumentará o desempenho no consumo dos serviços, especialmente para
        ///         certificados A3
        ///     </para>
        /// </summary>
        public bool ManterDadosEmCache { get; set; }


        /// <summary>
        ///     Algoritmo de Assinatura (Padrao: http://www.w3.org/2000/09/xmldsig#rsa-sha1)
        /// </summary>
        public string SignatureMethodSignedXml { get; set; }


        /// <summary>
        ///     URI para DigestMethod na Classe Reference para auxiliar para a assinatura (Padrao:
        ///     http://www.w3.org/2000/09/xmldsig#sha1)
        /// </summary>
        public string DigestMethodReference { get; set; }

        #endregion

        private string _arquivo;
        private byte[] _arrayBytesArquivo;
        private string _cacheId;
        private string _senha;
        private string _serial;
        private TipoCertificado _tipoCertificado;

        #region  Metodos

        #endregion
    }
}