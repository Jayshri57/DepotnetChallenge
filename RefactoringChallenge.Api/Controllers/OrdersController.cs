﻿using Microsoft.AspNetCore.Mvc;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Mapster;
using System.Linq;

namespace RefactoringChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // GET: api/<Orders>
        [HttpGet(nameof(GetOrders))]
        public async Task<IActionResult> GetOrders() => Ok(await _unitOfWork.Orders.GetAll());

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById([FromQuery] int orderId) => Ok(await _unitOfWork.Orders.GetById(orderId));

        [HttpPost("[action]")]
        public IActionResult Create(
           string customerId,
           int? employeeId,
           DateTime? requiredDate,
           int? shipVia,
           decimal? freight,
           string shipName,
           string shipAddress,
           string shipCity,
           string shipRegion,
           string shipPostalCode,
           string shipCountry,
           IEnumerable<OrderDetailRequest> orderDetails
           )
        {
            var newOrderDetails = new List<OrderDetail>();
            foreach (var orderDetail in orderDetails)
            {
                newOrderDetails.Add(new OrderDetail
                {
                    ProductId = orderDetail.ProductId,
                    Discount = orderDetail.Discount,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                });
            }

            var newOrder = new Order
            {
                CustomerId = customerId,
                EmployeeId = employeeId,
                OrderDate = DateTime.Now,
                RequiredDate = requiredDate,
                ShipVia = shipVia,
                Freight = freight,
                ShipName = shipName,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipRegion = shipRegion,
                ShipPostalCode = shipPostalCode,
                ShipCountry = shipCountry,
                OrderDetails = newOrderDetails,
            };

            var result = _unitOfWork.Orders.Add(newOrder);

            _unitOfWork.Complete();

            if (result != null) return Ok("Product Created");
            else return BadRequest("Error in Creating the Product");
        }

        [HttpPost("{orderId}/[action]")]
        public IActionResult AddProductsToOrder([FromRoute] int orderId, IEnumerable<OrderDetailRequest> orderDetails)
        {
            var order = _unitOfWork.Orders.GetById(orderId);

            if (order == null)
                return NotFound();

            var newOrderDetails = new List<OrderDetail>();
            foreach (var orderDetail in orderDetails)
            {
                newOrderDetails.Add(new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = orderDetail.ProductId,
                    Discount = orderDetail.Discount,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                });
            }

            //_northwindDbContext.OrderDetails.AddRange(newOrderDetails);
            //_northwindDbContext.SaveChanges();

            //return Json(newOrderDetails.Select(od => od.Adapt<OrderDetailResponse>()));

            _unitOfWork.OrderDetail.Add(newOrderDetails);
            _unitOfWork.Complete();

            var result = (newOrderDetails.Select(od => od.Adapt<OrderDetailResponse>()));
            if (result != null) return Ok("Product Created");
            else return BadRequest("Error in Creating the Product");
        }

        //[HttpPost("[action]")]
        //public IActionResult Create(
        //    string customerId,
        //    int? employeeId,
        //    DateTime? requiredDate,
        //    int? shipVia,
        //    decimal? freight,
        //    string shipName,
        //    string shipAddress,
        //    string shipCity,
        //    string shipRegion,
        //    string shipPostalCode,
        //    string shipCountry,
        //    IEnumerable<OrderDetailRequest> orderDetails
        //    )
        //{
        //    var newOrderDetails = new List<OrderDetail>();
        //    foreach (var orderDetail in orderDetails)
        //    {
        //        newOrderDetails.Add(new OrderDetail
        //        {
        //            ProductId = orderDetail.ProductId,
        //            Discount = orderDetail.Discount,
        //            Quantity = orderDetail.Quantity,
        //            UnitPrice = orderDetail.UnitPrice,
        //        });
        //    }

        //    var newOrder = new Order
        //    {
        //        CustomerId = customerId,
        //        EmployeeId = employeeId,
        //        OrderDate = DateTime.Now,
        //        RequiredDate = requiredDate,
        //        ShipVia = shipVia,
        //        Freight = freight,
        //        ShipName = shipName,
        //        ShipAddress = shipAddress,
        //        ShipCity = shipCity,
        //        ShipRegion = shipRegion,
        //        ShipPostalCode = shipPostalCode,
        //        ShipCountry = shipCountry,
        //        OrderDetails = newOrderDetails,
        //    };
        //    _northwindDbContext.Orders.Add(newOrder);
        //    _northwindDbContext.SaveChanges();

        //    return Json(newOrder.Adapt<OrderResponse>());
        //}

        //[HttpPost("{orderId}/[action]")]
        //public IActionResult AddProductsToOrder([FromRoute] int orderId, IEnumerable<OrderDetailRequest> orderDetails)
        //{
        //    var order = _northwindDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        //    if (order == null)
        //        return NotFound();

        //    var newOrderDetails = new List<OrderDetail>();
        //    foreach (var orderDetail in orderDetails)
        //    {
        //        newOrderDetails.Add(new OrderDetail
        //        {
        //            OrderId = orderId,
        //            ProductId = orderDetail.ProductId,
        //            Discount = orderDetail.Discount,
        //            Quantity = orderDetail.Quantity,
        //            UnitPrice = orderDetail.UnitPrice,
        //        });
        //    }

        //    _northwindDbContext.OrderDetails.AddRange(newOrderDetails);
        //    _northwindDbContext.SaveChanges();

        //    return Json(newOrderDetails.Select(od => od.Adapt<OrderDetailResponse>()));
        //}

        //[HttpPost("{orderId}/[action]")]
        //public IActionResult Delete([FromRoute] int orderId)
        //{
        //    var order = _northwindDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        //    if (order == null)
        //        return NotFound();

        //    var orderDetails = _northwindDbContext.OrderDetails.Where(od => od.OrderId == orderId);

        //    _northwindDbContext.OrderDetails.RemoveRange(orderDetails);
        //    _northwindDbContext.Orders.Remove(order);
        //    _northwindDbContext.SaveChanges();

        //    return Ok();
        //}
    }
}
