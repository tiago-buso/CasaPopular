using Flunt.Notifications;
using Flunt.Validations;

namespace CasaPopular.Entidades
{
    public class Dependente : Notifiable<Notification>
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public Dependente(string nome, int idade)
        {            
            if (string.IsNullOrEmpty(nome))
            {
                AddNotification("nome", "Por favor, insira um nome para o dependente");
            }

            if (idade < 0 || idade > 140)
            {
                AddNotification("idade", "Por favor, insira uma idade válida");
            }
            
            if (this.IsValid)
            {
                Nome = nome;
                Idade = idade;
            }            
        }          
    }
}
