namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class DestinatarioNFCe
    {
        /// <summary>
        /// Nome do consumidor
        /// </summary>
        public string NomeConsumidor { get; set; }

        /// <summary>
        /// Numero do documento de identificaçao
        /// </summary>
        public string Doc { get; set; }

        /// <summary>
        ///     Endereço
        /// </summary>
        public string Endereco { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public DestinatarioNFCe(string nomeConsumidor, string doc, string endereco)
        {
            NomeConsumidor = nomeConsumidor;
            Doc = doc;
            Endereco = endereco;    
        }
    }
    
}
