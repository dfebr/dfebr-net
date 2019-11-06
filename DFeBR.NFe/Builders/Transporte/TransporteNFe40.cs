using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Transporte;
using System.Collections.Generic;

namespace DFeBR.EmissorNFe.Builders.Transporte
{
    public class TransporteNFe40 : TransporteNFe
    {
        public TransporteNFe40(ModalidadeFrete? modFrete, string vagao,
            string balsa)
        {
            SetTransporte(new transp
            {
                modFrete = modFrete,
                vagao = vagao,
                balsa = balsa
            });
        }

        public TransporteNFe AddVolume(int? qVol, string esp,
            string marca, string nVol, decimal? pesoL,
            decimal? pesoB, List<lacres> lacres)
        {
            //Impl. Validacoes
            AddVol(new vol
            {
                qVol = qVol,
                esp = esp,
                marca = marca,
                nVol = nVol,
                pesoL = pesoL,
                pesoB = pesoB,
                lacres = lacres
            });

            return this;
        }

        public TransporteNFe SetTransportadora(string cnpj,
            string cpf, string xNome, string ie, string xEnder,
            string xMun, string uf)
        {
            //Impl. validacoes
            SetTransporta(new transporta
            {
                CNPJ = cnpj,
                CPF = cpf,
                xNome = xNome,
                IE = ie,
                xEnder = xEnder,
                xMun = xMun,
                UF = uf
            });

            return this;
        }
    }
}
