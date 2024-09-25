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
}