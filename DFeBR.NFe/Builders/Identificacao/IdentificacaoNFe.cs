using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Identificacao;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Exceptions;

namespace DFeBR.EmissorNFe.Builders.Identificacao
{
    public abstract class IdentificacaoNFe
    {
        internal ide Ide { get; private set; }

        protected void SetIde(ide ide)
        {
            Ide = ide;
        }
    }
}
