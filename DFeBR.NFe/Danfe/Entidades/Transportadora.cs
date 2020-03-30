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
    public class Transportadora
    {
        #region Propriedades

        public Endereco Endereco { get; set; }

        /// <summary>
        ///     Documento CPF ou CNPJ
        /// </summary>
        public string CnpjCpf { get; set; }

        /// <summary>
        ///     Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        ///     Placa
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        ///     RNTC
        /// </summary>
        public string Rntc { get; set; }

        /// <summary>
        ///     ANTT
        /// </summary>
        public string Antt { get; set; }

        /// <summary>
        ///     Inscrição Estadual
        /// </summary>
        public string Ie { get; set; }

        /// <summary>
        ///     Responsabilidade pelo frete
        ///     <para>Emitente|Destinatário</para>
        /// </summary>
        public string FretePorConta { get; set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <param name="cnpjCpf"></param>
        /// <param name="nome"></param>
        /// <param name="placa"></param>
        /// <param name="rntc"></param>
        /// <param name="antt"></param>
        /// <param name="ie"></param>
        /// <param name="fretePorConta">{Emitente|Destinatário}</param>
        public Transportadora(Endereco endereco, string cnpjCpf, string nome, string placa, string rntc, string antt, string ie, string fretePorConta)
        {
            Endereco = endereco;
            CnpjCpf = cnpjCpf;
            Nome = nome;
            Placa = placa;
            Rntc = rntc;
            Antt = antt;
            Ie = ie;
            FretePorConta = fretePorConta;  
        }
    }
}