using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepo _repo;

    public ProductController(IProductRepo repo)
    {
        _repo = repo;
    }
    // GET
    public IActionResult Index()
    {
        var products = _repo.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _repo.GetProduct(id);
        return View(product);
    }

    public IActionResult UpdateProduct(int id)
    {
        Product prod = _repo.GetProduct(id);
        if (prod == null)
        {
            return View("ProductNotFound");
        }
        return View(prod);
    }

    public IActionResult UpdateToDatabase(Product product)
    {
        _repo.UpdateProduct(product);
        return RedirectToAction("ViewProduct", new { id = product.ProductID });
    }
}