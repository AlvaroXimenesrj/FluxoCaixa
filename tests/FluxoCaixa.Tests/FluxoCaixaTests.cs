using FluxoCaixa.Api.Services.Commands;
using FluxoCaixa.Core.Domain;

namespace FluxoCaixa.Tests
{
    public class FluxoCaixaTests
    {

        [Fact]
        public void Deve_informar_valores_corretos_para_instanciar_uma_transacao()
        {
            // Arrange

            var tipoTransacao = TipoTransacao.credito;
            decimal valor = 100;
            string descricao = "teste";

            // Act

            var transacao = Transacao.TransacaoFactory(tipoTransacao, 100, descricao,1);

            // Assert

            Assert.Equal(transacao.Valor, valor);
            Assert.Equal(transacao.TipoTransacao, tipoTransacao);
            Assert.Equal(transacao.Descricao, descricao);            
        }

        [Fact]
        public void Deve_atualizar_saldo_correto_apos_debito()
        {
            // Arrange

            var caixa = new Caixa(100);
            decimal valorParaDebitar = 30;
            var tipoTransacao = TipoTransacao.debito;

            // Act

            caixa.AtualizarSaldo(valorParaDebitar, tipoTransacao);
            

            // Assert

            Assert.Equal(caixa.Saldo, 70);            
        }

        [Fact]
        public void Deve_atualizar_saldo_correto_apos_credito()
        {
            // Arrange

            var caixa = new Caixa(100);
            decimal valorParaDebitar = 50;
            var tipoTransacao = TipoTransacao.credito;

            // Act

            caixa.AtualizarSaldo(valorParaDebitar, tipoTransacao);


            // Assert

            Assert.Equal(caixa.Saldo, 150);
        }

        [Fact]
        public void A_descricao_da_transaca_deve_ser_informada_no_command_da_transacao()
        {
            // Arrange

            var command = new TransacaoCommand()
            {
                Tipo = "credito",
                Valor = 10,
                CaixaId = 1
            };

            var caixa = new Caixa(200);

            // Act

            var isValid = command.ValidarTransacao(command, caixa);            

            // Assert

            Assert.False(isValid);
            Assert.Equal(command.ValidationResult.Errors[0].ErrorMessage, "A descrição precisa ser informada");
        }

        [Fact]
        public void Eh_necessario_saldo_suficiente_para_debitar_da_conta()
        {
            // Arrange

            var command = new TransacaoCommand()
            {
                Descricao = "teste",
                Tipo = "debito",
                Valor = 300,
                CaixaId = 1
            };

            var caixa = new Caixa(200);

            // Act

            var isValid = command.ValidarTransacao(command, caixa);

            // Assert

            Assert.False(isValid);
            Assert.Equal(command.ValidationResult.Errors[0].ErrorMessage, "Não há saldo suficiente para realizar o débito");
        }
    }
}