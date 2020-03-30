using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Enderecador;
using DFeBR.EmissorNFe.Utilidade.Tipos;

namespace DFeBR.AppTeste.DFeInfra
{
    public class Configuracao
    {
        private ConfigServ GetConfigServ()
        {
            var cfg = new ConfigServ();
            cfg.
        }

        public EmissorServicoConfig GetConfiguracao()
        {
            EmissorServicoConfig config = new EmissorServicoConfig(VersaoServico.Ve400, Estado.Rj,
        TipoAmbiente.Homologacao, IndicadorSincronizacao.Sincrono);
            config.ConfiguraServicos(new ConfigServ
            {

            })
        }
    }
}
