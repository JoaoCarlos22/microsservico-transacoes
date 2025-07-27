using AutoMapper;
using gerenciamento_transacoes.Application.Features.Add;
using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Domain.Entities;
using MongoDB.Bson;
using Moq;

namespace gerenciamento_transacoes.Test
{
    public class AddTransactionTest
    {
        [Fact]
        public async Task HandleAddTransaction()
        {
            // Mock das dependencias
            var mockTransactionRepository = new Mock<ITransactionsRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockMapper = new Mock<IMapper>();

            // Simulação dos valores
            var request = new AddTransactionRequest(
                Value: 100.0,
                Description: "test",
                NameSender: "joca",
                NameReceiver: "bala",
                Date: DateTime.UtcNow
            );

            var transactionEntity = new Transaction
            {
                Value = request.Value,
                NameSender = request.NameSender,
                NameReceiver = request.NameReceiver,
                Date = request.Date,
                CreatedAt = DateTime.UtcNow
            };
                
            var generatedId = ObjectId.GenerateNewId().ToString();

            // Configuração do comportamento dos mocks:

            // 1. AutoMapper
            mockMapper.Setup(m => m.Map<Transaction>(It.IsAny<AddTransactionRequest>()))
                      .Returns(transactionEntity);

            // 2. ITransactionsRepository
            mockTransactionRepository.Setup(r => r.Create(
                It.IsAny<Transaction>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask); // Simula que a operação assíncrona foi concluída

            // 3. IUnitOfWork
            mockUnitOfWork.Setup(u => u.SaveChanges(It.IsAny<CancellationToken>()))
                          .Callback(() =>
                          { 
                              transactionEntity.Id = generatedId;
                          })
                          .Returns(Task.CompletedTask);
        }
    }
}
