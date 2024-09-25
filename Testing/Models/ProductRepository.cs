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

    public void InsertProduct(Product productToInsert)
    {
        _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @catid);",
            new { name = productToInsert.Name, price = productToInsert.Price, catid = productToInsert.CategoryID });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _conn.Query<Category>("SELECT * FROM categories");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product
        {
            Categories = categoryList
        };
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id;",
            new { id = product.ProductID });
        _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
            new { id = product.ProductID });
        _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
            new { id = product.ProductID });
    }
}