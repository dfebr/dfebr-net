// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:06/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;
using DFeBR.EmissorNFe.Servicos.Interfaces;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Retornos
{
    internal class RetCancelar : IRetCancelar

    {
        #region Propriedades

        public retEnvEvento Retorno { get; set; }

        /// <summary>
        ///     String Xml contendo dados de retorno
        /// </summary>
        public string XmlRecebido { get; set; }

        /// <summary>
        ///     Quantidade de solicitações processadas
        /// </summary>
        public int Processadas { get; set; }

        /// <summary>
        ///     Quantidade de solicitações rejeitadas ou denegadas
        /// </summary>
        public int Rejeitadas { get; set; }

        /// <summary>
        ///     String XML contendo dados enviados
        /// </summary>
        public string XmlEnviado { get; set; }

        #endregion

        public RetCancelar()
        {
                
        }
         
        public RetCancelar(retEnvEvento retorno, string xmlRecebido, int processadas, int rejeitadas, string xmlEnviado)
        {
            Retorno = retorno;
            XmlRecebido = xmlRecebido;
            Processadas = processadas;
            Rejeitadas = rejeitadas;
            XmlEnviado = xmlEnviado;    
        }

    }
}