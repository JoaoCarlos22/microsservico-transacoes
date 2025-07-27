using AutoMapper;
using gerenciamento_transacoes.Application.Features.Get;
using gerenciamento_transacoes.Application.Interfaces;
using MongoDB.Bson;
using Moq;
using Transaction = gerenciamento_transacoes.Domain.Entities.Transaction;

namespace gerenciamento_transacoes.Test
{
    public class GetAllTransactionsTest
    {
        [Fact]
        public async Task HandleGetAllTransactions()
        {
            // Mock das dependencias
            var mockTransactionRepository = new Mock<ITransactionsRepository>();
            var mockMapper = new Mock<IMapper>();

            // Simulação das transações
            var transaction1 = SimulationTransaction(100.0, "joao", "carlos");
            var transaction2 = SimulationTransaction(60.0, "carlos", "joao");

            var transactions = new List<Transaction>
            {
                { transaction1 },
                { transaction2 }
            };

            var response1 = SimulationTransactionResponse(transaction1);
            var response2 = SimulationTransactionResponse(transaction2);

            var responses = new List<GetAllTransactionsResponse>
            {
                { response1 },
                { response2 }
            };

            // 1. GetAll
            mockTransactionRepository.Setup(r => r.GetAll(It.IsAny<CancellationToken>()))
                .ReturnsAsync(transactions);

            // 2. AutoMapper
            mockMapper.Setup(m => m.Map<List<GetAllTransactionsResponse>>(It.IsAny<List<Transaction>>()))
                .Returns(responses);
        }

        public static Transaction SimulationTransaction(double value, string nameReceiver, string nameSender)
        {
            return new Transaction
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Value = value,
                NameSender = nameSender,
                NameReceiver = nameReceiver,
                Date = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static GetAllTransactionsResponse SimulationTransactionResponse(Transaction transaction)
        {
            return new GetAllTransactionsResponse
            {
                Id = transaction.Id,
                Value = transaction.Value,
                NameReceiver = transaction.NameReceiver,
                NameSender = transaction.NameSender,
                Date = transaction.Date,
                CreatedAt = transaction.CreatedAt
            };
        }
    }
}
