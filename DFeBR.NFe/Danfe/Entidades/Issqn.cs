// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores:
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:22/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Issqn
    {
        #region Propriedades

        /// <summary>
        ///     Inscrição Municipal
        /// </summary>
        public string Im { get; set; }

        /// <summary>
        ///     Valor total dos servicço
        /// </summary>
        public decimal ValorTotServ { get; set; }

        /// <summary>
        ///     Base de calculo
        /// </summary>
        public decimal BaseCalculo { get; set; }

        /// <summary>
        ///     Valor ISSQN
        /// </summary>
        public decimal ValorIssqn { get; set; }

        #endregion
    }
}