using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    public enum IdentificacaoProcessoEmissao
    {
        [XmlEnum("0")]
        EmissaoComAplicativoContribuinte = 0,
        [XmlEnum("3")]
        EmissoPeloContribuinteComAplicativoFornecidoPeloFisco = 3
    }
}
