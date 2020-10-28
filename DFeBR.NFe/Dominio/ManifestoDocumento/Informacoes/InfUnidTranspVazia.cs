using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public class InfUnidTranspVazia
    {
        [XmlElement(ElementName = "idUnidTranspVazia")]
        public string IdUnidTranspVazia { get; set; }

        [XmlElement(ElementName = "tpUnidTranspVazia")]
        public TipoUnidadeTranspVazia TpUnidTranspVazia { get; set; }
    }
}