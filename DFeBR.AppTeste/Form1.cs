using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Enderecador;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFeBR.AppTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btConfigura_click(object sender, EventArgs e)
        {
            EmissorServicoConfig config = new EmissorServicoConfig(VersaoServico.Ve400, Estado.Rj,
                TipoAmbiente.Homologacao, IndicadorSincronizacao.Sincrono);
            config.ConfiguraServicos(new ConfigServ
            {
                
            })
        }
    }
}
