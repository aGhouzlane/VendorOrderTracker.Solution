using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTest : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("Ahmed", "Ghouzlane", "123 s 5th st", "Bread vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetFirstName_ReturnsName_String()
    {
      //Arrange
      Vendor newVendor = new Vendor("Ahmed", "Ghouzlane", "123 s 5th st", "Bread vendor");

      //Act
      string result = newVendor.FirstName;

      //Assert
      Assert.AreEqual(newVendor.FirstName, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      //Arrange
      string firstName = "Ahmed";
      string lastName = "Ghouzlane";
      string address = "123 s 15th st";
      string description = "bread vendor";
      Vendor newVendor = new Vendor(firstName, lastName, address, description);

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("Ahmed", "Ghouzlane", "123 s 5th st", "Bread vendor");
      Vendor newVendor2 = new Vendor("Ana", "Gomez", "123 s 5th st", "Pastries vendor");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("Ahmed", "Ghouzlane", "123 s 5th st", "Bread vendor");
      Vendor newVendor2 = new Vendor("Ana", "Gomez", "123 s 5th st", "Pastries vendor");

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      //Arrange
      Order newOrder = new Order("Title", "description", 7, 9);
      List<Order> newList = new List<Order> { newOrder };

      Vendor newVendor = new Vendor("Ahmed", "Ghouzlane", "123 s 5th st", "Bread vendor");
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

  }
}