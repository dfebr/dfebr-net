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

using System.ComponentModel;
using System.Xml.Serialization;

#endregion

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Destinatario
{
    /// <summary>
    ///     <para>1 – Contribuinte ICMS;</para>
    ///     <para>2 – Contribuinte isento de inscrição;</para>
    ///     <para>9 – Não Contribuinte</para>
    /// </summary>
    public enum indIEDest
    {
        [Description("Contribuinte ICMS")] [XmlEnum("1")]
        ContribuinteICMS = 1,

        [Description("Contribuinte isento de inscrição")] [XmlEnum("2")]
        Isento = 2,

        [Description("Não Contribuinte")] [XmlEnum("9")]
        NaoContribuinte = 9
    }
}