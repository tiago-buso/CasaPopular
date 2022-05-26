using CasaPopular.Entidades;
using CasaPopular.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace CasaPopularTest
{
    public class Startup
    {   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRanking, Ranking>();
            services.AddTransient<IPontuacaoServico, PontuacaoServico>();
        }
    }
}
