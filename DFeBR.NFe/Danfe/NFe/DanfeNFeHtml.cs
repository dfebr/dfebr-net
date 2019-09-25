// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using DFeBR.EmissorNFe.Danfe.Interfaces;

#endregion

namespace DFeBR.EmissorNFe.Danfe.NFe
{
    public class DanfeNFeHtml : IDanfeHtml
    {
        #region Propriedades

        /// <summary>
        ///     Tipo da DANFE
        /// </summary>
        public string TipoDanfe => "NFe";

        #endregion

        #region Implementacoes

        /// <summary>
        ///     Obter Danfe
        /// </summary>
        /// <returns></returns>
        public Documento ObterDocHtml()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}