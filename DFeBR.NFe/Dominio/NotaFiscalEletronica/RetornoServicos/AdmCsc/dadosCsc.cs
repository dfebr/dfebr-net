// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.AdmCsc
{
    [Serializable]
    public class dadosCsc
    {
        #region Propriedades

        /// <summary>
        ///     AP07 / AR08 - Número identificador do CSC
        /// </summary>
        public string idCsc { get; set; }

        /// <summary>
        ///     AP08 / AR09 - Código alfanumérico do CSC
        /// </summary>
        public string codigoCsc { get; set; }

        #endregion
    }
}