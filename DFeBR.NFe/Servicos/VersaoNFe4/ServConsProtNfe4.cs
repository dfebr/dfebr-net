// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:26/04/2019
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
    internal class ServConsProtNfe4 : ServConsProtTemplate
    {
        #region Construtor

        public ServConsProtNfe4(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, string documento,
                VersaoServico versao, DocumentoProtocolo doc, ModeloDocumento modelo = ModeloDocumento.NFe) : base(emissorServicoConfig,
                certificado, documento, doc, versao, modelo)

        {
        }

        #endregion
          
    }
}