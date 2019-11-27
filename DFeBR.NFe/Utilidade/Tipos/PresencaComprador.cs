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
    ///     Indicador de presença do comprador no estabelecimento comercial no momento da operação
    ///     <para>0 - Não se aplica</para>
    ///     <para>1 - Operação presencial;</para>
    ///     <para>2 - Operação não presencial, pela Internet;</para>
    ///     <para>3 - Operação não presencial, Teleatendimento;</para>
    ///     <para>4 - NFC-e em operação com entrega a domicílio;</para>
    ///     <para>9 - Operação não presencial, outros.</para>
    /// </summary>
    public enum PresencaComprador
    {
        [XmlEnum("0")] PcNao = 0,
        [XmlEnum("1")] PcPresencial = 1,
        [XmlEnum("2")] PcInternet = 2,
        [XmlEnum("3")] PcTeleatendimento = 3,
        [XmlEnum("4")] PcEntregaDomicilio = 4,
        [XmlEnum("5")] PcPresencialForaEstabelecimento = 5, // versão 4.00
        [XmlEnum("9")] PcOutros = 9
    }
}