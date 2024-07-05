using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ProductManagement.Model
{
    public class Product
    {
        // it is required to have a product id and it should be between 1 and 10000
        [Required]
        [Range(minimum: 1, maximum: 10000)]
        [DisplayName("Product Id")]
        public int Id { get; set; }


        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [DisplayName("Product name")]
        public string Name { get; set; }


        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [DisplayName("Description")]
        public string? Description { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 10000)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Category")]
        public Category Category { get; set; }
    }

    // enum for category
    public enum Category
    {
        Electronics = 0,
        Clothing = 1,
        Food = 2,
        Furniture = 3,
        Other = 4,

    }
}