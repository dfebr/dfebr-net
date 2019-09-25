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

using System;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento
{
    public class infEventoEnv
    {
        #region Propriedades

        /// <summary>
        ///     HP07 - Grupo de informações do registro do Evento
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        ///     HP08 - Código do órgão de recepção do Evento.
        /// </summary>
        public Estado cOrgao { get; set; }

        /// <summary>
        ///     HP09 - Identificação do Ambiente: 1=Produção /2=Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     HP10 - CNPJ do autor do Evento
        /// </summary>
        public string CNPJ
        {
            get { return cnpj; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cpf))
                    cnpj = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     HP11 - CPF do autor do Evento
        /// </summary>
        public string CPF
        {
            get { return cpf; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cnpj))
                    cpf = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     HP12 - Chave de Acesso da NF-e vinculada ao Evento
        /// </summary>
        public string chNFe { get; set; }

        /// <summary>
        ///     HP13 - Data e hora do evento
        /// </summary>
        [XmlIgnore]
        public DateTime dhEvento { get; set; }

        /// <summary>
        ///     Proxy para dhEvento no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        [XmlElement(ElementName = "dhEvento")]
        public string ProxydhEvento
        {
            get { return dhEvento.ParaDataHoraStringUtc(); }
            set { dhEvento = DateTime.Parse(value); }
        }

        /// <summary>
        ///     HP14 - Código do evento
        /// </summary>
        public int tpEvento { get; set; }

        /// <summary>
        ///     HP15 - Sequencial do evento para o mesmo tipo de evento.
        /// </summary>
        public int nSeqEvento { get; set; }

        /// <summary>
        ///     HP16 - Versão do detalhe do evento
        /// </summary>
        public string verEvento { get; set; }

        /// <summary>
        ///     HP17 - Informações do Pedido de Cancelamento
        /// </summary>
        public detEvento detEvento { get; set; }

        private const string ErroCpfCnpjPreenchidos = "Somente preencher um dos campos: CNPJ ou CPF, para um objeto do tipo infEventoEnv!";

        #endregion

        #region Variaveis Globais

        private string cnpj;
        private string cpf;

        #endregion
    }
}