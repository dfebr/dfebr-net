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
    public class detEvento
    {
        #region Propriedades

        /// <summary>
        ///     HP18 - Versão do Pedido de Cancelamento, da carta de correção ou EPEC, deve ser informado com a mesma informação da
        ///     tag verEvento (HP16)
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     HP19 - "Cancelamento", "Carta de Correção", "Carta de Correcao" ou "EPEC"
        /// </summary>
        public string descEvento { get; set; }

        #endregion

        #region Cancelamento

        private string _nprot;

        /// <summary>
        ///     HP20 - Informar o número do Protocolo de Autorização da NF-e a ser Cancelada.
        /// </summary>
        public string nProt
        {
            get { return _nprot; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                descEvento = "Cancelamento";
                LimpaDadosCartaCorrecao();
                LimpaDadosEpec();
                _nprot = value;
            }
        }

        private string _xjust;

        /// <summary>
        ///     HP21 - Informar a justificativa do cancelamento
        /// </summary>
        public string xJust
        {
            get { return _xjust; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                descEvento = "Cancelamento";
                LimpaDadosCartaCorrecao();
                LimpaDadosEpec();
                _xjust = value;
            }
        }

        #endregion

        #region Carta de Correção

        private string _xcorrecao;

        /// <summary>
        ///     HP20 - Correção a ser considerada, texto livre. A correção mais recente substitui as anteriores.
        /// </summary>
        public string xCorrecao
        {
            get { return _xcorrecao; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                LimpaDadosCancelamento();
                LimpaDadosEpec();
                _xcorrecao = value;
            }
        }

        private string _xconduso;

        /// <summary>
        ///     HP20a - Condições de uso da Carta de Correção
        /// </summary>
        public string xCondUso
        {
            get { return _xconduso; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                _xconduso = value;
            }
        }

        #endregion

        #region EPEC

        private Estado? _cOrgaoAutor;

        /// <summary>
        ///     P20 - Código do Órgão do Autor do Evento.
        ///     Nota: Informar o código da UF do Emitente para este evento.
        /// </summary>
        public Estado? cOrgaoAutor
        {
            get { return _cOrgaoAutor; }
            set
            {
                if (value == null) return;
                descEvento = "EPEC";
                LimpaDadosCancelamento();
                LimpaDadosCartaCorrecao();
                _cOrgaoAutor = value;
            }
        }

        /// <summary>
        ///     P21 - Informar "1=Empresa Emitente" para este evento.
        ///     Nota: 1=Empresa Emitente; 2=Empresa Destinatária;
        ///     3=Empresa; 5=Fisco; 6=RFB; 9=Outros Órgãos.
        /// </summary>
        public TipoAutor? tpAutor { get; set; }

        /// <summary>
        ///     P22 - Versão do aplicativo do Autor do Evento.
        /// </summary>
        public string verAplic { get; set; }

        /// <summary>
        ///     P23 - Data e hora
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset? dhEmi { get; set; }

        /// <summary>
        ///     Proxy para dhEmi no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        [XmlElement(ElementName = "dhEmi")]
        public string ProxyDhEmi
        {
            get { return dhEmi.ParaDataHoraStringUtc(); }
            set { dhEmi = DateTimeOffset.Parse(value); }
        }

        /// <summary>
        ///     P24 - 0=Entrada; 1=Saída;
        /// </summary>
        public TipoNFe? tpNF { get; set; }

        /// <summary>
        ///     P25 - IE do Emitente
        /// </summary>
        public string IE { get; set; }

        /// <summary>
        ///     P26
        /// </summary>
        public dest dest { get; set; }

        public bool ShouldSerializecOrgaoAutor()
        {
            return cOrgaoAutor.HasValue;
        }

        public bool ShouldSerializetpAutor()
        {
            return tpAutor.HasValue;
        }

        public bool ShouldSerializetpNF()
        {
            return tpNF.HasValue;
        }

        private void LimpaDadosCancelamento()
        {
            nProt = "";
            xJust = "";
        }

        private void LimpaDadosCartaCorrecao()
        {
            xCorrecao = "";
            xCondUso = "";
        }

        private void LimpaDadosEpec()
        {
            cOrgaoAutor = null;
            tpAutor = null;
            verAplic = null;
            dhEmi = null;
            tpNF = null;
            IE = null;
            dest = null;
            //vNF = null;
            //vICMS = null;
            //vST = null;
        }

        #endregion
    }
}