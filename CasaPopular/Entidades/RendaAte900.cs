using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class RendaAte900 : IPontuacao
    {
        public int Pontos { get; private set; }

        public void CalcularPontuacao(Familia familia)
        {
           if (familia.RendaTotal <= 900)
           {
               Pontos = 5;
           }
        }
    }
}
