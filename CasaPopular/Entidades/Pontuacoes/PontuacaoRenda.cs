using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades.Pontuacoes
{
    public class PontuacaoRenda : TemplateDePontuacao
    {
        protected override int PontuacaoMaior()
        {
            return 5;
        }

        protected override int PontuacaoNormal()
        {
            return 3;
        }

        protected override bool RecebeMaiorPontuacao(Familia familia)
        {
            if (familia.RendaTotal <= 900)
            {
                return true;
            }

            return false;
        }

        protected override bool RecebeMenorPontuacao(Familia familia)
        {
            if (familia.RendaTotal >= 901 && familia.RendaTotal <= 1500)
            {
                return true;
            }

            return false;
        }
    }
}
