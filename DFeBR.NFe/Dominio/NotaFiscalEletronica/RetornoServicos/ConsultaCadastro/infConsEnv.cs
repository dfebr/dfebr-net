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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.ConsultaCadastro
{
    public class infConsEnv
    {
        #region Propriedades

        /// <summary>
        ///     GP04 - Serviço solicitado "CONS-CAD"
        /// </summary>
        public string xServ { get; set; }

        /// <summary>
        ///     GP05 - Sigla da UF consultada, informar 'SU' para SUFRAMA.
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        ///     GP06 - Inscrição estadual do contribuinte
        ///     <para>Somente preencher um dos campos: CNPJ, CPF ou IE</para>
        /// </summary>
        public string IE
        {
            get { return _ie; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(CNPJ) & string.IsNullOrEmpty(CPF))
                    _ie = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjIePreenchidos);
                }
            }
        }

        /// <summary>
        ///     GP07 - CNPJ do contribuinte
        ///     <para>Somente preencher um dos campos: CNPJ, CPF ou IE</para>
        /// </summary>
        public string CNPJ
        {
            get { return _cnpj; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(CPF) & string.IsNullOrEmpty(IE))
                    _cnpj = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjIePreenchidos);
                }
            }
        }

        /// <summary>
        ///     GP08 - CPF do contribuinte
        ///     <para>Somente preencher um dos campos: CNPJ, CPF ou IE</para>
        /// </summary>
        public string CPF
        {
            get { return _cpf; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(CNPJ) & string.IsNullOrEmpty(IE))
                    _cpf = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjIePreenchidos);
                }
            }
        }

        private const string ErroCpfCnpjIePreenchidos = "Somente preencher um dos campos: CNPJ, CPF ou IE, para um objeto do tipo infConsEnv!";

        #endregion

        #region Variaveis Globais

        private string _cnpj;
        private string _cpf;
        private string _ie;

        #endregion

        #region Construtor

        public infConsEnv()
        {
            xServ = "CONS-CAD";
        }

        #endregion
    }
}