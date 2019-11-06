using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Cobranca;
using System;

namespace DFeBR.EmissorNFe.Builders.Cobranca
{
    public class CobrancaNFe40 : CobrancaNFe
    {
        public CobrancaNFe40(string nFat, decimal? vOrig,
            decimal? vDesc, decimal vLiq)
        {
            //Impl. Validacoes
            SetFatura(new fat
            {
                nFat = nFat,
                vOrig = vOrig,
                vDesc = vDesc,
                vLiq = vLiq
            });
        }

        public CobrancaNFe AddDuplicata(string nDup,
            DateTime? dVenc, decimal vDup)
        {
            //Impl. Validacoes
            AddDuplic(new dup
            {
                nDup = nDup,
                dVenc = dVenc,
                vDup = vDup
            });
            return this;
        }
    }
}
