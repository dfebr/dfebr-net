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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Detalhe.Tributacao.Municipal
{
    /// <summary>
    ///     <para>1=Sim;</para>
    ///     <para>2=Não;</para>
    /// </summary>
    public enum indIncentivo
    {
        [XmlEnum("1")] iiSim = 1,
        [XmlEnum("2")] iiNao = 2
    }

    /// <summary>
    ///     1=Exigível, 2=Não incidência; 3=Isenção; 4=Exportação; 5=Imunidade; 6=Exigibilidade Suspensa por Decisão Judicial;
    ///     7=Exigibilidade Suspensa por Processo Administrativo;
    /// </summary>
    public enum IndicadorISS
    {
        [XmlEnum("1")] iiExigivel = 1,
        [XmlEnum("2")] iiNaoIncidencia = 2,
        [XmlEnum("3")] iiIsencao = 3,
        [XmlEnum("4")] iiExportacao = 4,
        [XmlEnum("5")] iiImunidade = 5,
        [XmlEnum("6")] iiExigSuspDecisaoJudicial = 6,
        [XmlEnum("7")] iiExigSuspProcessoAdm = 7
    }
}