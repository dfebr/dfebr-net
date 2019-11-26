using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cobranca;
using System.Collections.Generic;

namespace DFeBR.EmissorNFe.Builders.Cobranca
{
    public abstract class CobrancaNFe
    {
        internal cobr Cobr { get; private set; }

        protected CobrancaNFe()
        {
            Cobr = new cobr();
            Cobr.dup = new List<dup>();
        }

        protected void SetFatura(fat fatura)
        {
            Cobr.fat = fatura;
        }

        protected void AddDuplic(dup duplicata)
        {
            Cobr.dup.Add(duplicata);
        }
    }
}
