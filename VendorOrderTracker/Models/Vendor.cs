using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Address
  {
    public int StreetNumber { get; }
    public string StreetName { get; }
    public string City { get; }
    public string State { get; }
    public int ZipCode { get; }
  }
  public class Vendor
  {
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public Address Address { get; }
    public string Description { get; set; }
    public List<Order> Orders { get; set; }
    private static List<Vendor> vendors = new List<Vendor> { };
    public Vendor(string firstName, string lastName, Address address, string description)
    {
      FirstName = firstName;
      LastName = lastName;
      Address.StreetNumber = address.StreetNumber;
      Address.StreetName = address.StreetName;
      Address.City = address.City;
      Address.State = address.State;
      Address.ZipCode = address.ZipCode;
      vendors.Add(this);
      Id = vendors.Count;
      Orders = new List<Order> { };
    }

    public static void ClearAll()
    {
      vendors.Clear();
    }

    public static List<Vendor> GetAll()
    {
      return vendors;
    }

    public static Vendor Find(int searchId)
    {
      return vendors[searchId - 1];
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}