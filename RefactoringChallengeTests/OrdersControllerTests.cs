using NUnit.Framework;
using Moq;
using RefactoringChallenge.Controllers;
using RefactoringChallenge.ServiceManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RefactoringChallenge.Domain.Entities;

namespace RefactoringChallengeTests
{   
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderManager> _mockOrderManager;
        private OrdersController _controller;

        [SetUp]
        public void Setup()
        {
            _mockOrderManager = new Mock<IOrderManager>();
            _controller = new OrdersController(_mockOrderManager.Object);
        }

        [Test]
        public void Get_ReturnsJsonResult()
        {
            // Arrange
            _mockOrderManager.Setup(x => x.GetAll(null, null)).Returns(new List<OrderResponse>());

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void GetById_WithValidId_ReturnsJsonResult()
        {
            // Arrange
            int orderId = 1;
            _mockOrderManager.Setup(x => x.GetOrderResponse(orderId)).Returns(new OrderResponse());

            // Act
            var result = _controller.GetById(orderId);

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            int orderId = 1;
            _mockOrderManager.Setup(x => x.GetOrderResponse(orderId)).Returns((OrderResponse)null);

            // Act
            var result = _controller.GetById(orderId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void AddProductsToOrder_WithValidData_ReturnsJsonResult()
        {
            // Arrange
            int orderId = 1;
            IEnumerable<OrderDetailRequest> orderDetails = new List<OrderDetailRequest>()
        {
            new OrderDetailRequest() { ProductId = 1, Discount = (float)0.1m, Quantity = 2, UnitPrice = 10 }
        };
            _mockOrderManager.Setup(x => x.GetOrderResponse(orderId)).Returns(new OrderResponse());

            // Act
            var result = _controller.AddProductsToOrder(orderId, orderDetails);

            // Assert
            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void AddProductsToOrder_WithInvalidData_ReturnsNotFoundResult()
        {
            // Arrange
            int orderId = 1;
            IEnumerable<OrderDetailRequest> orderDetails = new List<OrderDetailRequest>()
        {
            new OrderDetailRequest() { ProductId = 1, Discount = (float)0.1m, Quantity = 2, UnitPrice = 10 }
        };
            _mockOrderManager.Setup(x => x.GetOrderResponse(orderId)).Returns((OrderResponse)null);

            // Act
            var result = _controller.AddProductsToOrder(orderId, orderDetails);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Delete_WithValidId_ReturnsOkResult()
        {
            // Arrange
            int orderId = 1;
            Order order = new Order() { OrderId = orderId };
            OrderDetail orderDetail = new OrderDetail() { OrderId = orderId };
            _mockOrderManager.Setup(x => x.GetOrder(orderId)).Returns(order);
            _mockOrderManager.Setup(x => x.GetOrderDetails(orderId)).Returns(orderDetail);

            // Act
            var result = _controller.Delete(orderId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
