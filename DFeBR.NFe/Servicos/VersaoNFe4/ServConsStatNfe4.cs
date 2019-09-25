// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:24/04/2019
// Todos os direitos reservados
// =============================================================


#region

using System.Security.Cryptography.X509Certificates;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Servicos.Templates;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Servicos.VersaoNFe4
{
    internal class ServConsStatNfe4 : ServConsStatTemplate
    {
        #region Construtor

        public ServConsStatNfe4(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado,VersaoServico versao,ModeloDocumento modelo=ModeloDocumento.NFe)
        :base(emissorServicoConfig,certificado,versao,modelo)
        {
                
        } 

        #endregion
       
    }
}