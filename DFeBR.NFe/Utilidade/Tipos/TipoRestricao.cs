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
    ///     0=Não há; 1=Alienação Fiduciária;
    ///     2=Arrendamento Mercantil; 3=Reserva de Domínio;
    ///     4=Penhor de Veículos; 9=Outras. (v2.0)
    /// </summary>
    public enum TipoRestricao
    {
        [XmlEnum("0")] [Description("0 - Não há")]
        Nenhuma = 0,

        [XmlEnum("1")] [Description("1 - Alienação Fiduciária")]
        Alienacao = 1,

        [XmlEnum("2")] [Description("2 - Arrendamento Mercantil")]
        Arrendamento = 2,

        [XmlEnum("3")] [Description("3 - Reserva de Domínio")]
        Reserva = 3,

        [XmlEnum("4")] [Description("4 - Penhor de Veículos")]
        Penhor = 4,

        [XmlEnum("9")] [Description("9 - outras")]
        Outras = 9
    }
}