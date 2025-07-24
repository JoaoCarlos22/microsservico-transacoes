using MediatR;

namespace gerenciamento_transacoes.Application.Features.Get
{
    public sealed record GetAllTransactionsRequest : IRequest<List<GetAllTransactionsResponse>>;
}
