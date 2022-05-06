
namespace CasaPopular.Entidades
{
    public interface IPontuacao
    {
        public int Pontos { get; }

        public void CalcularPontuacao(Familia familia);

    }
}
