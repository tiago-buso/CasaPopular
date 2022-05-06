using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class DoisOuMenosDependentesMenoresDeIdade : IPontuacao
    {
        public int Pontos { get; private set; }

        public void CalcularPontuacao(Familia familia)
        {
            int quantidadeDependentesMenores = familia.Dependentes.Count(x => x.Idade < 18);
            if (quantidadeDependentesMenores >= 1  && quantidadeDependentesMenores <= 2 )
            {
                Pontos = 2;
            }
        }
    }
}
