﻿namespace gerenciamento_transacoes.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
