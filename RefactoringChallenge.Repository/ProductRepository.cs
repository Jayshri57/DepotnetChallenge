using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;

namespace RefactoringChallenge.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindDbContext context) : base(context)
        {

        }
    }
}
