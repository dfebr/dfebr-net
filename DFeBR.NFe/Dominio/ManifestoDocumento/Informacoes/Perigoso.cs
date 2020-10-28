using System;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes
{

    /// <summary>
    /// Preenchido quando for transporte de produtos classificados pela ONU como perigosos.
    /// </summary>
    public class Perigoso
    {
        /// <summary>
        /// Número ONU/UN 
        /// </summary>
        [XmlElement(ElementName = "nONU")]
        public string NONU { get; set; }

        /// <summary>
        /// Nome apropriado para embarque do produto
        /// </summary>
        [XmlElement(ElementName = "xNomeAE")]
        public string XNomeAE { get; set; }

        /// <summary>
        /// Classe ou subclasse/divisão, e risco subsidiário/risco secundário
        /// </summary>
        [XmlElement(ElementName = "xClaRisco")]
        public string XClaRisco { get; set; }

        /// <summary>
        /// Grupo de Embalagem
        /// </summary>
        [XmlElement(ElementName = "grEmb")]
        public string GrEmb { get; set; }

        /// <summary>
        /// Quantidade total por produto
        /// </summary>
        [XmlElement(ElementName = "qTotProd")]
        public string QTotProd { get; set; }

        /// <summary>
        /// Quantidade e Tipo de volumes 
        /// </summary>
        [XmlElement(ElementName = "qVolTipo")]
        public string QVolTipo { get; set; }
    }
}
