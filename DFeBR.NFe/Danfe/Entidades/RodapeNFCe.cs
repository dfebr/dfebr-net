// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class RodapeNFCe
    {
        #region Propriedades

        /// <summary>
        ///     Numero de protocolo
        /// </summary>
        public string NumProt { get; set; }

        /// <summary>
        ///     ZX02 - Texto com o QR-Code impresso no DANFE NFC-e
        ///     O atributo qrCode deve ser serializado como CDATA, conforme NT2015.002, V141, regra ZX02-22
        /// </summary>
        public string StrQrCode { get; set; }

        /// <summary>
        /// Crédito do emissor
        /// </summary>
        public string Creditos { get; set; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public RodapeNFCe(string numProt, string strQrCode, string creditos)
        {
            NumProt = numProt;
            StrQrCode = strQrCode;
            Creditos = creditos;    
        }
    }
}