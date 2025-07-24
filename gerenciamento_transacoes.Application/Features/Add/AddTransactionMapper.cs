using AutoMapper;
using gerenciamento_transacoes.Domain.Entities;

namespace gerenciamento_transacoes.Application.Features.Add
{
    public sealed class AddTransactionMapper : Profile
    {
        public AddTransactionMapper()
        {
            CreateMap<AddTransactionRequest, Transaction>();
            CreateMap<Transaction, AddTransactionResponse>();
        }
    }
}
