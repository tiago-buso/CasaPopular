using CasaPopular.Entidades;
using CasaPopular.Entidades.Pontuacoes;

namespace CasaPopular
{
    public class Program
    {
        static void Main(string[] args)
        {            
            List<Familia> familias = CriadorDeFamilias();

            foreach (Familia familia in familias)
            {
                PontuacaoRenda pontuacaoRenda = new PontuacaoRenda();
                PontuacaoDependentes pontuacaoDependentes = new PontuacaoDependentes();

                int pontosRenda = pontuacaoRenda.CalcularPontuacao(familia);
                int pontosDependentes = pontuacaoDependentes.CalcularPontuacao(familia);

                familia.AdicionarPontuacao(pontosRenda);
                familia.AdicionarPontuacao(pontosDependentes);
            }

            int posicao = 1;
            foreach (var familiaOrdenadaPorPontuacao in familias.OrderByDescending(x => x.PontuacaoFinal))
            {
                Console.WriteLine("#####################");
                Console.WriteLine($"Família na posição {posicao}: {familiaOrdenadaPorPontuacao.Nome}");
                Console.WriteLine($"Pontuação Final: {familiaOrdenadaPorPontuacao.PontuacaoFinal}");
                Console.WriteLine("#####################");

                posicao++;
            }

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

       
    }
}