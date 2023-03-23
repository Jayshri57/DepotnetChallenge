using RefactoringChallenge.Domain.Entities;
using System.Collections.Generic;

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
