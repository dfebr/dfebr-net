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
    ///     Indicador de Escala Relevante:
    ///     S -  Produzido em Escala Relevante; N – Produzido em Escala NÃO Relevante.
    ///     Versão 4.00
    /// </summary>
    public enum indEscala
    {
        [XmlEnum("S")] S = 'S',
        [XmlEnum("N")] N = 'N'
    }
}