// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:11/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;
using DFeBR.EmissorNFe.Servicos.Templates;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Servicos.VersaoNFe4
{
    internal class ServCancNfe4 : ServCancTemplate
    {
        #region Construtor

        public ServCancNfe4(EmissorServicoConfig emissorServicoConfig, X509Certificate2 certificado, int idlote,
                ICollection<EventoBuilder> eventoBuilder, VersaoServico versao, ModeloDocumento modelo = ModeloDocumento.NFe) : base(
                emissorServicoConfig, certificado, idlote, eventoBuilder, versao, modelo)
        {
        }

        #endregion
    }
}