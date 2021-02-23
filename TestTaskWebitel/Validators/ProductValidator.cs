using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTaskWebitel.Models;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            When(c => c.ProductOrders != null, () =>
            {
                RuleForEach(c => c.ProductOrders).Custom((productOrder, context) =>
                {
                    RuleFor(c => c.Id).Equal(productOrder.ProductId);
                });
            });
        }

        //It has an exception
        public void ValidateProduct(Product product, out Boolean isValid, out String message)
        {
            ValidationResult validationResult = Validate(product);

            isValid = validationResult.IsValid;
            message = validationResult.ToString("~");
        }

        public Boolean IsValidEnteredProductId(Product product)
        {
            if (product.ProductOrders != null)
            {
                foreach (var productOrder in product.ProductOrders)
                {
                    if ((productOrder.ProductId != default &&
                        productOrder.ProductId != product.Id) ||
                        (productOrder.Product != null &&
                        productOrder.Product.Id != product.Id))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        
    }
}