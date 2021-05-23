using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTest : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Bread Order", "Bread description", 7, 10);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetOrderTitle_ReturnsOrderTitle_String()
    {
      //Arrange
      Order newOrder = new Order("Bread Order", "Bread description", 7, 10);

      //Act
      string result = newOrder.Title;

      //Assert
      Assert.AreEqual(newOrder.Title, result);
    }

    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      //Arrange
      Order newOrder = new Order("Bread Order", "Bread description", 7, 10);

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      //Arrange
      List<Order> list = new List<Order>();

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(list, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      //Arrange
      Order newOrder = new Order("Bread Order", "Bread description", 7, 10);
      Order newOrder2 = new Order("Pastry Order", "Pastry description", 9, 8);
      List<Order> newList = new List<Order> { newOrder, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      //Arrange
      Order newOrder = new Order("Bread Order", "Bread description", 7, 10);
      Order newOrder2 = new Order("Pastry Order", "Pastry description", 9, 8);

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }

  }
}