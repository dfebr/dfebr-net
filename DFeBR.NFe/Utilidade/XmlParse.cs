// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using DFeBR.EmissorNFe.Utilidade.Exceptions;

#endregion

namespace DFeBR.EmissorNFe.Utilidade
{
    public static class XmlParse
    {
        /// <summary>
        ///     Validar Schema
        /// </summary>
        /// <param name="xsdNomeArq">Nome do arquivo Xsd</param>
        /// <param name="stringXml">String XML</param>
        /// <param name="caminhoSchema">Caminho do Shema Xsd</param>
        public static void Validar(string xsdNomeArq, string stringXml, string caminhoSchema)
        {
            if (!Directory.Exists(caminhoSchema))
                throw new Exception("Diretório de Schemas não encontrado: \n" + caminhoSchema);
            var arquivoSchema = caminhoSchema + @"\" + xsdNomeArq;
            // Define o tipo de validação
            var cfg = new XmlReaderSettings {ValidationType = ValidationType.Schema};
            cfg.Schemas.Add(null, arquivoSchema);
            cfg.ValidationEventHandler += ValidationEventHandler;
            var reader = XmlReader.Create(new StringReader(stringXml), cfg);
            var document = new XmlDocument();
            document.Load(reader);
            //Valida xml
            document.Validate(ValidationEventHandler);
        }


        internal static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            var msg = $"Erro ao validar xml contra Schema Xsd.\n{args.Message}";
            throw new FalhaValidacaoSchemaException(msg);
        }
    }
}