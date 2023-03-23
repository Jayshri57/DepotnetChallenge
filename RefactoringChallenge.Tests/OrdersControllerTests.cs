using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RefactoringChallenge.Controllers;
using RefactoringChallenge.Domain;
using RefactoringChallenge.Domain.Entities;
using RefactoringChallenge.Domain.Interfaces;
using RefactoringChallenge.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactoringChallenge.UnitTests.Controllers
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderManager> _orderManagerMock;
        private OrdersController _ordersController;

        [SetUp]
        public void Setup()
        {
            _orderManagerMock = new Mock<IOrderManager>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.Orders).Returns((IOrderRepository)_orderManagerMock.Object);
            unitOfWorkMock.Setup(uow => uow.OrderDetail).Returns((IOrderDetailRepository)_orderManagerMock.Object);
            _ordersController = new OrdersController(_orderManagerMock.Object);
        }

        [Test]
        public void Get_ReturnsOkObjectResult_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<OrderResponse> { new OrderResponse { OrderId = 1, CustomerId = "ABC", EmployeeId = 1 } };
            _orderManagerMock.Setup(om => om.GetAll(null, null)).Returns(orders);

            // Act
            var result = _ordersController.Get() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var resultValue = result.Value as IEnumerable<OrderResponse>;
            Assert.IsNotNull(resultValue);
            CollectionAssert.AreEqual(orders, resultValue);
        }
    }
}

