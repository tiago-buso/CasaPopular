using Flunt.Br;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Entidades
{
    public class Familia : Notifiable<Notification>
    {
        public string Nome { get; private set; }
        public double RendaTotal { get; private set; }
        public List<Dependente> Dependentes { get; private set; }
        public int PontuacaoFinal { get; private set; }

        public Familia (string nome, double rendaTotal)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(nome, "Por favor, insira um nome para a família")
                .IsLowerThan(rendaTotal, 0, "Por favor, insira uma renda válida"));                                 
            
            Nome = nome;
            RendaTotal = rendaTotal;
        }    

        public void AdicionarDependente(Dependente dependente)
        {
            InstanciarLista();

            AddNotifications(new Contract()
                .IsNull(dependente, "Por favor, adicione um dependente válido"));
            
            Dependentes.Add(dependente);
        }        

        private void InstanciarLista()
        {
            if (Dependentes == null)
            {
                Dependentes = new List<Dependente>();
            }
        }

        public void AdicionarPontuacao(int pontuacao)
        {
            AddNotifications(new Contract()                
                .IsLowerThan(pontuacao, 0, "Por favor, insira uma pontuação válida"));

            PontuacaoFinal += pontuacao;
        }
    }
}
