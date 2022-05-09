using CasaPopular.Entidades;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CasaPopularTest
{    
    public class FamiliaTest
    {

        [Fact(DisplayName = "Instânciar objeto Familia corretamente")]
        [Trait("Familia", "Testes de criação de famílias")]
        public void InstanciarFamiliaCorretamente()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "Família teste 1";

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);

            // Assert
            familia.IsValid.Should().BeTrue();
            familia.RendaTotal.Should().Be(1000, $"Foi passada a renda total de {rendaTotal} para o construtor");
            familia.Nome.Should().Be("Família teste 1", $"Nome passado para o construtor foi {nome}");
            familia.Notifications.Should().HaveCount(0);
        }


        [Fact(DisplayName = "Instânciar objeto Familia incorretamente - nome inválido")]
        [Trait("Familia", "Testes de criação de famílias")]
        public void InstanciarFamiliaIncorretamenteNomeInvalido()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "";

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);

            // Assert
            familia.IsValid.Should().BeFalse();
            familia.Notifications.First(x => x.Key == "nome").Message.Should().Be("Por favor, insira um nome para a família", "Essa é a mensagem que passa para a notificação");
            familia.Notifications.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Instânciar objeto Familia incorretamente - renda total inválida")]
        [Trait("Familia", "Testes de criação de famílias")]
        public void InstanciarFamiliaIncorretamenteRendaTotalInvalida()
        {
            // Arrange && Arrange
            int rendaTotal = -1;
            string nome = "Família teste 2";

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);

            // Assert
            familia.IsValid.Should().BeFalse();
            familia.Notifications.First(x => x.Key == "rendaTotal").Message.Should().Be("Por favor, insira uma renda válida", "Essa é a mensagem que passa para a notificação");
            familia.Notifications.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Instânciar objeto Familia incorretamente - nome e renda total inválidos")]
        [Trait("Familia", "Testes de criação de famílias")]
        public void InstanciarFamiliaIncorretamenteNomeERendaInvalido()
        {
            // Arrange && Arrange
            int rendaTotal = -1;
            string nome = "";

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);

            // Assert
            familia.IsValid.Should().BeFalse();
            familia.Notifications.First(x => x.Key == "nome").Message.Should().Be("Por favor, insira um nome para a família", "Essa é a mensagem que passa para a notificação");
            familia.Notifications.First(x => x.Key == "rendaTotal").Message.Should().Be("Por favor, insira uma renda válida", "Essa é a mensagem que passa para a notificação");
            familia.Notifications.Should().HaveCount(2);
        }

        [Fact(DisplayName = "Inserir um dependente válido a uma família")]
        [Trait("Familia", "Testes de adicionar dependente a um objeto de Familia")]
        public void InstanciarFamiliaCorretamenteEAdicionarDependenteValido()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "Teste família 3";
            Dependente dependente = new Dependente("Dependente teste 1", 10);

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);
            familia.AdicionarDependente(dependente);

            // Assert
            familia.IsValid.Should().BeTrue();            
            familia.Notifications.Should().HaveCount(0);
            familia.Dependentes.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Inserir um dependente null a uma família")]
        [Trait("Familia", "Testes de adicionar dependente a um objeto de Familia")]
        public void InstanciarFamiliaCorretamenteEAdicionarDependenteInvalido()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "Teste família 3";            

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);
            familia.AdicionarDependente(null);

            // Assert
            familia.IsValid.Should().BeFalse();
            familia.Notifications.Should().HaveCount(1);
            familia.Notifications.First(x => x.Key == "dependente").Message.Should().Be("Por favor, adicione um dependente válido", "Essa é a mensagem que passa para a notificação");
            familia.Dependentes.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Inserir uma pontuação válida a uma família")]
        [Trait("Familia", "Testes de adicionar pontuação a um objeto de Familia")]
        public void InstanciarFamiliaCorretamenteEAdicionarPontuacaoValida()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "Teste família 3";
            int pontuacao = 8;

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);
            familia.AdicionarPontuacao(pontuacao);

            // Assert
            familia.IsValid.Should().BeTrue();
            familia.Notifications.Should().HaveCount(0);
            familia.PontuacaoFinal.Should().Be(8);
        }

        [Fact(DisplayName = "Inserir uma pontuação negativa a uma família")]
        [Trait("Familia", "Testes de adicionar dependente a um objeto de Familia")]
        public void InstanciarFamiliaCorretamenteEAdicionarPontuacaoInvalidaNegativa()
        {
            // Arrange && Arrange
            int rendaTotal = 1000;
            string nome = "Teste família 3";
            int pontuacao = -1;

            //Arrange
            Familia familia = new Familia(nome, rendaTotal);
            familia.AdicionarPontuacao(pontuacao);

            // Assert
            familia.IsValid.Should().BeFalse();
            familia.Notifications.Should().HaveCount(1);
            familia.Notifications.First(x => x.Key == "pontuacao").Message.Should().Be("Por favor, insira uma pontuação válida", "Essa é a mensagem que passa para a notificação");            
        }

    }
}
