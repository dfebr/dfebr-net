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

namespace DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Total
{
    /// <summary>
    ///     <para>1=Microempresa Municipal;</para>
    ///     <para>2=Estimativa;</para>
    ///     <para>3=Sociedade de Profissionais;</para>
    ///     <para>4=Cooperativa;</para>
    ///     <para>5=Microempresário Individual (MEI);</para>
    ///     <para>6=Microempresário e Empresa de Pequeno Porte (ME/EPP)</para>
    /// </summary>
    public enum RegTribISSQN
    {
        [XmlEnum("1")] TISSMicroempresaMunicipal = 1,

        [XmlEnum("2")] RTISSEstimativa = 2,

        [XmlEnum("3")] RTISSSociedadeProfissionais = 3,

        [XmlEnum("4")] RTISSCooperativa = 4,

        [XmlEnum("5")] RTISSMEI = 5,

        [XmlEnum("6")] RTISSMEEPP = 6
    }
}