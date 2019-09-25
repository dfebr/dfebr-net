// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:25/04/2019
// Todos os direitos reservados
// =============================================================


#region

using DFeBR.EmissorNFe.Danfe;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Autorizacao;
using DFeBR.EmissorNFe.Servicos.Interfaces;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Retornos
{
    internal class RetAutorz : IRetAutorz
    {
        #region Propriedades

        /// <summary>
        ///     Retorno
        /// </summary>
        public retEnviNFe Retorno { get; set; }

        /// <summary>
        /// Documento DANFE
        /// </summary>
        //public string Danfe { get; set; }

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

        /// <summary>
        /// Emitida em ambiente de contigência
        /// </summary>
        public bool Contigencia { get; private set; }

        #endregion

        public RetAutorz()
        {
                
        }
        public RetAutorz(retEnviNFe retorno, string xmlRecebido, int processadas, int rejeitadas, string xmlEnviado,bool contigencia)
        {
            Retorno = retorno;
            XmlRecebido = xmlRecebido;
            Processadas = processadas;
            Rejeitadas = rejeitadas;
            XmlEnviado = xmlEnviado;
            Contigencia = contigencia;
        }
    }
}