using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business
{
    public interface IServiceBase : IDisposable
    {
        IDbContext GetContext();

        int SaveChange();
    }
}
