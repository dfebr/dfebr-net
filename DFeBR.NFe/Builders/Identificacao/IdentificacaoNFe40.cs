using System;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Identificacao;
using DFeBR.EmissorNFe.Utilidade.Tipos;

namespace DFeBR.EmissorNFe.Builders.Identificacao
{
    public sealed class IdentificacaoNFe40 : IdentificacaoNFe
    {
        /// <summary>
        /// Identificação para NFe v4.0
        /// </summary>
        /// <param name="config"></param>
        /// <param name="cNf"></param>
        /// <param name="natOp"></param>
        /// <param name="indPag"></param>
        /// <param name="mod"></param>
        /// <param name="serie"></param>
        /// <param name="nNf"></param>
        /// <param name="dEmi"></param>
        /// <param name="dSaiEnt"></param>
        /// <param name="dhEmi"></param>
        /// <param name="dhSaiEnt"></param>
        /// <param name="tpNf"></param>
        /// <param name="idDest"></param>
        /// <param name="tpImp"></param>
        /// <param name="tpEmis"></param>
        /// <param name="finNFe"></param>
        /// <param name="indFinal"></param>
        /// <param name="indPres"></param>
        /// <param name="versaoProcesso"></param>
        public IdentificacaoNFe40(Configurar config,
            string cNf, string natOp,
            ModeloDocumento mod, int serie, long nNf, DateTime dEmi,
            DateTime dSaiEnt, DateTimeOffset dhEmi, DateTimeOffset dhSaiEnt,
            TipoNFe tpNf, DestinoOperacao idDest, TipoImpressao tpImp,
            TipoEmissao tpEmis, FinalidadeNFe finNFe, ConsumidorFinal indFinal,
            PresencaComprador indPres, string versaoProcesso, DateTime? dhCont = null, string xJust = "")
        {
            SetIde(new ide
            {
                cUF = config.EmissorConfig.Estado,
                cNF = cNf,
                natOp = natOp,
                mod = mod,
                serie = serie,
                nNF = nNf,
                dEmi = dEmi,
                dSaiEnt = dSaiEnt,
                dhEmi = dhEmi,
                dhSaiEnt = dhSaiEnt,
                tpNF = tpNf,
                idDest = idDest,
                cMunFG = config.EmissorConfig.Emitente.enderEmit.cMun,
                tpImp = tpImp,
                tpEmis = tpEmis,
                tpAmb = config.EmissorConfig.Ambiente,
                finNFe = finNFe,
                indFinal = indFinal,
                indPres = indPres,
                verProc = versaoProcesso,
                dhCont = dhCont,
                xJust = xJust
            });
        }
    }
}
