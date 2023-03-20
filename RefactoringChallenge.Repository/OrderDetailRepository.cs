using System;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;

namespace RefactoringChallenge.Repository
{
    public class OrderDetailsRepository : IOrderDetailRepository
    {
        protected readonly NorthwindDbContext _context;
        private readonly IMapper _mapper;

        public OrderDetailsRepository(NorthwindDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        //public void Add(List<OrderDetail> newOrderDetails)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(bool orderDetail)
        //{
        //    _context.Set<OrderDetail>().RemoveRange();
        //}        

    }
}
