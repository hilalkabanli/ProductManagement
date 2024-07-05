using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProductManagement.Model;

namespace ProductManagement.Attribute
{
    public class ProductPriceAttribute : ValidationAttribute
    {
        public ProductPriceAttribute()
        {

        }

        // custom validation for price
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // get the model and check the price
            var model = (Product)validationContext.ObjectInstance;
            ValidationResult result = ValidationResult.Success;
            var price = (int)value;
            if (model.Price >= 2000 || model.Price <= 0)
            {

                return new ValidationResult("Invalid price for " + model.Name);

            }
            return ValidationResult.Success;
        }

    }
}