using RefactoringChallenge.Controllers;
using RefactoringChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactoringChallenge.ServiceManager
{
    public interface IOrderManager
    {
        List<OrderResponse> GetAll(int? skip = null, int? take = null);
        OrderResponse GetOrderResponse(int orderId);
        Order AddOrder(Order order);
        void SaveChangesOrders();
        void SaveChangesOrderDetails();
        void UpdateOrderDetails(List<OrderDetail> orderDetails);
        OrderDetail GetOrderDetails(int orderId);
        Order GetOrder(int orderId);
        void DeleteOrderDetails(OrderDetail orderDetails);        
        void DeleteOrder(Order order);
    }
}
