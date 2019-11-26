using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;

namespace DFeBR.EmissorNFe.Builders.ResponsavelTecnico
{
    public class ResponsavelTecNFe40 : ResponsavelTecNFe
    {
        public ResponsavelTecNFe40(string cnpj, string xContato,
            string email, string fone, int? idCSRT)
        {
            SetResponsavel(new respTec
            {
                CNPJ = cnpj,
                xContato = xContato,
                email = email,
                fone = fone,
                idCSRT = idCSRT
            });
        }
    }
}
