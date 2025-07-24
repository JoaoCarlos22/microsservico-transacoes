using gerenciamento_transacoes.Application.Interfaces;
using gerenciamento_transacoes.Persistence.Context;
using gerenciamento_transacoes.Persistence.Repository;
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMongoDB(connection, database);
            });
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITransactionsRepository, TransactionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
