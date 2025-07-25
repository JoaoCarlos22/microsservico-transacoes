using Azure.Identity;
using Azure.Messaging.ServiceBus;
using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Application.Interfaces.ServiceBus;
using gerenciamento_transacoes.Persistence.Context;
using gerenciamento_transacoes.Persistence.Repository;
using gerenciamento_transacoes.Persistence.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gerenciamento_transacoes.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DatabaseUrl");
            var database = configuration["ConnectionStrings:DatabaseName"];
            var serviceBusNamespace = configuration["AzureServiceBus:Namespace"];

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMongoDB(connection, database);
            });

            services.AddSingleton(provider =>
            {
                var clientOptions = new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets
                };
                return new ServiceBusClient(serviceBusNamespace, new DefaultAzureCredential(), clientOptions);
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITransactionsRepository, TransactionRepository>();
            services.AddScoped<ISenderMessage, SenderMessage>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
