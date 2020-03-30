using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Fatura
    {
        public string NumFatura { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="numFatura">Numero da fatura</param>
       /// <param name="dataVencimento">Data do vencimento</param>
       /// <param name="valor">Valor</param>
        public Fatura(string numFatura, DateTime dataVencimento, decimal valor)
        {
            NumFatura = numFatura;
            DataVencimento = dataVencimento;
            Valor = valor;
        }
    }
}
