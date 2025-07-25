using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_transacoes.Application.Interfaces.ServiceBus
{
    public interface ISenderMessage
    {
        Task SendMessage(string queue, string message, CancellationToken cancellationToken);
    }
}
