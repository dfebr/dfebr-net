using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Builders.ResponsavelTecnico
{
    public abstract class ResponsavelTecNFe
    {
        internal respTec Responsavel { get; set; }

        protected void SetResponsavel(respTec resp)
        {
            Responsavel = resp;
        }
    }
}
