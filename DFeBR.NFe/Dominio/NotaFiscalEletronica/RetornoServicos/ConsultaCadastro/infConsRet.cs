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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.ConsultaCadastro
{
    public class infConsRet
    {
        #region Propriedades

        /// <summary>
        ///     GR04 - Versão do Aplicativo que processou a consulta.
        ///     A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla SCAN, SVAN ou SVRS nos demais
        ///     casos.
        /// </summary>
        public string verAplic { get; set; }

        /// <summary>
        ///     GR05 - Código do status da resposta.
        /// </summary>
        public int cStat { get; set; }

        /// <summary>
        ///     GR06 - Descrição do Status da resposta.
        /// </summary>
        public string xMotivo { get; set; }

        /// <summary>
        ///     GR06a - Sigla da UF consultada
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        ///     GR06b - Inscrição estadual consultada
        /// </summary>
        public string IE { get; set; }

        /// <summary>
        ///     GR06c - CNPJ consultado
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     GR06d - CPF consultado
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        ///     GR06e - Data e hora de processamento da consulta
        /// </summary>
        [XmlIgnore]
        public DateTime dhCons { get; set; }

        /// <summary>
        ///     Proxy para dhCons no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time)
        /// </summary>
        [XmlElement(ElementName = "dhCons")]
        public string ProxydhCons
        {
            get { return dhCons.ParaDataHoraStringUtc(); }
            set { dhCons = DateTime.Parse(value); }
        }

        /// <summary>
        ///     GR06f - Código da UF que atendeu a solicitação.
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     GR07 - Dados da situação cadastral Esta estrutura existe somente para as consultas realizadas com sucesso
        ///     cStat=111, com possibilidade de múltiplas ocorrências (Ex.: consulta
        ///     por IE de contribuinte com Inscrição Única - retorno de todos os estabelecimentos do contribuinte).
        /// </summary>
        public infCad infCad { get; set; }

        #endregion
    }
}