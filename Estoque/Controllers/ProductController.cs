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
        public IActionResult CreateProduct([FromBody] Product product)
        {
            product.Id = id++;
            products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id}, product);
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            Product product = products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromBody] Product productUpdated, int id)
        {
            Product product = products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                product.Description = productUpdated.Description;
                product.Name = productUpdated.Name;
                product.Price = productUpdated.Price;
                product.Quantity = productUpdated.Quantity;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById([FromRoute]int id)
        {
            Product product = products.FirstOrDefault(product => product.Id == id);
            if(product != null)
            {
                products.Remove(product);
                return NoContent();
            }

            return NotFound();
        }
    }
}
