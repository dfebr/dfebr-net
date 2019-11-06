using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Total;

namespace DFeBR.EmissorNFe.Builders.Total
{
    public abstract class TotalNFe
    {
        internal ICMSTot IcmsTot { get; set; }

        protected void SetTotal(ICMSTot tot)
        {
            IcmsTot = tot;
        }
    }
}
