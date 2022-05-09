
namespace CasaPopular.Entidades
{
    public class Ranking : IRanking
    {
       public void MostrarResultado(List<Familia> familias)
       {
            int posicao = 1;
            foreach (var familiaOrdenadaPorPontuacao in familias.OrderByDescending(x => x.PontuacaoFinal))
            {
                Console.WriteLine("#####################");
                Console.WriteLine($"Família na posição {posicao}: {familiaOrdenadaPorPontuacao.Nome}");
                Console.WriteLine($"Pontuação Final: {familiaOrdenadaPorPontuacao.PontuacaoFinal}");
                Console.WriteLine("#####################");

                posicao++;
            }
        }
    }
}
