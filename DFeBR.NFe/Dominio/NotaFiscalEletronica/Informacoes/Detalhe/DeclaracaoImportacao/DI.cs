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
using System.Collections.Generic;
using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.DeclaracaoImportacao
{
    public class DI
    {
        #region Propriedades

        /// <summary>
        ///     I19 - Número do Documento de Importação (DI, DSI, DIRE, ...)
        /// </summary>
        public string nDI { get; set; }

        /// <summary>
        ///     I20 - Data de Registro do documento.
        /// </summary>
        [XmlIgnore]
        public DateTime dDI { get; set; }

        /// <summary>
        ///     Proxy para dDI no formato AAAA-MM-DD
        /// </summary>
        [XmlElement(ElementName = "dDI")]
        public string ProxydDI
        {
            get { return dDI.ParaDataString(); }
            set { dDI = DateTime.Parse(value); }
        }

        /// <summary>
        ///     I21 - Local de desembaraço
        /// </summary>
        public string xLocDesemb { get; set; }

        /// <summary>
        ///     I22 - Sigla da UF onde ocorreu o Desembaraço Aduaneiro
        /// </summary>
        public string UFDesemb { get; set; }

        /// <summary>
        ///     I23 - Data do Desembaraço Aduaneiro.
        /// </summary>
        [XmlIgnore]
        public DateTime dDesemb { get; set; }

        /// <summary>
        ///     Proxy para dDesemb no formato AAAA-MM-DD
        /// </summary>
        [XmlElement(ElementName = "dDesemb")]
        public string ProxydDesemb
        {
            get { return dDesemb.ParaDataString(); }
            set { dDesemb = DateTime.Parse(value); }
        }

        /// <summary>
        ///     I23a - Via de transporte internacional informada na Declaração de Importação (DI)
        /// </summary>
        public TipoTransporteInternacional tpViaTransp { get; set; }

        /// <summary>
        ///     I23b - Valor da AFRMM - Adicional ao Frete para Renovação da Marinha Mercante
        /// </summary>
        public decimal? vAFRMM
        {
            get { return _vAfrmm.Arredondar(2); }
            set { _vAfrmm = value.Arredondar(2); }
        }

        /// <summary>
        ///     I23c - Forma de importação quanto a intermediação
        /// </summary>
        public TipoIntermediacao tpIntermedio { get; set; }

        /// <summary>
        ///     I23d - CNPJ do adquirente ou do encomendante
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     I23e - Sigla da UF do adquirente ou do encomendante
        /// </summary>
        public string UFTerceiro { get; set; }

        /// <summary>
        ///     I24 - Código do Exportador
        /// </summary>
        public string cExportador { get; set; }

        /// <summary>
        ///     I25 - Adições
        /// </summary>
        [XmlElement("adi")]
        public List<adi> adi { get; set; }

        #endregion

        #region Variaveis Globais

        private decimal? _vAfrmm;

        #endregion

        public bool ShouldSerializevAFRMM()
        {
            return vAFRMM.HasValue;
        }
    }
}