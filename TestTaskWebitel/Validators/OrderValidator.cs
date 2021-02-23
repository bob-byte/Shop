using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            When(c => c.ProductOrders != null, () =>
            {
                RuleForEach(c => c.ProductOrders).Custom((productOrder, context) =>
                {
                    RuleFor(c => c.Id).Equal(productOrder.OrderId);
                });
            });
        }

        //It has an exception
        public void ValidateOrder(Order order, out Boolean isValid, out String message)
        {
            ValidationResult validationResult = Validate(order);

            isValid = validationResult.IsValid;
            message = validationResult.ToString("~");
        }

        public Boolean IsValidEnteredOrderId(Order order)
        {
            if (order.ProductOrders != null)
            {
                foreach (var productOrder in order.ProductOrders)
                {
                    if ((productOrder.OrderId != default &&
                        productOrder.OrderId != order.Id) ||
                        (productOrder.Order != null &&
                        productOrder.Order.Id != order.Id))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}