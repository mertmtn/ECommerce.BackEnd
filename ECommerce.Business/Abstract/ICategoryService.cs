using ECommerce.Core;
using ECommerce.Entity.Concrete;
using System.Collections.Generic;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(string categorytd);
        IDataResult<List<Category>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
