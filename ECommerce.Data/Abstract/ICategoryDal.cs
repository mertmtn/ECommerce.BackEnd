using ECommerce.Core.DataAccess;
using ECommerce.Entity.Concrete;

namespace ECommerce.Data.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
