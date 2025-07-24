using gerenciamento_transacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace gerenciamento_transacoes.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public static AppDbContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<AppDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);


        public DbSet<Transaction> Transactions { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().ToCollection("details");
        }
    }
}
