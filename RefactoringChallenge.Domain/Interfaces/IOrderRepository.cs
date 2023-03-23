using RefactoringChallenge.Domain.Entities;
using System.Collections.Generic;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IOrderRepository 
    {        
        List<OrderResponse> GetAll(int? skip = null, int? take = null);
        OrderResponse GetOrderResponse(int orderId);
        Order AddOrder(Order order);
        void SaveChangesOrders();
        Order GetOrder(int orderId);
        void DeleteOrder(Order order);

    }
}
