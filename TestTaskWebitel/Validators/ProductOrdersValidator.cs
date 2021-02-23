using FluentValidation;
using FluentValidation.Results;
using System;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Validators
{
    public class ProductOrdersValidator : AbstractValidator<ProductOrder>
    {
        public ProductOrdersValidator()
        {
            RuleFor(c => c.Product).Empty();
            RuleFor(c => c.Order).Empty();
        }

        public Boolean IsValid(ProductOrder productOrder)
        {
            ValidationResult validProductOrders = Validate(productOrder);

            return validProductOrders.IsValid;
        }
    }
}