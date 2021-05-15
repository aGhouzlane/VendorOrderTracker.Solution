using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Vendor
  {
    private static List<Vendor> vendors = new List<Vendor> { };
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public List<Order> Orders { get; set; }

    public Vendor(string firstName, string lastName, string address, string description)
    {
      FirstName = firstName;
      LastName = lastName;
      Address = address;
      Description = description;
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