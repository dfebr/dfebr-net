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
            Validar();
        }

        internal virtual void Validar()
        {
            if (Ide == null)
                throw new FalhaValidacaoNFeBuilderException("A identificação da NFe não foi inicializada");

            AssertionConcern.AssertArgumentTrue(Ide.cMunFG == 0, "cMunFG - O código do município do fato gerador é inválido");
            AssertionConcern.AssertArgumentNotNullOrEmpty(Ide.cNF, "cNF - O código da NF é inválido");
            AssertionConcern.AssertArgumentTrue(Ide.serie == 0, "serie - A série da NF é inválida");
        }
    }
}
