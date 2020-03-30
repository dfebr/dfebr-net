using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Emitente
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; }
        /// <summary>
        ///     Inscrição estadual
        /// </summary>
        public string Ie { get; }

        /// <summary>
        ///     Documento CPF ou CNPJ
        /// </summary>
        public string CnpjCpf { get; }
        /// <summary>
        /// Logo empresa Base64
        /// </summary>
        public string Logo { get; }

        public Endereco Endereco { get; }

     /// <summary>
     /// 
     /// </summary>
     /// <param name="nome">Nome</param>
     /// <param name="ie">Inscrição estadual</param>
     /// <param name="cnpjCpf">CPF ou CNPJ</param>
     /// <param name="logo">Imagem em base64</param>
     /// <param name="endereco">Endereço</param>
        public Emitente(string nome, string ie, string cnpjCpf, string logo, Endereco endereco)
        {
            Nome = nome;
            Ie = ie;
            CnpjCpf = cnpjCpf;
            Logo = logo;
            Endereco = endereco;    
        }
    }
}
