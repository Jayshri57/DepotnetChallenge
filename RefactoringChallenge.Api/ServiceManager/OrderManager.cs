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

        
    }
}
