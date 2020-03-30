// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores:
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:27/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Imposto
    {
        #region Propriedades

        public decimal BaseCalcIcms { get; set; }

        public decimal ValorIcms { get; set; }

        public decimal BaseCalcIcmsSt { get; set; }

        public decimal ValorIcmsSt { get; set; }

        public decimal ValorTotProd { get; set; }

        public decimal ValorFrete { get; set; }

        public decimal ValorSeg { get; set; }

        public decimal Desconto { get; internal set; }

        public decimal Outros { get; set; }

        public decimal ValorIpi { get; internal set; }

        public decimal ValorTotNota { get; set; }

        #endregion
    }
}