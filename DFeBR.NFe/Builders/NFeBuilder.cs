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

using DFeBR.EmissorNFe.Builders.Destinatario;
using DFeBR.EmissorNFe.Builders.Detalhe;
using DFeBR.EmissorNFe.Builders.Identificacao;
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
        internal NFe NFe { get; private set; }
        
        public NFeBuilder(EmissorServicoConfig emissorServicoConfig)
        {
            NFe = new NFe();
            NFe.infNFe = new infNFe();
        }
    
        public NFeBuilder SetIdentificacao(IdentificacaoNFe identificacao)
        {
            NFe.infNFe.ide = identificacao.Ide;
            return this;
        }

        public NFeBuilder SetDestinatario(DestinatarioNFe destinatario)
        {
            NFe.infNFe.dest = destinatario.Dest;
            return this;
        }

        public void AddDetalhe(DetalheNFe detalhe)
        {
            NFe.infNFe.det.Add(detalhe.Det);
        }

        public NFeBuilder AddDetalhesRange(List<DetalheNFe> detalhes)
        {
            NFe.infNFe.det.AddRange(detalhes.Select(d => d.Det).ToList());
            return this;
        }
    }
}