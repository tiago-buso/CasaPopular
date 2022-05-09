using CasaPopular.Entidades;

namespace CasaPopular.Servicos
{
    public interface IPontuacaoServico
    {
        void CalcularPontuacaoDasFamilias(List<Familia> familias);
    }
}