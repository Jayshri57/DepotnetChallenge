using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mapster;
using MapsterMapper;
using RefactoringChallenge.Controllers;

namespace RefactoringChallenge.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly NorthwindDbContext _context;

        private readonly IMapper _mapper;
        public OrderRepository(NorthwindDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        //public IQueryable<OrderResponse> GetAll(int? skip = null, int? take = null)
        //{
        //    // var query = _northwindDbContext.Orders;
        //    var query = _context.Orders;


        //    if (skip != null)
        //    {
        //        query.Skip(skip.Value);
        //    }
        //    if (take != null)
        //    {
        //        query.Take(take.Value);
        //    }
        //    var result = _mapper.From(query).ProjectToType<OrderResponse>().ToList();
        //    return (IQueryable<OrderResponse>)result;
        //}


        public async Task<Order> GetById(int orderId)
        {          
            return await _context.Set<Order>().FindAsync(orderId);
        }       

        public void Delete(Task<Order> order)
        {
            _context.Set<Order>().RemoveRange();
        }

        public List<OrderResponse> GetAll(int? skip = null, int? take = null)
        {
            var query = _context.Orders;


            if (skip != null)
            {
                query.Skip(skip.Value);
            }
            if (take != null)
            {
                query.Take(take.Value);
            }
            var result = _mapper.From(query).ProjectToType<OrderResponse>().ToList();
            //return (IQueryable<OrderResponse>)result;
            return result;
        }

        
    }
}
