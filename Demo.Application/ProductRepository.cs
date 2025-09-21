using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Application
{
    public class ProductRepository
    {
        public void Add(Product product)
        {
             
        }

        public void Update(Product product)
        {

        }
        public void Remove(Product product)
        {

        }

        public Product Get(int id) 
        { 

        }
        public List<Product> GetAll() 
        { 

        }

        public Product GetProductByName(String name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetMostPopularProductsForThisMonths()
        {
            throw new NotImplementedException();
        }
    }
}