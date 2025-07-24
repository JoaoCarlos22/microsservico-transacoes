using AutoMapper;
using gerenciamento_transacoes.Application.Interfaces;
using MediatR;

namespace gerenciamento_transacoes.Application.Features.Get
{
    public sealed class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsRequest, List<GetAllTransactionsResponse>>
    {
        private readonly ITransactionsRepository _TransactionsRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsHandler(ITransactionsRepository TransactionsRepository, IMapper mapper)
        {
            _TransactionsRepository = TransactionsRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTransactionsResponse>> Handle(GetAllTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _TransactionsRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllTransactionsResponse>>(transactions);
        }
    }
}
