using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Transporte;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFeBR.EmissorNFe.Builders.Transporte
{
    public abstract class TransporteNFe
    {
        internal transp Transp { get; set; }

        protected void SetTransporte(transp transp)
        {
            Transp = transp;
            transp.vol = new List<vol>();
        }

        protected void AddVol(vol vol)
        {
            Transp.vol.Add(vol);
        }

        protected void SetTransporta(transporta transporta)
        { 
            Transp.transporta = transporta;
        }
    }
}
