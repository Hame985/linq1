using System;
using System.Collections.Generic;
using System.Linq;

namespace linq11
{

  

   
    
        class Program
        {
            static void Main()
            {
                var products = GetProducts();
                var orders = GetOrders();

                var q1 = products.Where(p => p.Category == "Seafood");
                var q2 = products.Select(p => p.Name);
                var q3 = products.OrderBy(p => p.UnitPrice);
                var q4 = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
                var q5 = products.Where(p => p.Category == "Condiments" && p.UnitsInStock > 0);

                var q6 = products.Select(p => new {
                    p.Name,
                    p.UnitPrice,
                    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                });

                var q7 = products.Select((p, i) => $"{i + 1}. {p.Name}");

                var q8 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

                var q9 = products.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);

                var q10 =
                    from o in orders
                    where o.OrderDate.Year >= 1997
                    select new { o.CustomerID, o.OrderDate };

            }

            static List<Product> GetProducts()
            {
                return new List<Product>{
                new Product{Id=1,Name="Chai",Category="Beverages",UnitPrice=18,UnitsInStock=39},
                new Product{Id=2,Name="Ikura",Category="Seafood",UnitPrice=31,UnitsInStock=20},
                new Product{Id=3,Name="Tofu",Category="Seafood",UnitPrice=23,UnitsInStock=0},
                new Product{Id=4,Name="Chef Anton",Category="Condiments",UnitPrice=22,UnitsInStock=53}
            };
            }

            static List<Order> GetOrders()
            {
                return new List<Order>{
                new Order{OrderId=1,CustomerID="C001",OrderDate=new DateTime(1996,5,1)},
                new Order{OrderId=2,CustomerID="C002",OrderDate=new DateTime(1997,3,10)},
                new Order{OrderId=3,CustomerID="C003",OrderDate=new DateTime(1998,7,21)}
            };
            }
        }
    }
