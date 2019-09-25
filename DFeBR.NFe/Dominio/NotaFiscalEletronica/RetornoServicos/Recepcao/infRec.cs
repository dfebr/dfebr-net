// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Domain
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Marcos Vinicius e-mail: marcos8154@gmail.com 
// Data Criação:04/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Recepcao
{
    public class infRec
    {
        #region Propriedades

        /// <summary>
        ///     AR08 - Número do Recibo gerado pelo Portal da Secretaria de Fazenda Estadual (vide item 5.5).
        /// </summary>
        public string nRec { get; set; }

        /// <summary>
        ///     AR10 - Tempo médio de resposta do serviço (em segundos) dos últimos 5 minutos (vide item 5.7). Nota: Caso o tempo
        ///     médio de resposta fique abaixo de 1 (um) segundo, o tempo será informado como 1 segundo. Arredondar as frações de
        ///     segundos para cima.
        /// </summary>
        public int tMed { get; set; }

        #endregion
    }
}