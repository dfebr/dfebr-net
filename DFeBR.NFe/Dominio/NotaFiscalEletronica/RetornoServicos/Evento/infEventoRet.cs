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
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento
{
    public class infEventoRet
    {
        #region Propriedades

        /// <summary>
        ///     HR12 - Identificador da TAG a ser assinada
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        ///     HR13 - Identificação do Ambiente: 1=Produção /2=Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     HR14 - Versão da aplicação que registrou o Evento
        /// </summary>
        public string verAplic { get; set; }

        /// <summary>
        ///     HR15 - Código da UF que registrou o Evento. Utilizar 91 para o Ambiente Nacional.
        /// </summary>
        public Estado cOrgao { get; set; }

        /// <summary>
        ///     HR16 - Código do status da resposta.
        /// </summary>
        public int cStat { get; set; }

        /// <summary>
        ///     HR17 - Descrição do status da resposta.
        /// </summary>
        public string xMotivo { get; set; }

        /// <summary>
        ///     HR18 - Chave de Acesso da NF-e vinculada ao evento.
        /// </summary>
        public string chNFe { get; set; }

        /// <summary>
        ///     HR19 - Código do Tipo do Evento.
        /// </summary>
        public int? tpEvento { get; set; }

        /// <summary>
        ///     HR20 - Descrição do Evento – “Cancelamento homologado”
        /// </summary>
         public string xEvento { get; set; }

        /// <summary>
        ///     HR21 - Sequencial do evento para o mesmo tipo de evento.
        /// </summary>
         public int? nSeqEvento { get; set; }

        /// <summary>
        ///     R22 - (EPEC) Idem a mensagem de entrada.
        /// </summary>
        public string cOrgaoAutor { get; set; }

        /// <summary>
        ///     HR22 - CNPJ do destinatário da NFe
        /// </summary>
        public string CNPJDest
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
        ///     HR23 - CPF do destinatário da NFe
        /// </summary>
        public string CPFDest
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
        ///     HR24 - e-mail do destinatário informado na NF-e.
        /// </summary>
        public string emailDest { get; set; }

        /// <summary>
        ///     HR25 - Data e hora de registro do evento. Se o evento for rejeitado informar a data e hora de recebimento do
        ///     evento.
        /// </summary>
        //[XmlIgnore]
         public string dhRegEvento { get; set; }

        ///// <summary>
        /////     Proxy para dhEmi no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        ///// </summary>
        //[XmlElement(ElementName = "dhRegEvento")]
        //public string ProxydhRegEvento
        //{
        //    get { return dhRegEvento.ParaDataHoraStringUtc(); }
        //    set { dhRegEvento = DateTime.Parse(value); }
        //}

        /// <summary>
        ///     HR26 - Número do Protocolo da NF-e
        /// </summary>
        public string nProt { get; set; }

        /// <summary>
        ///     R25 - (EPEC) Relação de Chaves de Acesso de EPEC pendentes de conciliação, existentes no AN.
        /// </summary>
        public string chNFePend { get; set; }

      
        private const string ErroCpfCnpjPreenchidos = "Somente preencher um dos campos: CNPJ ou CPF, para um objeto do tipo infEventoRet!";

        #endregion

        #region Variaveis Globais

        private string cnpj;
        private string cpf;

        #endregion

        public bool ShouldSerializetpEvento()
        {
            return tpEvento.HasValue;
        }

        public bool ShouldSerializenSeqEvento()
        {
            return nSeqEvento.HasValue;
        }
    }
}