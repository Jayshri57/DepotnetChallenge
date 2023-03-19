using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RefactoringChallenge.Domain.Interfaces;

namespace RefactoringChallenge.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer("Server=.;Database=Northwind;Trusted_Connection=True;"));
            
            return services;
        }
       
    }
}
