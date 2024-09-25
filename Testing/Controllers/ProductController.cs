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
}