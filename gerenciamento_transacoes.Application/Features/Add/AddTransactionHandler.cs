using AutoMapper;
using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Domain.Entities;
using MediatR;
using MongoDB.Bson;

namespace gerenciamento_transacoes.Application.Features.Add
{
    public sealed class AddTransactionHandler : IRequestHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionsRepository _transactionRepository;
        private readonly IMapper _mapper;

        public AddTransactionHandler(IUnitOfWork unitOfWork,
            ITransactionsRepository transactionRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<AddTransactionResponse> Handle(AddTransactionRequest req, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(req);
            if (string.IsNullOrEmpty(transaction.Id))
            {
                transaction.Id = ObjectId.GenerateNewId().ToString();
            }
            await _transactionRepository.Create(transaction, cancellationToken);
            await _unitOfWork.SaveChanges(cancellationToken);

            return new AddTransactionResponse
            {
                Id = transaction.Id
            };
        }
    }
}
