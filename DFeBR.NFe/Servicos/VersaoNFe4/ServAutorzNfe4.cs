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

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Servicos.Templates;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Servicos.VersaoNFe4
{
    internal class ServAutorzNfe4 : ServAutorzTemplate
    {
        
        #region Construtor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emissorServicoConfig">Configuracoes do Emissor</param>
        /// <param name="certificado">Certificado Digital</param>
        /// <param name="versao">Versão do serviço</param>
        /// <param name="compactarMensagem">True, compacta mensagem</param>
        /// <param name="idlote">Numero do lote</param>
        /// <param name="nFes"></param> 
        public ServAutorzNfe4(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, int idlote,
                ICollection<NFe> nFes, VersaoServico versao,bool compactarMensagem=false)
        :base(emissorServicoConfig,certificado,idlote,nFes,versao,compactarMensagem)

        { 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emissorServicoConfig">Configuracoes do Emissor</param>
        /// <param name="certificado">Certificado Digital</param>
        /// <param name="versao">Versão do serviço</param>
        /// <param name="xml">Uma string xml NFe bem formada</param>
        /// <param name="compactarMensagem">True, compacta mensagem</param>
        public ServAutorzNfe4(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, string xml,VersaoServico versao, bool compactarMensagem=false)
            :base(emissorServicoConfig,certificado,xml,versao,compactarMensagem)
        {
            
        }


        #endregion
          
         
    }
}