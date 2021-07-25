using ECommerce.Core;
using ECommerce.Entity.Concrete;
using System.Collections.Generic;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(string productId);
        IDataResult<List<Product>> GetAll();
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
