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

using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Inutilizacao;
using DFeBR.EmissorNFe.Servicos.Interfaces;

#endregion

namespace DFeBR.EmissorNFe.Servicos.Retornos
{
    internal class RetInut : IRetInut
    {
        #region Propriedades

        /// <summary>
        ///     Retorno
        /// </summary>
        public retInutNFe Retorno { get; set; }

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

        public RetInut()
        {
                
        }
        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public RetInut(retInutNFe retorno, string xmlRecebido, int processadas, int rejeitadas, string xmlEnviado)
        {
            Retorno = retorno;
            XmlRecebido = xmlRecebido;
            Processadas = processadas;
            Rejeitadas = rejeitadas;
            XmlEnviado = xmlEnviado;    
        }
    }
}