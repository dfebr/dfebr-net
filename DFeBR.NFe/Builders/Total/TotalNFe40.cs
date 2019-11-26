using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Total;

namespace DFeBR.EmissorNFe.Builders.Total
{
    public sealed class TotalNFe40 : TotalNFe
    {
        public TotalNFe40(decimal vBC, decimal vICMS,
            decimal? vICMSDeson, decimal? vFCPUFDest,
            decimal? vICMSUFDest, decimal? vICMSUFRemet,
            decimal? vFCP, decimal vBCST, decimal vST,
            decimal? vFCPST, decimal? vFCPSTRet,
            decimal vProd, decimal vFrete, decimal vSeg,
            decimal vDesc, decimal vII, decimal vIPI,
            decimal? vIPIDevol, decimal vPIS,
            decimal vCOFINS, decimal vOutro, decimal vNF,
            decimal vTotTrib)
        {
            SetTotal(new ICMSTot
            {
                vBC = vBC,
                vICMS = vICMS,
                vICMSDeson = vICMSDeson,
                vFCPUFDest = vFCPUFDest,
                vICMSUFDest = vICMSUFDest,
                vICMSUFRemet = vICMSUFRemet,
                vFCP = vFCP,
                vBCST = vBCST,
                vST = vST,
                vFCPST = vFCPST,
                vFCPSTRet = vFCPSTRet,
                vProd = vProd,
                vFrete = vFrete,
                vSeg = vSeg,
                vDesc = vDesc,
                vII = vII,
                vIPI = vIPI,
                vIPIDevol = vIPIDevol,
                vPIS = vPIS,
                vCOFINS = vCOFINS,
                vOutro = vOutro,
                vNF = vNF,
                vTotTrib = vTotTrib
            });
        }
    }
}
