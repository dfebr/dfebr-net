
using System.Collections.Generic;

namespace DFeBR.EmissorNFe.Danfe
{
    public class Documento
    {
        /// <summary>
        /// Uma string Html contendo dados da DANFE
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// Uma string contendo script JS
        /// </summary>
        public string Script { get; set; }

        public List<ReplaceJsTags> ReplaceJsTags { get; set; }
    }
}
