using DFeBR.EmissorNFe.Builders;
using DFeBR.EmissorNFe.Builders.Cobranca;
using DFeBR.EmissorNFe.Builders.Destinatario;
using DFeBR.EmissorNFe.Builders.Detalhe;
using DFeBR.EmissorNFe.Builders.Identificacao;
using DFeBR.EmissorNFe.Builders.Pagamento;
using DFeBR.EmissorNFe.Builders.ResponsavelTecnico;
using DFeBR.EmissorNFe.Builders.Total;
using DFeBR.EmissorNFe.Builders.Transporte;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Servicos.Interfaces;
using DFeBR.EmissorNFe.Servicos.Templates;
using DFeBR.EmissorNFe.Servicos.VersaoNFe4;
using System.Collections.Generic;

namespace UnitTest
{
    public class EmissaoNFeBuilderTest
    {
        private EmissorServicoConfig GetConfig()
        {
            var config = new EmissorServicoConfig();
            config.ConfiguraEmitente();
            .....
            return config;
        }

        private DetalheNFe40 GetDetalhe()
        {
            var detalhe = new DetalheNFe40(....);
            detalhe.SetICMS20(....);
            detalhe.SetIPI(....);
            detalhe.SetPISOutr(....);
            detalhe.SetII(...);
            detalhe.SetCOFINSOutr(...);

            return detalhe;
        }

        private TransporteNFe40 GetTransporte()
        {
            var transp = new TransporteNFe40(....);
            transp.SetTransportadora(....);
            transp.AddVolume(.....);
            return transp;
        }

        private CobrancaNFe40 GetCobranca()
        {
            var cobr = new CobrancaNFe40(,);
            cobr.AddDuplicata(,);
           
            return cobr;
        }

        private PagamentoNFe40 GetPagamento()
        {
            var pag = new PagamentoNFe40(..);
            pag.AdicionaDetalhe(....);
            pag.AdicionaDetalheCartao(.....);
            return pag;
        }

        public void EmitirNFeComBuilder()
        {
            NFeBuilder builder = new NFeBuilder(GetConfig());
            builder.SetIdentificacao(new IdentificacaoNFe40());
            builder.SetDestinatario(new DestinatarioNFe40());
            builder.AddDetalhe(GetDetalhe());
            builder.SetTotal(new TotalNFe40(.....));
            builder.SetTransporte(GetTransporte());
            builder.SetCobranca(GetCobranca());
            builder.AddPagamento(GetPagamento());
            builder.SetResponsavel(new ResponsavelTecNFe40(....));

            var servNfe = new ServNFe4(GetConfig());
            servNfe.Autorizar(1, new List<NFeBuilder> { builder });
        }
    }
}
