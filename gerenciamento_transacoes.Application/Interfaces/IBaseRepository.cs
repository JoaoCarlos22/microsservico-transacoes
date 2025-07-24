using gerenciamento_transacoes.Domain.Common;

namespace gerenciamento_transacoes.Application.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
