using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class Dependente
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public Dependente(string nome, int idade)
        {
            ValidarNome(nome);
            ValidarIdade(idade);

            Nome = nome;
            Idade = idade;
        }
       

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Por favor, insira um nome para o dependente");
            }            
        }

        private void ValidarIdade(int idade)
        {
            if (idade < 0 || idade > 140)
            {
                throw new Exception("Por favor, insira uma idade válida");
            }
        }
    }
}
