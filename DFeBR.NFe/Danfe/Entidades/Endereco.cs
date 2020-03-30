using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
   public class Endereco
    {
        public string NomeEnd { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Num { get; }
        public string Cep { get; }
        public string Uf { get; }
        public string Tel { get; }
        public string Estado { get; }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nomeEnd">Endereço</param>
       /// <param name="bairro">Bairro</param>
       /// <param name="cidade">Cidade</param>
       /// <param name="num">Numero</param>
       /// <param name="cep">CEP</param>
       /// <param name="uf">UF</param>
       /// <param name="tel">Telefone</param>
       /// <param name="estado">Estado</param>
        public Endereco(string nomeEnd, string bairro, string cidade, string num, string cep, string uf, string tel, string estado)
        {
            NomeEnd = nomeEnd;
            Bairro = bairro;
            Cidade = cidade;
            Num = num;
            Cep = cep;
            Uf = uf;
            Tel = tel;
            Estado = estado;    
        }
    }
}
