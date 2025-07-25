using AutoMapper;
using gerenciamento_transacoes.Application.DTOs;
using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Application.Interfaces.ServiceBus;
using gerenciamento_transacoes.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace gerenciamento_transacoes.Application.Features.Add
{
    public sealed class AddTransactionHandler : IRequestHandler<AddTransactionRequest, AddTransactionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionsRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ISenderMessage _messageProducer;

        public AddTransactionHandler(IUnitOfWork unitOfWork,
            ITransactionsRepository transactionRepository, IMapper mapper,
            IConfiguration configuration, ISenderMessage messageProducer)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _configuration = configuration;
            _messageProducer = messageProducer;
        }

        public async Task<AddTransactionResponse> Handle(AddTransactionRequest req, CancellationToken cancellationToken)
        {
            // persistencia da transicao no BD
            var transaction = _mapper.Map<Transaction>(req);
            if (string.IsNullOrEmpty(transaction.Id))
            {
                transaction.Id = ObjectId.GenerateNewId().ToString();
            }
            await _transactionRepository.Create(transaction, cancellationToken);
            await _unitOfWork.SaveChanges(cancellationToken);

            // envio da mensagem ServiceBus
            var queueName = _configuration["AzureServiceBus:QueueName"];
            var messageContent = System.Text.Json.JsonSerializer.Serialize(new TransactionDto
            {
                Id = transaction.Id,
                Value = transaction.Value,
                NameReceiver = transaction.NameReceiver,
                NameSender = transaction.NameSender,
                DateOnly = transaction.Date
            });

            await _messageProducer.SendMessage(queueName, messageContent, cancellationToken);

            return new AddTransactionResponse
            {
                Id = transaction.Id
            };
        }
    }
}
