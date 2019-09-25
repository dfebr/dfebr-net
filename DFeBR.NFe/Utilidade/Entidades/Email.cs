// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Entidades
{
    #region

    #endregion

    /// <summary>
    ///     The email.
    /// </summary>
    public class Email
    {
        #region Propriedades

        public string TimeOut { get; set; }

        public string Porta { get; set; }

        public string ServidorEmail { get; set; }

        public bool UsarSsl { get; set; }

        public bool UsarTls { get; set; }

        public bool UsarAutenticacao { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string EmailRemetente { get; set; }

        public string NomeRemetente { get; set; }

        public List<string> EmailDestinatario { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public string Titulo { get; set; }

        public List<byte[]> Anexos { get; set; }

        #endregion
    }
}