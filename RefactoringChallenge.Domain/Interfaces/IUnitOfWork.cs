using System;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IOrderDetailRepository OrderDetail { get; }

        int Complete();
    }
}