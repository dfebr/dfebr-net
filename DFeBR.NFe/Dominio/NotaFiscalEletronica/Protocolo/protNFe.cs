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

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Protocolo
{
    public class protNFe
    {
        #region Propriedades

        /// <summary>
        ///     PR02 - Versão do leiaute das informações de Protocolo.
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     PR03 - Informações do Protocolo de resposta. TAG a ser assinada
        /// </summary>
        [XmlElement("infProt")]
        public   List<infProt> infProt { get; set; }

        #endregion

        #region Construtor

        public protNFe()
        {
            //infProt = new List<infProt>();
        }

        #endregion
    }
}