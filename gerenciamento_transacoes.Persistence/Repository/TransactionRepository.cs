using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Domain.Entities;
using gerenciamento_transacoes.Persistence.Context;

namespace gerenciamento_transacoes.Persistence.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionsRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
