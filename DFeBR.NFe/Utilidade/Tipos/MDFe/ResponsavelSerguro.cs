using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos.MDFe
{
    [Serializable]
    public enum ResponsavelSeguro
    {
        [XmlEnum("1")]
        [Description("Emitente do MDFe")]
        EmitenteDoMDFe = 1,
        [XmlEnum("2")]
        [Description("Responsável Seguro")]
        Contratante = 2
    }
}
