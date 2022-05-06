using CasaPopular.Entidades;

namespace CasaPopular
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public List<Familia> CriadorDeFamilias()
        {
            List<Familia> familias = new List<Familia>();

            Familia familia1 = new Familia("Família 1", 1000);
            Familia familia2 = new Familia("Família 2", 10000);
            Familia familia3 = new Familia("Família 3", 900);
            Familia familia4 = new Familia("Família 4", 1500);
            Familia familia5 = new Familia("Família 5", 500);
            Familia familia6 = new Familia("Família 6", 2000);

            familia1.AdicionarDependente(new Dependente("Dependente 1 Família 1", 1));
            familia1.AdicionarDependente(new Dependente("Dependente 2 Família 1", 5));
            familia1.AdicionarDependente(new Dependente("Dependente 3 Família 1", 7));

            return familias;
        }

       
    }
}