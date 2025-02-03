using System;
using System.Linq;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class OrderRepositoryTests : BaseRepositoryTest
{
    private OrderRepository _orderRepository;

    [SetUp]
    public void Init() => _orderRepository = new OrderRepository(_context);

    [Test]
    public void Add_ShouldAddOrder()
    {
        var order = new Order { CarId = 1, OrderDate = DateTime.Now, Status = "Pending", TotalCost = 150.75m };
        _orderRepository.Add(order);
        _orderRepository.SaveAsync().Wait();

        var result = _orderRepository.GetById(order.OrderId);
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetAll_ShouldReturnAllOrders()
    {
        var order1 = new Order { CarId = 1, OrderDate = DateTime.Now, Status = "Pending", TotalCost = 100 };
        var order2 = new Order { CarId = 2, OrderDate = DateTime.Now, Status = "Completed", TotalCost = 200 };

        _orderRepository.Add(order1);
        _orderRepository.Add(order2);
        _orderRepository.SaveAsync().Wait();

        var result = _orderRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnOrder()
    {
        var order = new Order { CarId = 3, OrderDate = DateTime.Now, Status = "In Progress", TotalCost = 300 };
        _orderRepository.Add(order);
        _orderRepository.SaveAsync().Wait();

        var result = _orderRepository.GetById(order.OrderId);
        Assert.IsNotNull(result);
    }

    [Test]
    public void Update_ShouldModifyOrderStatus()
    {
        var order = new Order { CarId = 4, OrderDate = DateTime.Now, Status = "Pending", TotalCost = 400 };
        _orderRepository.Add(order);
        _orderRepository.SaveAsync().Wait();

        order.Status = "Shipped";
        _orderRepository.Update(order);
        _orderRepository.SaveAsync().Wait();

        var result = _orderRepository.GetById(order.OrderId);
        Assert.AreEqual("Shipped", result.Status);
    }

    [Test]
    public void Delete_ShouldRemoveOrder()
    {
        var order = new Order { CarId = 5, OrderDate = DateTime.Now, Status = "Delivered", TotalCost = 500 };
        _orderRepository.Add(order);
        _orderRepository.SaveAsync().Wait();

        _orderRepository.Delete(order.OrderId);
        _orderRepository.SaveAsync().Wait();

        var result = _orderRepository.GetById(order.OrderId);
        Assert.IsNull(result);
    }
}
