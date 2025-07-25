using Azure.Messaging.ServiceBus;
using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Application.Interfaces.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_transacoes.Persistence.ServiceBus
{
    public class SenderMessage : ISenderMessage
    {
        private readonly ServiceBusClient _client;
        //private ServiceBusSender sender;

        public SenderMessage(ServiceBusClient client)
        {
            _client = client;
        }

        public async Task SendMessage(string queue, string message, CancellationToken cancellationToken)
        {
            try
            {
                await using ServiceBusSender sender = _client.CreateSender(queue);
                ServiceBusMessage _message = new ServiceBusMessage(message);
                
                await sender.SendMessageAsync(_message, cancellationToken);
            } catch(Exception error)
            {
                throw;
            }
        }

    }
}
