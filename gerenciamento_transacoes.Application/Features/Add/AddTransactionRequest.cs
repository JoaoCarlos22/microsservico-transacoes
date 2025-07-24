using MediatR;

namespace gerenciamento_transacoes.Application.Features.Add
{
    public sealed record AddTransactionRequest(
        double Value,
        string NameSender,
        string NameReceiver,
        DateTime Date) : IRequest<AddTransactionResponse>;
}
