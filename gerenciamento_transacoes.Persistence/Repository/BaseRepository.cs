using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Domain.Common;
using gerenciamento_transacoes.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_transacoes.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task Create(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }
    }
}
