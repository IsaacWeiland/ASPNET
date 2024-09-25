using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Testing.Models;

public class ProductRepository : IProductRepo
{
    private readonly IDbConnection _conn;

    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products;");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id", new { id = id });
    }

    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
    }
}