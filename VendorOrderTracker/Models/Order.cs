using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Order
  {
    public int Id { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public DateTime DateTime { get; set; }
    private static List<Order> orders = new List<Order> { };
    public Order(string title, string description, float price)
    {
      Title = title;
      Description = description;
      Price = price;
      orders.Add(this);
      Id = orders.Count;
      DateTime = DateTime.Now;
    }
    public static List<Item> GetAll()
    {
      return orders;
    }

    public static void ClearAll()
    {
      orders.Clear();
    }

    public static Order Find(int searchId)
    {
      return orders[searchId - 1];
    }
  }
}