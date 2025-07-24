using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_transacoes.Application.Features.Get
{
    public sealed record GetAllTransactionsResponse
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public double Value { get; set; }
        public string NameSender { get; set; }
        public string NameReceiver { get; set; }
        public DateTime Date { get; set; }
    }
}
