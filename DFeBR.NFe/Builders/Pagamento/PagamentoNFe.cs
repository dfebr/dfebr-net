using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Pagamento;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Builders.Pagamento
{
    public abstract class PagamentoNFe
    {
        internal pag Pag { get; set; }
        
        protected void SetPagamento(pag pag)
        {
            Pag = pag;
        }

        protected void AddDetalhe(detPag det)
        {
            if (Pag.detPag == null)
                Pag.detPag = new List<detPag>();

            Pag.detPag.Add(det);
        }
    }
}