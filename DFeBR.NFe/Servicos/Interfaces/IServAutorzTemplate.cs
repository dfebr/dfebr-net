// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Application
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:17/04/2019
// Todos os direitos reservados
// =============================================================


#region

#endregion

using System.Collections.Generic;
using DFeBR.EmissorNFe.Danfe;

namespace DFeBR.EmissorNFe.Servicos.Interfaces
{
    public interface IServAutorzTemplate  
    {
         
        /// <summary>
        /// Nome do serviço
        /// </summary>
        string NomeServico { get; }

        /// <summary>
        ///     Executar
        /// </summary>
        /// <returns></returns>
        IRetAutorz Executar();

        

    }
}