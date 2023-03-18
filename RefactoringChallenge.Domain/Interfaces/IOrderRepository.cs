using RefactoringChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefactoringChallenge.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        //Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName);
    }
}
