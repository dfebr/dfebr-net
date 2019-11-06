using System;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Destinatario;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Exceptions;

namespace DFeBR.EmissorNFe.Builders.Destinatario
{
    public abstract class DestinatarioNFe
    {
        internal dest Dest { get; private set; }
  
        protected void SetDestinatario(dest dest)
        {
            Dest = dest;
        }

        protected void SetEnderecoDestinatario(enderDest ender)
        {
            AssertionConcern.AssertArgumentNotNull(Dest, "O destinatário ainda não foi inicializado");
            Dest.enderDest = ender;
        }
    }
}
