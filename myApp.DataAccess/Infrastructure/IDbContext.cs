using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.DataAccess.Infrastructure
{
    public interface IDbContext : IDisposable
    {
        Database GetDatabase();

        DbEntityEntry Entry(object data);

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbContextConfiguration Configuration { get; }

        int SaveChange();

        IDbSet<T> Set<T>() where T : class;

        IRepository<T> GetRepository<T>() where T : class;

        IEnumerable<dynamic> RawQuery(string stringQuery, params object[] parameters);

        IEnumerable<dynamic> RawProcedure(string storeName, params object[] vs);

        int RawModify(string commandText, params object[] parameters);

        object RawScalar(string query, params object[] parameters);

        DataTable RawTable(string query, params object[] parameters);

        DataTable RawProcedureTable(string storeName, params object[] paramters);
    }
}
