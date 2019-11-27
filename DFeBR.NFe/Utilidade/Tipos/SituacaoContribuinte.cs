using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
    /// <summary>
    ///     Situação do contribuinte: 0 - não habilitado; 1 - habilitado.
    /// </summary>
    public enum SituacaoContribuinte
    {
        [XmlEnum("0")] NaoHabilitado = 0,
        [XmlEnum("1")] Habilitado = 1
    }
}
