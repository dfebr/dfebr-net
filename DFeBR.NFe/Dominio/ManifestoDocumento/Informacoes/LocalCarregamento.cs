using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{
    public abstract class LocalCarregamento
    {
        public string CEP { get; set; }

        [XmlIgnore]
        public decimal? Latitude { get; set; }

        [XmlElement("latitude")]
        public string latitudeProxy
        {
            get { return Latitude.ToString() ?? null; }
            set { Latitude = decimal.Parse(value); }
        }

        [XmlIgnore]
        public decimal? Longitude { get; set; }

        [XmlElement("Longitude")]
        public string LongitudeProxy
        {
            get { return Longitude.ToString() ?? null; }
            set { Longitude = decimal.Parse(value); }
        }
    }
}
