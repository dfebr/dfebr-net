﻿using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Municipal;
using DFeBR.EmissorNFe.Utilidade;

namespace DFeBR.EmissorNFe.Builders.Detalhe
{
    public abstract class DetalheNFe
    {
        internal det Det { get; private set; }

        protected void SetDetalhe(det det)
        {
            Det = det;
            det.imposto = new imposto();

            Validar();
        }

        internal void Validar()
        {
            AssertionConcern.AssertArgumentEquals(Det.nItem, 0, "O número do item (nItem) deve ser maior que zero. Os itens também deve estar em ordem crescente.");
            AssertionConcern.AssertArgumentNotNullOrEmpty(Det.prod.xProd, "O nome do produto (xProd) é obrigatório");
            AssertionConcern.AssertArgumentNotNullOrEmpty(Det.prod.cEAN, "O Código EAN/GTIN do produto (cEAN) é obrigatório");
            AssertionConcern.AssertArgumentNotNullOrEmpty(Det.prod.NCM, "O NCM é obrigatório");
            AssertionConcern.AssertArgumentEquals(Det.prod.CFOP, 0, "O CFOP é obrigatório");
        }

        protected void InformarICMS(ICMSBasico icms)
        {
            Det.imposto.ICMS = new ICMS
            {
                TipoICMS = icms
            };
        }

        protected void InformarIPI(IPIBasico ipi, string clEnq, int cEnq,
            string cSelo, int qSelo,
            string cnpjProd)
        {
            Det.imposto.IPI = new IPI
            {
                TipoIPI = ipi,
                cEnq = cEnq,
                CNPJProd = cnpjProd,
                clEnq = clEnq,
                cSelo = cSelo,
                qSelo = qSelo
            };
        }

        protected void InformarPIS(PISBasico pis)
        {
            Det.imposto.PIS = new PIS
            {
                TipoPIS = pis
            };
        }

        protected void InformarCOFINS(COFINSBasico cofins)
        {
            Det.imposto.COFINS = new COFINS
            {
                TipoCOFINS = cofins
            };
        }

        protected void InformarII(II ii)
        {
            Det.imposto.II = ii;
        }

        protected void InformarISSQN(ISSQN issqn)
        {
            Det.imposto.ISSQN = issqn;
        }
    };
    
}
