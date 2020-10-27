namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfCIOT
    {
        /// <summary>
        /// Código Identificador da Operação de Transporte
        /// </summary>
        public string CIOT { get; set; }

        /// <summary>
        /// Número do CPF responsável pela geração do CIOT
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Número do CNPJ responsável pela geração do CIOT
        /// </summary>
        public string CNPJ { get; set; }
    }
}