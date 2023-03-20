using RefactoringChallenge.Domain.Interfaces;
using System;

namespace RefactoringChallenge.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindDbContext _context;
        public IOrderRepository Orders { get; }
        public IOrderDetailRepository OrderDetail { get; }

        public UnitOfWork(NorthwindDbContext northwindDbContext,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            this._context = northwindDbContext;

            this.Orders = orderRepository;
            this.OrderDetail = orderDetailRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
