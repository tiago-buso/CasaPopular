using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class RendaAte1500 : IPontuacao
    {
        public int Pontos { get; private set; }

        public void CalcularPontuacao(Familia familia)
        {
            if (familia.RendaTotal >= 901 && familia.RendaTotal <= 1500)
            {
                Pontos = 3;
            }
        }
    }
}
