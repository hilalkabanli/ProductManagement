using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using ProductManagement;
using ProductManagement.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private List<Product> list;
        // productscontroller constructor to initialize the list of products
        public ProductsController()
        {
            list = new List<Product>();
            list.Add(new Product() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100, Category = Category.Electronics });
            list.Add(new Product() { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200, Category = Category.Clothing });
            list.Add(new Product() { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300, Category = Category.Food });
            list.Add(new Product() { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400, Category = Category.Furniture });
            list.Add(new Product() { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500, Category = Category.Other });
            list.Add(new Product() { Id = 6, Name = "Product 6", Description = "Description 6", Price = 600, Category = Category.Electronics });
            list.Add(new Product() { Id = 7, Name = "Product 7", Description = "Description 7", Price = 700, Category = Category.Clothing });
        }

        // get method to get all products
        [HttpGet]
        public ApiResponse<List<Product>> Get()
        {
            return new ApiResponse<List<Product>>(list);

        }

        // get method to get product by id
        [HttpGet("{id}")]
        public ApiResponse<Product> Get(int id)
        {
            var item = list?.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<Product>("Item not found in system.");
            }

            return new ApiResponse<Product>(item);
        }

        // post method to add a product
        [HttpPost]
        public ApiResponse<List<Product>> Post([FromBody] Product product)
        {
            list.Add(product);
            return new ApiResponse<List<Product>>(list);
        }

        // put method to update a product
        [HttpPut("{id}")]
        public ApiResponse<List<Product>> Put(int id, [FromBody] Product product)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<List<Product>>("Item not found in system.");
            }
            list.Remove(item);
            list.Add(product);
            return new ApiResponse<List<Product>>(list);
        }


        // delete method to delete a product
        [HttpDelete("{id}")]
        public ApiResponse<List<Product>> Delete(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<List<Product>>("Item not found in system.");
            }

            list.Remove(item);

            return new ApiResponse<List<Product>>(list);
        }
        // patch method to update a product
        [HttpPatch("{id}")]
        public async Task<ApiResponse<List<Product>>> Patch(int id, [FromBody] Product product)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<List<Product>>("Item not found in system.");
            }

            var index = list.IndexOf(item);
            list[index] = product;

            return new ApiResponse<List<Product>>(list);

        }

        // get method to get filtered products
        [HttpGet("list")]
        public ApiResponse<List<Product>> GetFilteredProducts([FromQuery] string name, [FromQuery] string category, [FromQuery] string sortBy)
        {
            var query = list.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(category) && Enum.TryParse(category, out Category cat))
            {
                query = query.Where(p => p.Category == cat);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy.ToLower() switch
                {
                    "name" => query.OrderBy(p => p.Name),
                    "price" => query.OrderBy(p => p.Price),
                    _ => query
                };
            }

            var result = query.ToList();
            return new ApiResponse<List<Product>>(result);
        }
    }

}