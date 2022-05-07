using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades.Pontuacoes
{
    public class PontuacaoDependentes : TemplateDePontuacao
    {
        protected override int PontuacaoMaior()
        {
            return 3;
        }

        protected override int PontuacaoNormal()
        {
            return 2;
        }

        protected override bool RecebeMaiorPontuacao(Familia familia)
        {
            if (FamiliaTemDependentes(familia) && QuantidadeDeDependentesValidosParaPontuacao(18, familia) >= 3)
            {              
                return true;
            }

            return false;
        }

        protected override bool RecebeMenorPontuacao(Familia familia)
        {
            if (FamiliaTemDependentes(familia))
            {
                int quantidadeDependentesValidosParaPontuacao = QuantidadeDeDependentesValidosParaPontuacao(18, familia);
                if (quantidadeDependentesValidosParaPontuacao >= 1 && quantidadeDependentesValidosParaPontuacao <= 2)
                {
                    return true;
                }
            }            

            return false;
        }

        private bool FamiliaTemDependentes(Familia familia)
        {
            return familia.Dependentes != null;
        }

        private int QuantidadeDeDependentesValidosParaPontuacao(int idadeLimite, Familia familia)
        {
            return familia.Dependentes.Count(x => x.Idade < idadeLimite);
        }
    }
}
