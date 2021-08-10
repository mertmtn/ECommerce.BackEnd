using ECommerce.Entity.Concrete;
using System;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public static class CartItemValidationMessage
    {
        public static string ProductIdNotEmpty = "Ürün seçilmelidir.";
        public static string QuantityNotNegative = "Ürün miktarı negatif olamaz.";
    }
}