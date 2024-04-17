using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business
{
    public class ServiceBase : IServiceBase
    {
        public readonly IDbContext Context;
        protected bool Disposed;

        protected ServiceBase(IDbContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public IDbContext GetContext()
        {
            return Context;
        }

        public int SaveChange()
        {
            return Context.SaveChange();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
                if (disposing)
                    Context.Dispose();

            Disposed = true;
        }
    }
}
