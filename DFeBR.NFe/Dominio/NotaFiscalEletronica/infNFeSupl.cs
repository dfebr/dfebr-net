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

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica
{
    [Serializable]
    public class infNFeSupl : IXmlSerializable
    {
        #region Propriedades

        /// <summary>
        ///     ZX02 - Texto com o QR-Code impresso no DANFE NFC-e
        ///     O atributo qrCode deve ser serializado como CDATA, conforme NT2015.002, V141, regra ZX02-22
        /// </summary>
        public string qrCode { get; set; }

        /// <summary>
        ///     ZX03 - Texto com a URL de consulta por chave de acesso a ser impressa no DANFE NFC-e
        ///     VERSÃO 4.00
        /// </summary>
        public string urlChave { get; set; }

        #endregion

        #region Implementacoes

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement(typeof(infNFeSupl).Name);
            reader.ReadStartElement("qrCode");
            qrCode = reader.ReadString();
            reader.ReadEndElement();
            if (reader.IsStartElement("urlChave"))
            {
                reader.ReadStartElement("urlChave");
                urlChave = reader.ReadString();
                reader.ReadEndElement();
            }

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("qrCode");
            writer.WriteCData(qrCode);
            writer.WriteEndElement();
            if (urlChave == null) return;
            writer.WriteStartElement("urlChave");
            writer.WriteString(urlChave);
            writer.WriteEndElement();
        }

        #endregion
    }
}