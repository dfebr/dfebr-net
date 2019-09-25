// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: DFeBR.EmissorNFe
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:15/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;

#endregion

namespace DFeBR.EmissorNFe
{
    public class Configurar
    {
        #region Propriedades

        /// <summary>
        ///     Configuracao do serviço emissor
        /// </summary>
        public EmissorServicoConfig EmissorConfig { get; }

        #endregion

        #region Construtor

        public Configurar(EmissorServicoConfig config)
        {
            EmissorConfig = config ?? throw new ArgumentNullException(nameof(config));
        }

        #endregion
    }
}