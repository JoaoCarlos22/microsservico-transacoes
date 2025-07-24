using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Persistence.Context;

namespace gerenciamento_transacoes.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public Task SaveChanges(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
