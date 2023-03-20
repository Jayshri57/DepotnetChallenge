using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;
using System.Linq;

namespace RefactoringChallenge.Repository
{
    public class OrderDetailsRepository : IOrderDetailRepository
    {
        protected readonly NorthwindDbContext _northwindDbContext;
        private readonly IMapper _mapper;

        public OrderDetailsRepository(NorthwindDbContext context, IMapper mapper) 
        {
            _northwindDbContext = context;
            _mapper = mapper;
        }

        public void UpdateOrderDetails(List<OrderDetail> orderDetails)
        {
            _northwindDbContext.OrderDetails.AddRange(orderDetails);
        }

        public OrderDetail GetOrderDetails(int orderId)
        {
            var result = _northwindDbContext.OrderDetails.FirstOrDefault(od => od.OrderId == orderId);
            //return (OrderDetail)result;
            return result;
        }

        public void DeleteOrderDetails(OrderDetail orderDetails)
        {
            _northwindDbContext.OrderDetails.RemoveRange(orderDetails);
        }

        public void SaveChangesOrderDetails()
        {
            _northwindDbContext.SaveChanges();
        }
    }
}
