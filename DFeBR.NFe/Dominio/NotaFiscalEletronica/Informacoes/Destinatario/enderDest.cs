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
using System.Linq;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Destinatario
{
    public class enderDest
    {
        #region Propriedades

        /// <summary>
        ///     E06 - Logradouro
        /// </summary>
        public string xLgr { get; set; }

        /// <summary>
        ///     E07 - Número
        /// </summary>
        public string nro { get; set; }

        /// <summary>
        ///     E08 - Complemento
        /// </summary>
        public string xCpl { get; set; }

        /// <summary>
        ///     E09 - Bairro
        /// </summary>
        public string xBairro { get; set; }

        /// <summary>
        ///     E10 - Código do município
        ///     <para>Código do município (utilizar a tabela do IBGE), informar 9999999 para operações com o exterior.</para>
        /// </summary>
        public long cMun { get; set; }

        /// <summary>
        ///     E11 - Nome do município, informar EXTERIOR para operações com o exterior.
        /// </summary>
        public string xMun { get; set; }

        /// <summary>
        ///     E12 - Sigla da UF, informar EX para operações com o exterior.
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        ///     E13 - Código do CEP
        ///     <para>Informar os zeros não significativos. (NT 2011/004)</para>
        /// </summary>
        public string CEP
        {
            get { return _cep; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Replace("-", "");
                    if (!value.All(char.IsDigit))
                        throw new Exception(@"enderDest\CEP deve receber somente números!");
                    if (value.Length != 8)
                        throw new Exception(string.Format(@"enderDest\CEP deve ter 8 números. Tamanho informado: {0}!", value.Length));
                }

                _cep = value;
            }
        }

        /// <summary>
        ///     E14 - Código do País
        ///     <para>1058 - Brasil</para>
        /// </summary>
        public int? cPais { get; set; }

        /// <summary>
        ///     E15 - Nome do País
        ///     <para>Brasil ou BRASIL</para>
        /// </summary>
        public string xPais { get; set; }

        /// <summary>
        ///     E16 - Telefone
        ///     <para>
        ///         Preencher com o Código DDD + número do telefone. Nas operações com exterior é permitido informar o código do
        ///         país + código da localidade + número do telefone (v.2.0)
        ///     </para>
        /// </summary>
        public long? fone { get; set; }

        #endregion

        #region Variaveis Globais

        private string _cep;

        #endregion

        public bool ShouldSerializecPais()
        {
            return cPais.HasValue;
        }

        public bool ShouldSerializefone()
        {
            return fone.HasValue;
        }

        public bool ShouldSerializexCpl()
        {
            return !string.IsNullOrEmpty(xCpl);
        }
    }
}