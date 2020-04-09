// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores:
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com
// Data Criação:22/05/2019
// Todos os direitos reservados
// ===================================================================


namespace DFeBR.EmissorNFe.Danfe.Entidades
{
    public class Produto
    {
        #region Propriedades

        /// <summary>
        ///     Código do produto
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        ///     Descrição do produto
        /// </summary>
        public string Descricao { get; }

        /// <summary>
        ///     Informações adicionais do produto
        /// </summary>
        public string InfAdic { get; }

        /// <summary>
        ///     Unidade do produto
        /// </summary>
        public string Unidade { get; }

        /// <summary>
        ///     Quantidade do produto
        /// </summary>
        public decimal Quantidade { get; }

        /// <summary>
        ///     Valor unitário do produto
        /// </summary>
        public decimal ValorUnitario { get; }

        /// <summary>
        ///     Valor IMCS
        /// </summary>
        public decimal ValorIcms { get; }

        /// <summary>
        ///     Código NNCM
        /// </summary>
        public string Ncm { get; }

        /// <summary>
        ///     Código CFOP
        /// </summary>
        public string Cfop { get; }

        /// <summary>
        ///     Origem Mercadoria
        /// </summary>
        public string Origem { get; }

        /// <summary>
        ///     Base de calculo
        /// </summary>
        public decimal BaseCalculo { get; }

        /// <summary>
        ///     ICMS Partilha
        /// </summary>
        public decimal ValorIcmsPart { get; }


        /// <summary>
        ///     IPI
        /// </summary>
        public decimal ValorIpi { get; }

        /// <summary>
        ///     IPI percentual
        /// </summary>
        public decimal ValorIpiPerc { get; }

        /// <summary>
        /// NFe
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="descricao">Descrição</param>
        /// <param name="infAdic">Informações adicionais</param>
        /// <param name="unidade">Unidade de medida</param>
        /// <param name="quantidade">Quantidade</param>
        /// <param name="valorUnitario">Valor unitário</param>
        /// <param name="valorIcms">Valor do ICMS</param>
        /// <param name="ncm">Código NCM</param>
        /// <param name="cfop">Código CFOP</param>
        /// <param name="origem">{0- Nacional | 1 Importado}</param>
        /// <param name="baseCalculo">Base de cálculo</param>
        /// <param name="valorIcmsPart">Valor de partilha do ICMS</param>
        /// <param name="valorIpi">Valor do IPI</param>
        /// <param name="valorIpiPerc">Valor percentual do IPI</param>
        public Produto(string codigo, string descricao, string infAdic, string unidade, decimal quantidade, decimal valorUnitario, decimal valorIcms, string ncm, string cfop, string origem, decimal baseCalculo, decimal valorIcmsPart, decimal valorIpi, decimal valorIpiPerc)
        {
            Codigo = codigo;
            Descricao = descricao;
            InfAdic = infAdic;
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ValorIcms = valorIcms;
            Ncm = ncm;
            Cfop = cfop;
            Origem = origem;
            BaseCalculo = baseCalculo;
            ValorIcmsPart = valorIcmsPart;
            ValorIpi = valorIpi;
            ValorIpiPerc = valorIpiPerc;    
        }

        /// <summary>
        /// NFCe
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="descricao">Descrição</param> 
        /// <param name="unidade">Unidade de medida</param>
        /// <param name="quantidade">Quantidade</param>
        /// <param name="valorUnitario">Valor unitário</param>  
        public Produto(string codigo, string descricao, string unidade, decimal quantidade, decimal valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao; 
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;  
        }

        #endregion
    }
}