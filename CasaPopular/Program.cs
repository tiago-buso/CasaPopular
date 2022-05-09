using CasaPopular.Entidades;
using CasaPopular.Entidades.Pontuacoes;
using CasaPopular.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace CasaPopular
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            List<Familia> familias = CriadorDeFamilias();

            var pontuacaoServico = serviceProvider.GetService<IPontuacaoServico>();

            pontuacaoServico.CalcularPontuacaoDasFamilias(familias);

            Console.ReadLine();

        }

        public static List<Familia> CriadorDeFamilias()
        {
            List<Familia> familias = new List<Familia>();

            Familia familia1 = new Familia("Família 1", 1000);
            Familia familia2 = new Familia("Família 2", 10000);
            Familia familia3 = new Familia("Família 3", 900);
            Familia familia4 = new Familia("Família 4", 1500);
            Familia familia5 = new Familia("Família 5", 500);
            Familia familia6 = new Familia("Família 6", 2000);

            familia1.AdicionarDependente(new Dependente("Dependente 1 Família 1", 1));
            familia1.AdicionarDependente(new Dependente("Dependente 2 Família 1", 5));
            familia1.AdicionarDependente(new Dependente("Dependente 3 Família 1", 7));

            familia2.AdicionarDependente(new Dependente("Dependente 1 Família 2", 10));

            familia4.AdicionarDependente(new Dependente("Dependente 1 Família 4", 17));
            familia4.AdicionarDependente(new Dependente("Dependente 2 Família 4", 15));

            familia6.AdicionarDependente(new Dependente("Dependente 1 Família 6", 22));

            familias.Add(familia1);
            familias.Add(familia2);
            familias.Add(familia3);
            familias.Add(familia4);
            familias.Add(familia5);
            familias.Add(familia6);

            return familias;
        }

        //Injeção de dependência
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRanking, Ranking>();
            services.AddScoped<IPontuacaoServico, PontuacaoServico>();
        }
    }
}