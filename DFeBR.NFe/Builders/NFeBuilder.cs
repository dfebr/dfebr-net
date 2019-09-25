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
using DFeBR.EmissorNFe.Builders.Identificacao;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;

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
    
        public void SetIdentificacao(IdentificacaoNFe identificacao)
        {
            NFe.infNFe.ide = identificacao.Ide;
        }

        public void SetDestinatario(DestinatarioNFe destinatario)
        {
            NFe.infNFe.dest = destinatario.Dest;
        }

    }
}