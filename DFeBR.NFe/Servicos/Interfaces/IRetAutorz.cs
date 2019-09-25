// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:07/05/2019
// Todos os direitos reservados
// ===================================================================


using DFeBR.EmissorNFe.Danfe;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Autorizacao;

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IRetAutorz:IRetBasico
    {
        /// <summary>
        /// Emissor em ambiente de contigência
        /// </summary>
        bool Contigencia { get; }
        /// <summary>
        ///     Retorno
        /// </summary>
        retEnviNFe Retorno { get; set; }
        /// <summary>
        /// String Html do DANFE
        /// </summary>
        //string Danfe { get; }
         
    }
}