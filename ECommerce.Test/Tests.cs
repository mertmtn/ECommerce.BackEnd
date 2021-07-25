using ECommerce.Business.Abstract;
using NUnit.Framework;

namespace ECommerce.Test
{
    
    public class Tests
    {
        public ICartService _cartService;

        public Tests(ICartService cartService)
        {
            _cartService = cartService;
        }
       
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result= _cartService.GetCartItemDetailByUserId("60fb4549894c39e9ca666513");             
        }
    }
}