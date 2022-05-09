using CasaPopular.Entidades;
using CasaPopular.Entidades.Pontuacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Servicos
{
    public class PontuacaoServico : IPontuacaoServico
    {
        private readonly IRanking _ranking;

        public PontuacaoServico(IRanking ranking)
        {
            _ranking = ranking;
        }

        public void CalcularPontuacaoDasFamilias(List<Familia> familias)
        {
            foreach (Familia familia in familias)
            {
                int pontuacaoRenda = CalcularPontuacaoRenda(familia);
                int pontuacaoDependentes = CalcularPontuacaoDependentes(familia);

                familia.AdicionarPontuacao(pontuacaoRenda);
                familia.AdicionarPontuacao(pontuacaoDependentes);
            }

            _ranking.MostrarResultado(familias);
        }

        private int CalcularPontuacaoRenda(Familia familia)
        {
            PontuacaoRenda pontuacaoRenda = new PontuacaoRenda();
            return pontuacaoRenda.CalcularPontuacao(familia);
        }

        private int CalcularPontuacaoDependentes(Familia familia)
        {
            PontuacaoDependentes pontuacaoDependentes = new PontuacaoDependentes();
            return pontuacaoDependentes.CalcularPontuacao(familia);
        }
    }
}
