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

using System.Xml.Serialization;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using DFeBR.EmissorNFe.Utilidade;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMSST : ICMSBasico
    {
        #region Propriedades

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        [XmlElement(Order = 1)]
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12- Situação Tributária
        /// </summary>
        [XmlElement(Order = 2)]
        public Csticms CST { get; set; }

        /// <summary>
        ///     N26 - Valor da BC do ICMS ST retido
        /// </summary>
        [XmlElement(Order = 3)]
        public decimal vBCSTRet
        {
            get { return _vBcstRet; }
            set { _vBcstRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N27 - Valor do ICMS ST retido
        /// </summary>
        [XmlElement(Order = 4)]
        public decimal vICMSSTRet
        {
            get { return _vIcmsstRet; }
            set { _vIcmsstRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N31 - Valor da BC do ICMS ST da UF destino
        /// </summary>
        [XmlElement(Order = 5)]
        public decimal vBCSTDest
        {
            get { return _vBcstDest; }
            set { _vBcstDest = value.Arredondar(2); }
        }

        /// <summary>
        ///     N32 - Valor do ICMS ST da UF destino
        /// </summary>
        [XmlElement(Order = 6)]
        public decimal vICMSSTDest
        {
            get { return _vIcmsstDest; }
            set { _vIcmsstDest = value.Arredondar(2); }
        }

        #endregion

        #region Variaveis Globais

        private decimal _vBcstDest;
        private decimal _vBcstRet;
        private decimal _vIcmsstDest;
        private decimal _vIcmsstRet;

        #endregion
    }
}