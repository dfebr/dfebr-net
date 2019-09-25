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

using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Observacoes
{
    /// <summary>
    ///     <para>0=SEFAZ;</para>
    ///     <para>1=Justiça Federal;</para>
    ///     <para>2=Justiça Estadual;</para>
    ///     <para>3=Secex/RFB;</para>
    ///     <para>9=Outros</para>
    /// </summary>
    public enum IndicadorProcesso
    {
        [XmlEnum("0")] ipSEFAZ = 0,
        [XmlEnum("1")] ipJusticaFederal = 1,
        [XmlEnum("2")] ipJusticaEstadual = 2,
        [XmlEnum("3")] ipSecexRFB = 3,
        [XmlEnum("9")] ipOutros = 9
    }
}