using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual.Tipos;

namespace DFeBR.EmissorNFe.Builders.Detalhe
{
    public abstract class DetalheNFe
    {
        internal det Det { get; private set; }

        protected void SetDetalhe(det det)
        {
            Det = det;
            det.imposto = new imposto();
        }

        internal void Validar()
        {

        }

        protected void InformarICMS(ICMSBasico icms)
        {
            Det.imposto.ICMS = new ICMS
            {
                TipoICMS = icms
            };
        }
    };
    
}
