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
    public class DependenteTest
    {
        [Fact(DisplayName = "Instanciar objeto Dependente corretamente")]
        [Trait("Dependente", "Testes de criação de dependentes")]
        public void InstanciarDependenteCorretamente()
        {
            //Arrange
            int idade = 10;
            string nome = "Dependente teste 1";

            //Act
            Dependente dependente = new Dependente(nome, idade);

            //Assert
            dependente.IsValid.Should().BeTrue();
            dependente.Idade.Should().Be(10, $"Foi passada a idade de {idade} para o construtor");
            dependente.Nome.Should().Be("Dependente teste 1", $"Nome passado para o construtor foi {nome}");
            dependente.Notifications.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Instanciar objeto Dependente incorretamente - nome inválido")]
        [Trait("Dependente", "Testes de criação de dependentes")]
        public void InstanciarDependenteIncorretamenteNomeInvalido()
        {
            //Arrange
            int idade = 10;
            string nome = "";

            //Act
            Dependente dependente = new Dependente(nome, idade);

            //Assert
            dependente.IsValid.Should().BeFalse();
            dependente.Notifications.First(x => x.Key == "nome").Message.Should().Be("Por favor, insira um nome para o dependente", "Essa é a mensagem que passa para a notificação");
            dependente.Notifications.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Instanciar objeto Dependente incorretamente - idade inválida")]
        [Trait("Dependente", "Testes de criação de dependentes")]
        public void InstanciarDependenteIncorretamenteIdadenvalida()
        {
            //Arrange
            int idade = -10;
            string nome = "Dependente teste 1";

            //Act
            Dependente dependente = new Dependente(nome, idade);

            //Assert
            dependente.IsValid.Should().BeFalse();
            dependente.Notifications.First(x => x.Key == "idade").Message.Should().Be("Por favor, insira uma idade válida", "Essa é a mensagem que passa para a notificação");
            dependente.Notifications.Should().HaveCount(1);
        }

        [Fact(DisplayName = "Instanciar objeto Dependente incorretamente - nome e idade inválidos")]
        [Trait("Dependente", "Testes de criação de dependentes")]
        public void InstanciarDependenteIncorretamenteNomeEIdadeInvalidos()
        {
            // Arrange
            int idade = -1;
            string nome = "";

            //Act
            Dependente dependente = new Dependente(nome, idade);

            //Assert
            dependente.IsValid.Should().BeFalse();
            dependente.Notifications.First(x => x.Key == "nome").Message.Should().Be("Por favor, insira um nome para o dependente", "Essa é a mensagem que passa para a notificação");
            dependente.Notifications.First(x => x.Key == "idade").Message.Should().Be("Por favor, insira uma idade válida", "Essa é a mensagem que passa para a notificação");
            dependente.Notifications.Should().HaveCount(2);
        }
    }
}
