using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Application
{
    public class ProductManager
    {
        public void Test()
        {
            //in memory collection
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Camera", Price = 1000 });
            products.Add(new Product { Id = 2, Name = "Laptop", Price = 2000 });
            var selectedProduct = products.Where(x => x.Name == "Camera").FirstOrDefault();
            products.Remove(selectedProduct);

            //Repository Design Pattern

            ProductRepository productsRepository = new ProductRepository();
            productsRepository.Add(new Product { Id = 1,Name = "Camera", Price = 1000 });
            productsRepository.Add(new Product { Id = 2,Name = "Laptop", Price = 2000 });
            var selectedProduct2 = productsRepository.GetProductByName("Camera");
            productsRepository.Remove(selectedProduct2);

            //Entity Framework
            /*
             * ApplicationDbContext context = new ApplicationDbContext();
             * context.Product.Add(new Product { Id = 1,Name = "Camera", Price = 1000 });
             * context.Product.Add(new Product { Id = 2,Name = "Laptop", Price = 2000 });
             * var selectedProduct3 = context.Product.Where(x =>x.Name== "Camera");
             * context.Product.Remove(selectedProduct3);
             * 
             * 
             */

        }

    }
}
