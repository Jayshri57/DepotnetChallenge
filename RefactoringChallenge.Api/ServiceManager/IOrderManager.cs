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
    }
}
