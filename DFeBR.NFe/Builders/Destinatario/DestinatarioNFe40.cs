using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Destinatario;

namespace DFeBR.EmissorNFe.Builders.Destinatario
{
    public sealed class DestinatarioNFe40 : DestinatarioNFe
    {
        /// <summary>
        /// Destinatário para NFe v4.0
        /// </summary>
        public DestinatarioNFe40(Configurar config, string cnpj, string cpf, string idEstrangeiro, string nome, indIEDest indIeDest, string ie,
                string isuf, string im, string email)
        {
            SetDestinatario(new dest()
            {
                CNPJ = cnpj,
                CPF = cpf,
                idEstrangeiro = idEstrangeiro,
                xNome = nome,
                indIEDest = indIeDest,
                IE = ie,
                ISUF = isuf,
                IM = im,
                email = email
            });
        }

        public DestinatarioNFe SetEndereco(string xLgr, string nro, string xCpl, string xBairro, long cMun, string xMun, string uf,
                string cep, long? fone)
        {
            SetEnderecoDestinatario(new enderDest
            {
                xLgr = xLgr,
                nro = nro,
                xCpl = xCpl,
                xBairro = xBairro,
                cMun = cMun,
                xMun = xMun,
                UF = uf,
                CEP = cep,
                fone = fone,
                cPais = 1058,
                xPais = "Brasil"
            });

            return this;
        }
    }
}
