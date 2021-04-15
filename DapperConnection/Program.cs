using Dapper;
using eShop.CoreBusiness.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DapperConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectStr = "Data Source=(local);Initial Catalog=eShop;Integrated Security=True";

            var da = new DataAccess(connectStr);
            var result1 = da.Query<Product, dynamic>("SELECT * FROM Product", new { });

            var result2 = da.QuerySingle<Product, dynamic>("SELECT * FROM Product WHERE Name = @Name", new { Name = "My product"});


            foreach (var item in result1)
            {
                Console.WriteLine($"{item.Name}, {item.Price}");
            }

            Console.WriteLine($"{result2.Name}, {result2.Price}");


            //using(IDbConnection conn = new SqlConnection(connectStr))
            //{
            //    var results = conn.Query<Product>("SELECT * FROM Product");

            //    foreach (var item in results)
            //    {
            //        Console.WriteLine($"{item.Name}, {item.Price}");
            //    }

            //var sql = @"INSERT INTO Product (ProductId, Brand, Name, Price) VALUES (@ProductId, @Brand, @Name, @Price)";

            //var prod = new Product { ProductId = 1000003, Brand = "His Brand", Name = "His Product Name", Price = 100 };

            //var sql = @"UPDATE Product
            //            SET ImageLink = @Url
            //            WHERE Name = @Name";

            //conn.Execute(sql, new { Url = "http://www.product.com/1", Name = "His Product Name" });

            //conn.Execute(sql, prod);

            //var sql = @"DELETE FROM Product WHERE Name = @Name";
            //conn.Execute(sql, new { Name = "His Product Name" });
            //}
        }
    }
}
