using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        private static int id = 1;

        [HttpPost]
        public List<Product> CreateProduct([FromBody] Product product)
        {
            product.Id = id++;
            products.Add(product);
            return products;
        }


        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProductById([FromRoute] int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        [HttpPut("{id}")]
        public Product UpdateProduct([FromBody] Product productUpdated, int id)
        {
            Product product = this.GetProductById(id);
            if(product != null)
            {
                product.Description = productUpdated.Description;
                product.Name = productUpdated.Name;
                product.Price = productUpdated.Price;
                product.Quantity = productUpdated.Quantity;
                return product;
            }
            else
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public Boolean DeleteProductById([FromRoute]int id)
        {
            Product product = this.GetProductById(id);
            if(product != null)
            {
                products.Remove(product);
                return true;
            }

            return false;
        }
    }
}
