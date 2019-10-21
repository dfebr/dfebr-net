using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Pagamento;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Builders.Pagamento
{
    public class PagamentoNFe40 : PagamentoNFe
    {
        public PagamentoNFe40(FormaPagamento tPag, decimal vPag,
            decimal? vTroco)
        {
            SetPagamento(new pag
            {
                tPag = tPag,
                vPag = vPag,
                vTroco = vTroco
            });
        }

        public PagamentoNFe AdicionaDetalhe(IndicadorPagamentoDetalhePagamento indPag,
            FormaPagamento tPag, decimal vPag)
        {
            AddDetalhe(new detPag
            {
                indPag = indPag,
                tPag = tPag,
                vPag = vPag
            });

            return this;
        }

        public PagamentoNFe AdicionaDetalheCartao(IndicadorPagamentoDetalhePagamento indPag,
            FormaPagamento tPag, decimal vPag,
            TipoIntegracaoPagamento tpIntegra, BandeiraCartao tBand,
            string CNPJ, string cAut)
        {
            AddDetalhe(new detPag
            {
                indPag = indPag,
                tPag = tPag,
                vPag = vPag,
                card = new card
                {
                    tpIntegra = tpIntegra,
                    tBand = tBand,
                    CNPJ = CNPJ,
                    cAut = cAut
                }
            });

            return this;
        }
    }
}
