using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RefactoringChallenge.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailsRepository(NorthwindDbContext context) : base(context)
        {

        }
        
        public void Delete(bool orderDetail)
        {
            _context.Set<OrderDetail>().RemoveRange();
        }

        public async Task<List<OrderDetail>> Add(List<OrderDetail> newOrderDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetById(int orderId)
        {
            return await _context.Set<Order>().FindAsync(orderId);
        }
    }
}
