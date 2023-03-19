using RefactoringChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        //void Add(List<OrderDetail> newOrderDetails);
        void Delete(bool orderDetails);
        void AddAsync(List<OrderDetail> newOrderDetails);
        void Add(List<OrderDetail> newOrderDetails);
    }
}
