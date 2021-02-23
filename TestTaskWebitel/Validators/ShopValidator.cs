//using FluentValidation;
//using FluentValidation.Results;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using TestTaskWebitel.Models.Domain;

//namespace TestTaskWebitel.Validators
//{
//    public static class ShopValidator
//    {
//        public static Boolean IsValid<T>(Shop shop)
//            where T: Product
//        {
//            AbstractValidator<Product> validations;
//            if(shop is Product)
//            {
//                validations = new ProductValidator();
//            }
//            else
//            {
//                return false;
//            }
//            //else if(shop is Order)
//            //{
//            //    validations = new 
//            //}

//            ProductOrdersValidator productOrderValidator = new ProductOrdersValidator();
//            foreach (var item in shop.ProductOrders)
//            {
//                ProductOrders = productOrderValidator.Validate(item);
//                if(!validProductOrders.IsValid)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }

//        public 
//    }
//}