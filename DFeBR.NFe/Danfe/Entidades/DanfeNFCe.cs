#region

using System;
using System.Collections.Generic;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class DanfeNFCe
    {
        #region Propriedades

        public Emitente Emitente { get; }

        /// <summary>
        ///     True, dados enviados em contigência
        /// </summary>
        public bool EmitidaEmContigencia { get; }

        /// <summary>
        ///     Número do documento
        /// </summary>
        public string NumeroDocumento { get; }

        /// <summary>
        ///     Status da nota
        /// </summary>
        public Status Status { get; }


        /// <summary>
        ///     Lista de produtos
        /// </summary>
        public ICollection<ProdutoNFCe> Produtos { get; }

        /// <summary>
        ///     True, ambiente de produção
        /// </summary>
        public bool Producao { get; }

        /// <summary>
        ///     Pagamento
        /// </summary>
        public Pagamento Pagamento { get; }

        /// <summary>
        ///     Dados de impostos IBPT
        /// </summary>
        public string DadosTributos { get; }

        /// <summary>
        ///     Informaçoes Adicionais
        /// </summary>
        public string InfAdicionais { get; }

        /// <summary>
        ///     Numero de séria da nota
        /// </summary>
        public string Serie { get; }

        /// <summary>
        ///     Data de emissão da nota
        /// </summary>
        public DateTime DataEmissao { get; }

        /// <summary>
        ///     Url de consulta
        /// </summary>
        public string UrlConsulta { get; }

        /// <summary>
        ///     Chave da nota
        /// </summary>
        public string Chave { get; }

        /// <summary>
        ///     Destinatário
        /// </summary>
        public Destinatario Destinatario { get; }

        /// <summary>
        ///     Numero de protocolo
        /// </summary>
        public string NumProt { get; }

        /// <summary>
        ///     ZX02 - Texto com o QR-Code impresso no DANFE NFC-e
        ///     O atributo qrCode deve ser serializado como CDATA, conforme NT2015.002, V141, regra ZX02-22
        /// </summary>
        public string StrQrCode { get; }

        /// <summary>
        ///     Crédito do emissor
        /// </summary>
        public string Creditos { get; }

        #endregion

        #region Construtor

        /// <summary>
        /// </summary>
        /// <param name="emitente">emitente</param>
        /// <param name="emitidaEmContigencia">True, emitida em contingência</param>
        /// <param name="numeroDocumento">numero do documento</param>
        /// <param name="status">Status</param>
        /// <param name="produtos">Produtos</param>
        /// <param name="ambiente">True, ambiente de produção</param>
        /// <param name="pagamento">Pagamentos</param>
        /// <param name="infAdicionais">Informações adicinoais</param>
        /// <param name="serie">Número de série</param>
        /// <param name="dataEmissao">Data da emissão</param>
        /// <param name="urlConsulta">Url de consulta</param>
        /// <param name="chave">Chave da NFCe</param>
        /// <param name="destinatario">Destinatario</param>
        /// <param name="numProt">Numero do protocolo</param>
        /// <param name="strQrCode">string QrCode</param>
        /// <param name="creditos">Créditos</param>
        public DanfeNFCe(Emitente emitente, bool emitidaEmContigencia, string numeroDocumento, Status status,
                ICollection<ProdutoNFCe> produtos, bool ambiente, Pagamento pagamento, string dadosTributos, string infAdicionais,
                string serie, DateTime dataEmissao, string urlConsulta, string chave, Destinatario destinatario, string numProt,
                string strQrCode, string creditos)
        {
            Emitente = emitente;
            EmitidaEmContigencia = emitidaEmContigencia;
            NumeroDocumento = numeroDocumento;
            Status = status;
            Produtos = produtos;
            Producao = ambiente;
            Pagamento = pagamento;
            DadosTributos = dadosTributos;
            InfAdicionais = infAdicionais;
            Serie = serie;
            DataEmissao = dataEmissao;
            UrlConsulta = urlConsulta;
            Chave = chave.RetirarLetras();
            Destinatario = destinatario;
            NumProt = numProt;
            StrQrCode = strQrCode;
            Creditos = creditos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="ambiente">True, ambiente de produção</param>
        /// <param name="emitidaEmContigencia">True, emitida em contingência</param>
        /// <param name="status">Status</param>
        /// <param name="numProt">Numero do protocolo</param>
        /// <param name="creditos">Créditos</param>
        /// <param name="logo">Logo marcar em string Base64</param>
        public DanfeNFCe(NFe nfe, bool ambiente, bool emitidaEmContigencia, Status status, string numProt = "",
                string creditos = "", string logo = "")
        {
            //TODO:Criar teste unitario usando o novo construtor [DanfeNFe] 

            if (nfe == null) throw new ArgumentNullException(nameof(nfe));
            var doc = string.IsNullOrWhiteSpace(nfe.infNFe.emit.CPF) ? nfe.infNFe.emit.CNPJ : nfe.infNFe.emit.CPF;
            Emitente = new Emitente(nfe.infNFe.emit.xNome, nfe.infNFe.emit.IE, doc, logo,
                    new Endereco(nfe.infNFe.emit.enderEmit.xLgr, nfe.infNFe.emit.enderEmit.xBairro, nfe.infNFe.emit.enderEmit.xMun,
                            nfe.infNFe.emit.enderEmit.nro, nfe.infNFe.emit.enderEmit.CEP, nfe.infNFe.emit.enderEmit.UF,
                            nfe.infNFe.emit.enderEmit.fone.ToString(), nfe.infNFe.emit.enderEmit.UF));
            EmitidaEmContigencia = emitidaEmContigencia;
            NumeroDocumento = nfe.infNFe.ide.nNF.ToString();
            Status = status;

            #region Produtos

            var produtos = new List<ProdutoNFCe>();
            nfe.infNFe.det.ForEach(item =>
            {
                produtos.Add(new ProdutoNFCe(item.prod.cProd, item.prod.xProd, item.prod.uTrib, item.prod.qTrib, item.prod.vUnCom,
                        item.prod.vProd));
            });

            #endregion

            Produtos = produtos;
            Producao = ambiente;

            #region Pagamento

            var listPag = new List<FormPag>();
            nfe.infNFe.pag[0].detPag.ForEach(item => { listPag.Add(new FormPag(item.tPag.Descricao(), item.vPag)); });
            var pagamento = new Pagamento(nfe.infNFe.total.ICMSTot.vProd, nfe.infNFe.total.ICMSTot.vDesc, nfe.infNFe.total.ICMSTot.vNF,
                    nfe.infNFe.pag[0].vTroco, listPag);
            Pagamento = pagamento;

            #endregion,

            var infAdicionais = nfe.infNFe.infAdic.infCpl;

            #region Impostos

            var dadosTributos = nfe.infNFe.infAdic.infCpl;
            DadosTributos = dadosTributos;

            #endregion

            InfAdicionais = infAdicionais;
            Serie = nfe.infNFe.ide.serie.ToString();
            DataEmissao = nfe.infNFe.ide.dhEmi.Date;
            UrlConsulta = nfe.infNFeSupl.urlChave;
            Chave = nfe.infNFe.Id.RetirarLetras();

            #region Destinatario

            Destinatario destinatario = null;
            Endereco endereco = null;
            var dest = nfe.infNFe.dest;
            if (dest != null)
            {
                var cpfcnpj = dest.CPF + dest.CNPJ;
                if (dest.enderDest != null)
                    endereco = new Endereco(dest.enderDest.xLgr, dest.enderDest.xBairro, dest.enderDest.xMun, dest.enderDest.nro,
                            dest.enderDest.CEP, dest.enderDest.UF, dest.enderDest.fone.ToString(), dest.enderDest.UF);
                destinatario = new Destinatario(dest.xNome, cpfcnpj, endereco);
            }

            Destinatario = destinatario;

            #endregion

            NumProt = numProt;
            StrQrCode = nfe.infNFeSupl.qrCode;
            Creditos = creditos;
        }

        #endregion
    }
}