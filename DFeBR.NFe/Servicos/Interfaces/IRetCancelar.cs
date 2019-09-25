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


using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IRetCancelar:IRetBasico
    {
        retEnvEvento Retorno { get; set; }

    }
}