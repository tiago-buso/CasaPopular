using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class TresOuMaisDependentesMenoresIdade : IPontuacao
    {
        public int Pontos { get; private set; }

        public void CalcularPontuacao(Familia familia)
        {
            if (familia.Dependentes.Count(x => x.Idade < 18) >= 3)
            {
                Pontos = 3;
            }
        }
    }
}
