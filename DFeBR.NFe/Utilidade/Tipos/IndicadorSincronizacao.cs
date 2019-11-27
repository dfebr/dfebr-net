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
    ///     Indicador de Sincronização:
    ///     <para>0 = Assíncrono. A resposta deve ser obtida consultando o serviço NFeRetAutorizacao, com o nº do recibo</para>
    ///     <para>
    ///         1 = Síncrono. Empresa solicita processamento síncrono do Lote de NF-e (sem a geração de Recibo para consulta
    ///         futura);
    ///     </para>
    /// </summary>
    public enum IndicadorSincronizacao
    {
        [XmlEnum("0")] Assincrono = 0,

        [XmlEnum("1")] Sincrono = 1
    }
}