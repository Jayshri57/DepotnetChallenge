using System;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }

        int Complete();
    }
}