using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RefactoringChallenge.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository, IOrderDetailRepository
    {
        public OrderRepository(NorthwindDbContext context) : base(context)
        {

        }

        public async Task<Order> GetById(int orderId)
        {          
            return await _context.Set<Order>().FindAsync(orderId);
        }       

        public void Delete(Task<Order> order)
        {
            _context.Set<Order>().RemoveRange();
        }

        public void Delete(bool orderDetails)
        {
            throw new NotImplementedException();
        }

        Task<OrderDetail> IGenericRepository<OrderDetail>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<OrderDetail>> IGenericRepository<OrderDetail>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
