using System;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Destinatario;

namespace DFeBR.EmissorNFe.Builders.Destinatario
{
    public abstract class DestinatarioNFe
    {
        internal dest Dest { get; private set; }
        internal void Valida()
        {
            //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.xNome, "O nome (xNome) do destinatário não foi informado");
            if (string.IsNullOrEmpty(Dest.CNPJ) && string.IsNullOrEmpty(Dest.CPF))
                throw new InvalidOperationException("Deve ser informado o CNPJ ou CPF do destinatário. Ambos estão ausentes");
            if (string.IsNullOrEmpty(Dest.IE) && string.IsNullOrEmpty(Dest.IM))
                throw new InvalidOperationException("A IE ou a IM do destinatário devem ser informados. Ambos estão ausentes");

            if (Dest.enderDest != null)
            {
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.xLgr, "O logradouro (xLgr) não foi informado");
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.nro, "O número do endereço (nro) não foi informado");
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.xBairro, "O bairro (xBairro) não foi informado");
                //AssertionConcern.AssertArgumentTrue(Dest.enderDest.cMun == 0, "O código do municipio (cMun) não foi informado");
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.xMun, "O nome do município (xMun) não foi informado");
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.uf, "A UF não foi informada");
                //AssertionConcern.AssertArgumentNotNullOrEmpty(Dest.enderDest.cep, "O CEP não foi informado");
            }
        }

        protected void SetDestinatario(dest dest)
        {
            Dest = dest;
            Valida();
        }

        protected void SetEnderecoDestinatario(enderDest ender)
        {
            //AssertionConcern.AssertArgumentNotNull(Dest, "O destinatário ainda não foi inicializado");
            Dest.enderDest = ender;
            Valida();
        }
    }
}
