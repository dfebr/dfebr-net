// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores:
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:22/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;

#endregion

namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class DanfeNFe
    {
        #region Propriedades

        public Destinatario Destinatario { get;  }

        public Emitente Emitente { get;  }

        public string Chave { get;  }

        public decimal ValorTotNota { get;  }

        public string NumNota { get;  }

        public string SerieNota { get;  }

        /// <summary>
        ///     Status da nota
        /// </summary>
        public Status Status { get;  }

        /// <summary>
        ///     Tipo operação
        ///     <para>0 - Entrada; 1 - Saida</para>
        /// </summary>
        public string TipoOper { get;  }

        /// <summary>
        ///     Inscrição estadual do substituto tributário
        /// </summary>
        public string IeSt { get;  }

        /// <summary>
        ///     Natureza da operação
        /// </summary>
        public string NatOperacao { get;  }

        /// <summary>
        ///     Protocolo de autorização de uso
        /// </summary>
        public string ProtocoloUso { get;  }

        /// <summary>
        ///     Data emissão
        /// </summary>
        public DateTime DataEmissao { get;  }

        /// <summary>
        ///     Data Entrada Saida
        /// </summary>
        public DateTime DataEntSaid { get;  }

        public ICollection<Fatura> Faturas { get;  }

        public Imposto Imposto { get;  }

        /// <summary>
        ///     Transportadora
        /// </summary>
        public Transportadora Transportadora { get;  }

        /// <summary>
        ///     Volumes
        /// </summary>
        public ICollection<Volume> Volumes { get;  }

        /// <summary>
        ///     Produtos
        /// </summary>
        public ICollection<Produto> Produtos { get;  }

        /// <summary>
        ///     Dados sobre serviço
        /// </summary>
        public Issqn ISsqn { get;  }
        /// <summary>
        /// Informações adicionais
        /// </summary>
        public InfAdic Inf { get;  }
        /// <summary>
        /// Credito empresa Software
        /// </summary>
        public string Creditos { get;  }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinatario">Destinatario</param>
        /// <param name="emitente">Emitente</param>
        /// <param name="chave">Chave</param>
        /// <param name="valorTotNota">Valor total da nota</param>
        /// <param name="numNota">Número da nota</param>
        /// <param name="serieNota">Série da nota</param>
        /// <param name="status">Status da nota</param>
        /// <param name="tipoOper">0 - Entrada; 1 - Saida</param>
        /// <param name="ieSt">Inscrição estadual</param>
        /// <param name="natOperacao">Natureza da operação</param>
        /// <param name="protocoloUso">Protocolo de uso</param>
        /// <param name="dataEmissao">Data da emissão</param>
        /// <param name="dataEntSaid">data de saida</param>
        /// <param name="faturas">Faturas</param>
        /// <param name="imposto">Impostos</param>
        /// <param name="transportadora">Transportadora</param>
        /// <param name="volumes">volumes</param>
        /// <param name="produtos">Produtos</param>
        /// <param name="ssqn">ISSQN</param>
        /// <param name="inf">Informações adicionais</param>
        /// <param name="creditos">Créditos</param>
        public DanfeNFe(Destinatario destinatario, Emitente emitente, string chave, decimal valorTotNota, 
                string numNota, string serieNota, Status status, string tipoOper, string ieSt, 
                string natOperacao, string protocoloUso, DateTime dataEmissao, 
                DateTime dataEntSaid, ICollection<Fatura> faturas, Imposto imposto, 
                Transportadora transportadora, ICollection<Volume> volumes, ICollection<Produto> produtos,
                Issqn ssqn, InfAdic inf, string creditos)
        {
            Destinatario = destinatario;
            Emitente = emitente;
            Chave = chave;
            ValorTotNota = valorTotNota;
            NumNota = numNota;
            SerieNota = serieNota;
            Status = status;
            TipoOper = tipoOper;
            IeSt = ieSt;
            NatOperacao = natOperacao;
            ProtocoloUso = protocoloUso;
            DataEmissao = dataEmissao;
            DataEntSaid = dataEntSaid;
            Faturas = faturas;
            Imposto = imposto;
            Transportadora = transportadora;
            Volumes = volumes;
            Produtos = produtos;
            ISsqn = ssqn;
            Inf = inf;
            Creditos = creditos;    
        }

        //TODO:Criar construtor [DanfeNFe] de modo que informe como prametro o objeto NFe, similar ao construtor da DanfeNFCe
        //TODO:Criar teste unitario usando o novo construtor [DanfeNFe] 

    }
}