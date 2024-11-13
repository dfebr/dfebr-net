﻿// =============================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.NFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:26/03/2019
// Todos os direitos reservados
// =============================================================


#region

using System.Xml.Serialization;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Inutilizacao
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class infInutEnv
    {
        #region Propriedades

        /// <summary>
        ///     DP04 - Identificador da TAG a ser assinada formada com Código da UF + Ano (2 posições) + CNPJ + modelo + série +
        ///     nro inicial e nro final precedida do literal “ID”
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        ///     DP05 - Identificação do Ambiente: 1 – Produção / 2 - Homologação
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     DP06 - Serviço solicitado: "INUTILIZAR"
        /// </summary>
        public string xServ { get; set; }

        /// <summary>
        ///     DP07 - Código da UF do solicitante
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     DP08 - Ano de inutilização da numeração
        /// </summary>
        public int ano { get; set; }

        /// <summary>
        ///     DP09 - CNPJ do emitente
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     DP10 - Modelo da NF-e (55)
        /// </summary>
        public ModeloDocumento mod { get; set; }

        /// <summary>
        ///     DP11 - Série da NF-e
        /// </summary>
        public int serie { get; set; }

        /// <summary>
        ///     DP12 - Número da NF-e inicial a ser inutilizada
        /// </summary>
        public int nNFIni { get; set; }

        /// <summary>
        ///     DP13 - Número da NF-e final a ser inutilizada
        /// </summary>
        public int nNFFin { get; set; }

        /// <summary>
        ///     DP14 - Informar a justificativa do pedido de inutilização
        /// </summary>
        public string xJust { get; set; }

        #endregion

        #region Construtor

        public infInutEnv()
        {
            xServ = "INUTILIZAR";
        }

        #endregion
    }
}