using ECommerce.Business.Concrete;
using ECommerce.Data.Concrete.MongoDb;
using ECommerce.Data.Concrete.MongoDb.Settings;
using ECommerce.Entity.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.UnitTest
{
    [TestClass]
    public class CartOperationTest
    {
        private static CartItemManager _cartItemService;
        public CartOperationTest()
        {
            var mongoDbContext = new MongoDbContext(new MongoDbSettings { ConnectionString = "mongodb://localhost:27017", Database = "ECommerce" });

            var cartItemDal = new MongoCartItemDal(mongoDbContext);
            var productDal = new MongoProductDal(mongoDbContext);

            var productManager = new ProductManager(productDal);
            
            _cartItemService = new CartItemManager(cartItemDal, productManager);

        }

        [TestMethod]
        public void AddToCart()
        {
            var productToAddCart = new CartItem
            {
                CartId = "60fcab4cfc755a3107ee32d2",
                ProductId = "60fcabd2fc755a3107ee32d3",
                Quantity = 5,
                DateCreated = System.DateTime.Now
            };

            var result=_cartItemService.Add(productToAddCart);

            Assert.IsTrue(result.Success,result.Message);
        }

        [TestMethod]
        public void DeleteFromCart()
        {
            var productToAddCart = new CartItem
            {
                CartId = "60fcab4cfc755a3107ee32d2",
                ProductId = "60fcabd2fc755a3107ee32d3"                 
            };

            var result = _cartItemService.Delete(productToAddCart);

            Assert.IsTrue(result.Success);
        }
    }
}
