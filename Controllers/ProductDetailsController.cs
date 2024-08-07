using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private List<Product> list;

        public ProductDetailsController()
        {
            list = new List<Product>();
            list.Add(new Product() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100, Category = Category.Electronics });
            list.Add(new Product() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200, Category = Category.Clothing });

        }

        // get method to get all products with query
        [HttpGet("ByIdQuery")]
        public Product ByIdQuery([FromQuery] int id)
        {
            return list?.FirstOrDefault(x => x.Id == id);
        }

        // get method to get product by id with route
        [HttpGet("ByIdRoute/{id}")]
        public Product ByIdRoute([FromRoute] int id)
        {
            return list?.FirstOrDefault(x => x.Id == id);
        }


        // bydetailquert method to get product by id with query and other details
        [HttpGet("ByDetailQuery")]
        public string ByIdQuery([FromQuery] int? id, [FromQuery] string? name, [FromQuery] string? author, [FromQuery] int? pageCount)
        {
            return $"id:{id}-name:{name}-author:{author}-pageCount:{pageCount}";
        }

        // bydetailroute method to get product by id with route and other details
        [HttpGet("ByDetailRoute/{id}/{name}/{author}/{pageCount}")]
        public string ByIdRoute(int? id, string? name, string? author, int? pageCount)
        {
            return $"id:{id}-name:{name}-author:{author}-pageCount:{pageCount}";
        }

        // bydetail method to get product by id with route and other details
        [HttpGet("ByDetail/{id}")]
        public string ByDetail(int? id, [FromQuery] string? name, [FromQuery] string? author, [FromQuery] int? pageCount)
        {
            return $"id:{id}-name:{name}-author:{author}-pageCount:{pageCount}";
        }
    }
}