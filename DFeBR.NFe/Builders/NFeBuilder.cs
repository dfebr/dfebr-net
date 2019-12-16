// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:10/04/2019
// Todos os direitos reservados
// =============================================================


#region

using DFeBR.EmissorNFe.Builders.Cobranca;
using DFeBR.EmissorNFe.Builders.Destinatario;
using DFeBR.EmissorNFe.Builders.Detalhe;
using DFeBR.EmissorNFe.Builders.Identificacao;
using DFeBR.EmissorNFe.Builders.Pagamento;
using DFeBR.EmissorNFe.Builders.ResponsavelTecnico;
using DFeBR.EmissorNFe.Builders.Total;
using DFeBR.EmissorNFe.Builders.Transporte;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace DFeBR.EmissorNFe.Builders
{
    public sealed class NFeBuilder
    {
        public NFe NFe { get; private set; }
        
        public NFeBuilder(EmissorServicoConfig emissorServicoConfig)
        {
            NFe = new NFe();
            NFe.infNFe = new infNFe();
            NFe.infNFe.total = new Dominio.NotaFiscalEletronica.Informacoes.Total.total();

            NFe.infNFe.emit = emissorServicoConfig.Emitente;
        }

        public NFeBuilder SetResponsavel(ResponsavelTecNFe responsavel)
        {
            NFe.infNFe.RespTec = responsavel.Responsavel;
            return this;
        }
    
        public NFeBuilder SetIdentificacao(IdentificacaoNFe identificacao)
        {
            NFe.infNFe.ide = identificacao.Ide;
            return this;
        }

        public NFeBuilder SetTransporte(TransporteNFe transporte)
        {
            NFe.infNFe.transp = transporte.Transp;
            return this;
        }

        public NFeBuilder SetCobranca(CobrancaNFe cobranca)
        {
            NFe.infNFe.cobr = cobranca.Cobr;
            return this;
        }

        public NFeBuilder SetDestinatario(DestinatarioNFe destinatario)
        {
            NFe.infNFe.dest = destinatario.Dest;
            return this;
        }

        public NFeBuilder SetTotal(TotalNFe total)
        {
            NFe.infNFe.total.ICMSTot = total.IcmsTot;
            return this;
        }

        public NFeBuilder AddPagamento(PagamentoNFe pagamento)
        {
            NFe.infNFe.pag.Add(pagamento.Pag);
            return this;
        }

        public NFeBuilder AddPagamentosRange(List<PagamentoNFe> pagamentos)
        {
            pagamentos.ForEach(p => AddPagamento(p));
            return this;
        }

        public NFeBuilder AddDetalhe(DetalheNFe detalhe)
        {
            NFe.infNFe.det.Add(detalhe.Det);
            return this;
        }

        public NFeBuilder AddDetalhesRange(List<DetalheNFe> detalhes)
        {
            detalhes.ForEach(d => AddDetalhe(d));
            return this;
        }
    }
}