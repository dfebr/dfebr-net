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
    public class CabecalhoNFCe
    {
        #region Propriedades

        /// <summary>
        ///     Nome Fantasia
        /// </summary>
        public string NomeFantasia { get;  }

        /// <summary>
        ///     CNPJ
        /// </summary>
        public string Cnpj { get;  }

        /// <summary>
        ///     Inscrição Estadual
        /// </summary>
        public string Ie { get;  }

        /// <summary>
        ///     Numero do Endereço
        /// </summary>
        public string Numero { get;  }

        /// <summary>
        ///     Endereço
        /// </summary>
        public string Endereco { get;  }

        /// <summary>
        ///     Cidade
        /// </summary>
        public string Cidade { get;  }

        /// <summary>
        ///     Estado
        /// </summary>
        public string Estado { get;  }

        /// <summary>
        ///     CEP
        /// </summary>
        public string Cep { get;  }

        #endregion
         
        public CabecalhoNFCe(string nomeFantasia, string cnpj, string ie, string numero, string endereco, string cidade, string estado, string cep)
        {
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Ie = ie;
            Numero = numero;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;  
        }
    }
}