using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Destinatario
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; }
        /// <summary>
        /// /
        /// </summary>
        public string CnpjCpf { get; }
        /// <summary>
        ///     Inscrição estadual
        /// </summary>
        public string Ie { get; }

        public Endereco Endereco { get; }


       /// <summary>
       /// NFe
       /// </summary>
       /// <param name="nome">Nome</param>
       /// <param name="cnpjCpf">CPF ou CNPJ</param>
       /// <param name="ie">Inscrição estadual</param>
       /// <param name="endereco">Endereço</param>
        public Destinatario(string nome, string cnpjCpf, string ie, Endereco endereco)
        {
            Nome = nome;
            CnpjCpf = cnpjCpf;
            Ie = ie;
            Endereco = endereco;    
        }

       /// <summary>
       /// NFCe
       /// </summary>
       /// <param name="nome">Nome</param>
       /// <param name="cnpjCpf">CPF ou CNPJ</param>
       /// <param name="ie">Inscrição estadual</param>
       /// <param name="endereco">Endereço</param>
       public Destinatario(string nome, string cnpjCpf,Endereco endereco)
       {
           Nome = nome;
           CnpjCpf = cnpjCpf; 
           Endereco = endereco;
       }

    }
}
