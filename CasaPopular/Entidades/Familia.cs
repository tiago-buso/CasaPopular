using Flunt.Notifications;
using Flunt.Validations;

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
            if (string.IsNullOrEmpty(nome))
            {
                AddNotification("nome", "Por favor, insira um nome para a família");
            }

            if (rendaTotal < 0)
            {
                AddNotification("rendaTotal", "Por favor, insira uma renda válida");
            }                                        
            
            if (this.IsValid)
            {
                Nome = nome;
                RendaTotal = rendaTotal;
            }            
        }    

        public void AdicionarDependente(Dependente dependente)
        {
            InstanciarLista();

            if (dependente == null)
            {
                AddNotification("dependente", "Por favor, adicione um dependente válido");
            }
            
            if (this.IsValid)
            {
                Dependentes.Add(dependente);
            }            
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
            if (pontuacao < 0)
            {
                AddNotification("pontuacao", "Por favor, insira uma pontuação válida");
            }           

            if (this.IsValid)
            {
                PontuacaoFinal += pontuacao;
            }            
        }
    }
}
