﻿using RefactoringChallenge.Controllers;
using RefactoringChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IOrderRepository 
    {
        Task<Order> GetById(int orderId);
        void Delete(Task<Order> order);
        List<OrderResponse> GetAll(int? skip = null, int? take = null);
        
    }
}
