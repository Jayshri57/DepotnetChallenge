using RefactoringChallenge.Controllers;
using RefactoringChallenge.Domain.Entities;
using RefactoringChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactoringChallenge.ServiceManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<OrderResponse> GetAll(int? skip = null, int? take = null)
        {
            return _unitOfWork.Orders.GetAll(skip, take);
        }

        public OrderResponse GetOrderResponse(int orderId)
        {
            return _unitOfWork.Orders.GetOrderResponse(orderId);
        }

        public Order AddOrder(Order order)
        {
            return _unitOfWork.Orders.AddOrder(order);
        }
        public void SaveChangesOrders()
        {
            _unitOfWork.Orders.SaveChangesOrders();
            // _unitOfWork.OrderDetail.SaveChangesOrders();
        }

        public void SaveChangesOrderDetails()
        {            
             _unitOfWork.OrderDetail.SaveChangesOrderDetails();
        }

        public void UpdateOrderDetails(List<OrderDetail> orderDetails)
        {
             _unitOfWork.OrderDetail.UpdateOrderDetails(orderDetails);
        }

        public OrderDetail GetOrderDetails(int orderId)
        {
            return _unitOfWork.OrderDetail.GetOrderDetails(orderId);
        }

        public void DeleteOrderDetails(OrderDetail orderDetails)
        {
            _unitOfWork.OrderDetail.DeleteOrderDetails(orderDetails);
        }

        public Order GetOrder(int orderId)
        {
            return _unitOfWork.Orders.GetOrder(orderId);
        }

        public void DeleteOrder(Order order)
        {
            _unitOfWork.Orders.DeleteOrder(order);
        }
    }
}
