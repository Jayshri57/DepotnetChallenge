using Microsoft.AspNetCore.Mvc;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Mapster;
using System.Linq;
using MapsterMapper;
using RefactoringChallenge.Repository;
using RefactoringChallenge.ServiceManager;

namespace RefactoringChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        readonly IOrderManager _orderManager;
        public OrdersController(IOrderManager service)
        {
            _orderManager = service;
        }

        // GET: api/<Orders>
        [HttpGet(nameof(Get))]
        public IActionResult Get(int? skip = null, int? take = null)
        {          
            try
            {
                var result = _orderManager.GetAll(skip, take);
                return Json(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult GetById([FromRoute] int orderId)
        {
            try
            {
                var result = _orderManager.GetOrderResponse(orderId);
                if (result == null)
                    return NotFound();

                return Json(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

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
            try
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
                _orderManager.AddOrder(newOrder);
                _orderManager.SaveChangesOrders();

                return Json(newOrder.Adapt<OrderResponse>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{orderId}/[action]")]
        public IActionResult AddProductsToOrder([FromRoute] int orderId, IEnumerable<OrderDetailRequest> orderDetails)
        {
            try
            {
                var order = _orderManager.GetOrderResponse(orderId);
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

                _orderManager.UpdateOrderDetails(newOrderDetails);
                _orderManager.SaveChangesOrderDetails();

                return Json(newOrderDetails.Select(od => od.Adapt<OrderDetailResponse>()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{orderId}/[action]")]
        public IActionResult Delete([FromRoute] int orderId)
        {
            try
            {
                var order = _orderManager.GetOrder(orderId);
                if (order == null)
                    return NotFound();

                var orderDetails = _orderManager.GetOrderDetails(orderId);
                if (orderDetails == null)
                    return NotFound();

                _orderManager.DeleteOrderDetails(orderDetails);
                _orderManager.SaveChangesOrderDetails();
                _orderManager.DeleteOrder(order);
                _orderManager.SaveChangesOrders();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
