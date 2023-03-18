using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;

namespace RefactoringChallenge.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindDbContext context) : base(context)
        {

        }
        //public async Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName)
        //{
        //    return await _context.Orders.Where(c => c.OrderDetails.Contains(orderName)).ToListAsync();
        //}
    }
}
