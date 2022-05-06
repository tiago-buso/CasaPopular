using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class Familia
    {
        public string Nome { get; private set; }
        public double RendaTotal { get; private set; }
        public List<Dependente> Dependentes { get; private set; }

        public IPontuacao Pontuacao { get; private set; }

        public Familia (string nome, double rendaTotal)
        {
            ValidarNome(nome);
            ValidarRendaTotal(rendaTotal);
            
            Nome = nome;
            RendaTotal = rendaTotal;
        }    

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Por favor, insira um nome para a família");
            }
        }

        private void ValidarRendaTotal(double rendaTotal)
        {
            if (rendaTotal < 0)
            {
                throw new Exception("Por favor, insira uma renda válida");
            }
        }

        public void AdicionarDependente(Dependente dependente)
        {
            InstanciarLista();
            ValidarDependente(dependente);
        }        

        private void InstanciarLista()
        {
            if (Dependentes == null)
            {
                Dependentes = new List<Dependente>();
            }
        }

        private void ValidarDependente(Dependente dependente)
        {
            if (dependente != null)
            {
                Dependentes.Add(dependente);
            }
            else
            {
                throw new Exception("Por favor, adicione um dependente válido");
            }
        }

        public void AdicionarPontuacao(IPontuacao pontuacao)
        {
            if (pontuacao != null)
            {
                Pontuacao = pontuacao;
            }
            else
            {
                throw new Exception("Por favor, adicione uma pontuação válida");
            }
        }
    }
}
