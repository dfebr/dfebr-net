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
    ///     Processo de emissão utilizado com a seguinte codificação:
    ///     <para>0 - emissão de NF-e com aplicativo do contribuinte;</para>
    ///     <para>1 - emissão de NF-e avulsa pelo Fisco;</para>
    ///     <para>2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;</para>
    ///     <para>3- emissão de NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.</para>
    /// </summary>
    public enum ProcessoEmissao
    {
        [XmlEnum("0")] [Description("0 - Aplicativo do contribuinte")]
        AplicativoContribuinte = 0,

        [XmlEnum("1")] [Description("1 - Avulsa pelo Fisco")]
        AvulsaFisco = 1,

        [XmlEnum("2")] [Description("2 - Avulsa pelo site do Fisco")]
        AvulsaSiteFisco = 2,

        [XmlEnum("3")] [Description("3 - Aplicativo fornecido pelo Fisco")]
        AplicativoFisco = 3
    }
}