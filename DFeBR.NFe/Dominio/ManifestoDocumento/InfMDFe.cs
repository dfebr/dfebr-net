using DFeBR.EmissorNFe.Dominio.ManifestoDocumento.Informacoes;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes;
using DFeBR.EmissorNFe.Utilidade.Tipos.MDFe;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DFeBR.EmissorNFe.Dominio.ManifestoDocumento
{
    public class InfMDFe
    {
        public InfMDFe()
        {
            Ide = new Ide();
            Emit = new Emit();
            InfModal = new InfModal();
            InfDoc = new InfDoc();
            Tot = new Tot();
            Versao = VersaoServicoMDFe.Ve100;
        }
        /// <summary>
        /// Versão do leiaute 
        /// </summary>
        [XmlAttribute(AttributeName = "versao")]
        public VersaoServicoMDFe Versao { get; set; }

        /// <summary>
        /// Identificador da tag a ser assinada. 
        /// Informar a chave de acesso do MDF-e e
        /// precedida do literal "MDFe" 
        /// </summary>
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Identificação do MDF-e
        /// </summary>
        [XmlElement(ElementName = "ide")]
        public Ide Ide { get; set; }

        /// <summary>
        /// Identificação do Emitente do Manifesto
        /// </summary>
        [XmlElement(ElementName = "emit")]
        public Emit Emit { get; set; }

        /// <summary>
        /// Informações do modal
        /// </summary>
        [XmlElement(ElementName = "infModal")]
        public InfModal InfModal { get; set; }

        /// <summary>
        /// Informações dos Documentos fiscais vinculados ao manifesto
        /// </summary>
        [XmlElement(ElementName = "infDoc")]
        public InfDoc InfDoc { get; set; }

        /// <summary>
        /// Informações de Seguro da carga
        /// MDF-e 3.0
        /// </summary>
        [XmlElement(ElementName = "seg")]
        public List<SeguroCarga> Seg { get; set; }

        [XmlElement(ElementName = "prodPred")]
        public ProdPred ProdPred { get; set; }

        /// <summary>
        /// Totalizadores da carga transportada e seus documentos fiscais
        /// </summary>
        [XmlElement(ElementName = "tot")]
        public Tot Tot { get; set; }

        /// <summary>
        /// Lacres do MDF-e
        /// </summary>
        [XmlElement(ElementName = "lacres")]
        public List<Lacre> Lacres { get; set; }

        /// <summary>
        /// Autorizados para download do XML do DF-e
        /// </summary>
        [XmlElement(ElementName = "autXML")]
        public List<AutXML> AutXml { get; set; }

        /// <summary>
        /// Informações Adicionais
        /// </summary>
        [XmlElement(ElementName = "infAdic")]
        public InfAdic InfAdic { get; set; }

        /// <summary>
        /// Informações do Responsável Técnico pela emissão do DF-e
        /// </summary>
        [XmlElement(ElementName = "infRespTec")]
        public respTec InfRespTec { get; set; }
    }
}
