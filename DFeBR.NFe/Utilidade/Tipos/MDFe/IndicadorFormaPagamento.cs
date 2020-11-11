using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum IndicadorFormaPagamento
    {
        [XmlEnum("0")]
        [Description("Pagamento à Vista")]
        PagamentoAVista = 0,

        [XmlEnum("1")]
        [Description("Pagamento à Prazo")]
        PagamentoAPrazo = 1
    }
}
