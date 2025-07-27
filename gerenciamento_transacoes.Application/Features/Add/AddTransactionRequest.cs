using MediatR;

namespace gerenciamento_transacoes.Application.Features.Add
{
    public sealed record AddTransactionRequest(
        double Value,
        string Description,
        string NameSender,
        string NameReceiver,
        DateTime Date) : IRequest<string>;
}
