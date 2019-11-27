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
        public enum IndicadorPresenca
    {
        [XmlEnum("0")] [Description("0 - Não se aplica")]
        NaoSeAplica = 0,

        [XmlEnum("1")] [Description("1 - Operação presencial")]
        OperacaoPresencial = 1,

        [XmlEnum("2")] [Description("2 - Operação não presencial, pela Internet")]
        NaoPresencial = 2,

        [XmlEnum("3")] [Description("3 - Operação não presencial, Teleatendimento")]
        NaoPresencialTeleatendimento = 3,

        [XmlEnum("4")] [Description("4 - NFC-e em operação com entrega a domicílio")]
        NfceEntregaDomicilio = 4,

        [XmlEnum("5")] [Description("5 - Operação presencial fora do estabelecimento")]
        PresencialForaDoEstabelecimento = 5,

        [XmlEnum("9")] [Description("9 - Operação não presencial, outros")]
        NaoPresencialOutros = 9
    }
}