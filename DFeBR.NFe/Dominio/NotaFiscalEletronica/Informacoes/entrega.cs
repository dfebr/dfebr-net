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

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes
{
    public class entrega
    {
        #region Propriedades

        /// <summary>
        ///     G02 - CNPJ
        /// </summary>
        public string CNPJ
        {
            get { return cnpj; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cpf))
                    cnpj = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     G02a - CPF
        /// </summary>
        public string CPF
        {
            get { return cpf; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cnpj))
                    cpf = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     G02b - Razão Social ou Nome do recebedor
        /// </summary>
        public string xNome { get; set; }

        /// <summary>
        ///     G03 - Logradouro
        /// </summary>
        public string xLgr { get; set; }

        /// <summary>
        ///     G04 - Número
        /// </summary>
        public string nro { get; set; }

        /// <summary>
        ///     G05 - Complemento
        /// </summary>
        public string xCpl { get; set; }

        /// <summary>
        ///     G06 - Bairro
        /// </summary>
        public string xBairro { get; set; }

        /// <summary>
        ///     G07 - Código do município
        ///     <para>Código do município (utilizar a tabela do IBGE), informar 9999999 para operações com o exterior.</para>
        /// </summary>
        public long cMun { get; set; }

        /// <summary>
        ///     G08 - Nome do município, informar EXTERIOR para operações com o exterior.
        /// </summary>
        public string xMun { get; set; }

        /// <summary>
        ///     G09 - Sigla da UF, informar EX para operações com o exterior.
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        ///     G10 - Código do CEP, informar zeros não significativos.
        /// </summary>
        public long CEP { get; set; }


        public string ProxyCEP
        {
            get
            {
                return CEP.ToString("D8");
            }
            set
            {
                CEP = long.Parse(value);
            }
        }

        /// <summary>
        ///     G11 - Código do País, informar tabela do BACEN.
        /// </summary>
        public int? cPais { get; set; }


        public bool cPaisSpecified { get { return cPais.HasValue; } }

        /// <summary>
        ///     G12 - Nome do País.
        /// </summary>
        public string xPais { get; set; }

        /// <summary>
        ///     G13 - Telefone. Informar DDD + Telefone. Para exterior usar código do país + código localidade + telefone.
        /// </summary>
        public string fone { get; set; }

        /// <summary>
        ///     G14 - E-mail do recebedor.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        ///     G15 - I.E. do recebedor, sem caracteres de formatação.
        /// </summary>
        public string IE { get; set; }

        private const string ErroCpfCnpjPreenchidos = "Somente preencher um dos campos: CNPJ ou CPF, para um objeto do tipo entrega!";

        #endregion

        #region Variaveis Globais

        private string cnpj;
        private string cpf;

        #endregion
    }
}