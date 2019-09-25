// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.Emissor
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System.Collections.Generic;

#endregion

namespace DFeBR.EmissorNFe.Utilidade.Entidades
{
    public static class StatusSefaz
    {
        #region Propriedades

        public static ICollection<KeyValuePair<int, string>> ListarCodigo
        {
            get
            {
                var list = new List<KeyValuePair<int, string>>();
                list.Add(new KeyValuePair<int, string>(100, "Autorizado o uso da NF-e"));
                list.Add(new KeyValuePair<int, string>(101, "Cancelamento de NF-e homologado"));
                list.Add(new KeyValuePair<int, string>(102, "Inutilização de número homologado"));
                list.Add(new KeyValuePair<int, string>(103, "Lote recebido com sucesso"));
                list.Add(new KeyValuePair<int, string>(104, "Lote processado"));
                list.Add(new KeyValuePair<int, string>(105, "Lote em processamento"));
                list.Add(new KeyValuePair<int, string>(106, "Lote não localizado"));
                list.Add(new KeyValuePair<int, string>(107, "Serviço em Operação"));
                list.Add(new KeyValuePair<int, string>(108, "Serviço Paralisado Momentaneamente (curto prazo)"));
                list.Add(new KeyValuePair<int, string>(109, "Serviço Paralisado sem Previsão"));
                list.Add(new KeyValuePair<int, string>(110, "Uso Denegado"));
                list.Add(new KeyValuePair<int, string>(111, "Consulta cadastro com uma ocorrência"));
                list.Add(new KeyValuePair<int, string>(112, "Consulta cadastro com mais de uma ocorrência"));
                list.Add(new KeyValuePair<int, string>(124, "EPEC Autorizado"));
                list.Add(new KeyValuePair<int, string>(128, "Lote de Evento Processado"));
                list.Add(new KeyValuePair<int, string>(135, "Evento registrado e vinculado a NF-e"));
                list.Add(new KeyValuePair<int, string>(136, "Evento registrado, mas não vinculado a NF-e"));
                list.Add(new KeyValuePair<int, string>(137, "Nenhum documento localizado para o Destinatário"));
                list.Add(new KeyValuePair<int, string>(138, "Documento localizado para o Destinatário"));
                list.Add(new KeyValuePair<int, string>(139, "Pedido de Download processado"));
                list.Add(new KeyValuePair<int, string>(104, "Download disponibilizado"));
                list.Add(new KeyValuePair<int, string>(142, "Ambiente de Contingência EPEC bloqueado para o Emitente"));
                list.Add(new KeyValuePair<int, string>(150, "Autorizado o uso da NF-e, autorização fora de prazo"));
                list.Add(new KeyValuePair<int, string>(151, "Cancelamento de NF-e homologado fora de prazo "));
                return list;
            }
        }

        #endregion
    }
}