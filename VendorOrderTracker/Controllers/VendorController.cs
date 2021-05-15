using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace VendorOrderTracker.Controllers
{
  public class VendorController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string firstName, string lastName, Address address, string description)
    {
      Vendor vendor = new Vendor(firstName, lastName, address, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Item> vendorOrder = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", vendorOrder);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/Orders")]
    public ActionResult Create(int vendorId, string orderTitle, string orderDescription, int orderQuantity,
    float orderPrice, DateTime OrderDateTime)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderTitle, orderDescription, orderQuantity, orderPrice, OrderDateTime);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendors", foundVendor);
      return View("Show", model);
    }
  }
}