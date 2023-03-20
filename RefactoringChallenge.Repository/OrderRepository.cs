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
        protected readonly NorthwindDbContext _northwindDbContext;

        private readonly IMapper _mapper;
        public OrderRepository(NorthwindDbContext context, IMapper mapper) 
        {
            _northwindDbContext = context;
            _mapper = mapper;
        }  

        public List<OrderResponse> GetAll(int? skip = null, int? take = null)
        {
            var query = _northwindDbContext.Orders;


            if (skip != null)
            {
                query.Skip(skip.Value);
            }
            if (take != null)
            {
                query.Take(take.Value);
            }
            var result = _mapper.From(query).ProjectToType<OrderResponse>().ToList();
            return result;
        }

        public OrderResponse GetOrderResponse(int orderId)
        {
            var result = _mapper.From(_northwindDbContext.Orders).ProjectToType<OrderResponse>().FirstOrDefault(o => o.OrderId == orderId);
            return result;
        }

        public Order AddOrder(Order order)
        {
            var result = _northwindDbContext.Orders.Add(order);
            return result.Adapt<Order>();
        }

        public void SaveChangesOrders()
        {
             _northwindDbContext.SaveChanges();           
        }

        public Order GetOrder(int orderId)
        {
            var result = _northwindDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            return result;
        }
        public void DeleteOrder(Order order)
        {
            _northwindDbContext.Remove(order);
        }


    }
}
