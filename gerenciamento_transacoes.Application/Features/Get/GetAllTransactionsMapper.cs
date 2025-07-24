using AutoMapper;
using gerenciamento_transacoes.Domain.Entities;

namespace gerenciamento_transacoes.Application.Features.Get
{
    public sealed class GetAllTransactionsMapper : Profile
    {
        public GetAllTransactionsMapper()
        {
            CreateMap<Transaction, GetAllTransactionsResponse>();
        }
    }
}
