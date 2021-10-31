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
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>();

        [HttpPost]
        public Product CreateProduct([FromBody]Product product)
        {
            products.Add(product);
            return product;

        }
    }
}
