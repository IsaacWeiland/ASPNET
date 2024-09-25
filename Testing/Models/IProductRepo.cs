using System.Collections.Generic;

namespace Testing.Models;

public interface IProductRepo
{ 
    IEnumerable<Product> GetAllProducts();
    Product GetProduct(int id);
}