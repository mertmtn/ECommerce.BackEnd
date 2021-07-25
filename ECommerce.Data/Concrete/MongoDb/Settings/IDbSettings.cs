using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.MongoDb.Settings
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        
    }
}
