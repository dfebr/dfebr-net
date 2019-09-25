// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:20/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class CorpoNFCe
    {
        #region Propriedades



        /// <summary>
        ///     True, dados enviados em contigência
        /// </summary>
        public bool EmitidaEmContigencia { get; set; }

        /// <summary>
        ///     Número do documento
        /// </summary>
        public string NumeroDocumento { get; set; }

        /// <summary>
        ///     Status da nota
        /// </summary>
        public Status Status { get; set; }
         

        /// <summary>
        ///     Lista de produtos
        /// </summary>
        public ICollection<ProdutoNFCe> Produtos { get; set; }

        /// <summary>
        ///     True, ambiente de produção
        /// </summary>
        public bool Producao { get; set; }

        /// <summary>
        ///     Pagamento
        /// </summary>
        public PagamentoNFCe Pagamento { get; set; }

        /// <summary>
        ///     Dados de impostos
        /// </summary>
        public ImpostosNFCe Imposto { get; set; }

        /// <summary>
        ///     Informaçoes Adicionais
        /// </summary>
        public InfAdicNFCe InfAdicionais { get; set; }

        /// <summary>
        ///     Numero de séria da nota
        /// </summary>
        public string Serie { get; set; }

        /// <summary>
        ///     Data de emissão da nota
        /// </summary>
        public DateTime DataEmissao { get; set; }

        /// <summary>
        ///     Url de consulta
        /// </summary>
        public string UrlConsulta { get; set; }

        /// <summary>
        ///     Chave da nota
        /// </summary>
        public string Chave { get; set; }

        /// <summary>
        ///     Destinatário
        /// </summary>
        public DestinatarioNFCe Destinatario { get; set; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public CorpoNFCe(bool emitidaEmContigencia, string numeroDocumento, Status status, ICollection<ProdutoNFCe> produtos,
                bool producao, PagamentoNFCe pagamento, ImpostosNFCe imposto, InfAdicNFCe infAdicionais, string serie,
                DateTime dataEmissao, string urlConsulta, string chave, DestinatarioNFCe destinatario)
        {
            EmitidaEmContigencia = emitidaEmContigencia;
            NumeroDocumento = numeroDocumento;
            Status = status; 
            Produtos = produtos;
            Producao = producao;
            Pagamento = pagamento;
            Imposto = imposto;
            InfAdicionais = infAdicionais;
            Serie = serie;
            DataEmissao = dataEmissao;
            UrlConsulta = urlConsulta;
            Chave = chave;
            Destinatario = destinatario;    
        }
    }
}