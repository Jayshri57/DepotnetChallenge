using RefactoringChallenge.Controllers;
using RefactoringChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IOrderDetailRepository
    {
        void UpdateOrderDetails(List<OrderDetail> orderDetails);        
        void DeleteOrderDetails(OrderDetail orderDetails);
        OrderDetail GetOrderDetails(int orderId);
        void SaveChangesOrderDetails();
    }
}
