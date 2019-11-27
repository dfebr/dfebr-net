// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Marcos Vinícius e-mail: marcos8154@gmail.com
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Tipos
{
        /// <summary>
    ///     Informar "1=Empresa Emitente" para este evento.
    ///     Nota:
    ///     1=Empresa Emitente;
    ///     2=Empresa Destinatária;
    ///     3=Empresa;
    ///     5=Fisco;
    ///     6=RFB;
    ///     9=Outros Órgãos.
    /// </summary>
    public enum TipoAutor
    {
        [XmlEnum("1")] taEmpresaEmitente = 1,

        [XmlEnum("2")] taEmpresaDestinataria = 2,

        [XmlEnum("3")] taEmpresa = 3,

        [XmlEnum("5")] taFisco = 5,

        [XmlEnum("6")] taRFB = 6,

        [XmlEnum("9")] taOutrosOrgaos = 9
    }
}