using Flunt.Br;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class Dependente : Notifiable<Notification>
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public Dependente(string nome, int idade)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(nome, "Por favor, insira um nome para o dependente")
                .IsNotBetween(Idade, 0, 140, "Por favor, insira uma idade válida"));                  

            Nome = nome;
            Idade = idade;
        }          
    }
}
