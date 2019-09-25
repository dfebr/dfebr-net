// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Emitente
{
    public class emit
    {
        #region Propriedades

        /// <summary>
        ///     C02 - CNPJ do emitente
        /// </summary>
        public string CNPJ
        {
            get { return _cnpj; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(_cpf))
                    _cnpj = Regex.Match(value, @"\d+").Value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     C02a - CPF do remetente
        /// </summary>
        public string CPF
        {
            get { return _cpf; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(_cnpj))
                    _cpf = Regex.Match(value, @"\d+").Value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     C03 - Razão Social ou Nome do emitente
        /// </summary>
        public string xNome { get; set; }

        /// <summary>
        ///     C04 - Nome fantasia
        /// </summary>
        public string xFant { get; set; }

        /// <summary>
        ///     C05 - Grupo do Endereço do emitente
        /// </summary>
        public enderEmit enderEmit { get; set; }

        /// <summary>
        ///     C17 - Inscrição Estadual
        ///     <para>Campo de informação obrigatória nos casos de emissão própria (procEmi = 0, 2 ou 3).</para>
        ///     <para>
        ///         A IE deve ser informada apenas com algarismos para destinatários contribuintes do ICMS, sem caracteres de
        ///         formatação (ponto, barra, hífen, etc.);
        ///     </para>
        ///     <para>
        ///         O literal “ISENTO” deve ser informado apenas para contribuintes do ICMS que são isentos de inscrição no
        ///         cadastro de contribuintes do ICMS e estejam emitindo NF-e avulsa;
        ///     </para>
        /// </summary>
        public string IE { get; set; }

        /// <summary>
        ///     C18 - IE do Substituto Tributário
        ///     <para>Informar a IE do ST da UF de destino da mercadoria, quando houver a retenção do ICMS ST para a UF de destino.</para>
        /// </summary>
        public string IEST { get; set; }

        /// <summary>
        ///     C19 - Inscrição Municipal
        ///     <para>
        ///         Este campo deve ser informado, quando ocorrer a emissão de NF-e conjugada, com prestação de serviços sujeitos
        ///         ao ISSQN e fornecimento de peças sujeitos ao ICMS.
        ///     </para>
        /// </summary>
        public string IM { get; set; }

        /// <summary>
        ///     C20 - CNAE fiscal
        ///     <para>Este campo deve ser informado quando o campo IM (C19) for informado.</para>
        /// </summary>
        public string CNAE { get; set; }

        /// <summary>
        ///     C21 - Código de Regime Tributário
        /// </summary>
        public CRT CRT { get; set; }

        private const string ErroCpfCnpjPreenchidos = "Somente preencher um dos campos: CNPJ ou CPF, para um objeto do tipo emit!";

        #endregion

        #region Variaveis Globais

        private string _cnpj;
        private string _cpf;

        #endregion

        //public void SetEndereco(string xLgr,
        //    string nro, string xCpl, string xBairro,
        //    long cMun, string xMun, string uf,
        //    string cep, long? fone)
        //{   
        //    enderEmit = new enderEmit()
        //    {
        //        xLgr = xLgr,
        //        nro = nro,
        //        xCpl = xCpl,
        //        xBairro = xBairro,
        //        cMun = cMun,
        //        xMun = xMun,
        //        UF = uf,
        //        cPais = 1058,
        //        xPais = "Brasil",
        //        fone = fone
        //    };
        //}
    }
}