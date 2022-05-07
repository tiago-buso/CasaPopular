using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades.Pontuacoes
{
    public abstract class TemplateDePontuacao : IPontuacao
    {
        public int CalcularPontuacao(Familia familia)
        {
            if (RecebeMaiorPontuacao(familia))
            {
                return PontuacaoMaior();
            }
            else if (RecebeMenorPontuacao(familia))
            {
                return PontuacaoNormal();
            }

            return 0;
        }

        protected abstract bool RecebeMaiorPontuacao(Familia familia);
        protected abstract bool RecebeMenorPontuacao(Familia familia);
        protected abstract int PontuacaoMaior();
        protected abstract int PontuacaoNormal();
    }
}
