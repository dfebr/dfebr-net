// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Marcos Vinícius e-mail: marcos8154@gmail.com
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
        /// <summary>
    ///     Tipo de documento a ser utilizado na consulta de cadastro.
    ///     <para>Ie - Inscrição Estadual</para>
    ///     <para>Cnpj - CNPJ</para>
    ///     <para>Cpf - CPF</para>
    /// </summary>
    public enum ConsultaCadastroTipoDocumento
    {
        Ie = 0,
        Cnpj = 1,
        Cpf = 2
    }

}