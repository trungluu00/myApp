using myApp.DataAccess.Entities;
using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using myApp.DataAccess.Mapping;
using MySql.Data.MySqlClient;

namespace myApp.DataAccess
{
    public class EfContext : DbContext, IDbContext
    {
        #region C'tors

        public EfContext()
            : base("ConnectionString")
        {}

        public EfContext(DbConnection connection)
            : base(connection, false)
        {}
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {}

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<Follow> Follows { get; set; }
        #endregion

        #region Functions

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        
        public new DbEntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public new DbEntityEntry<T> Entry<T>(T entiry) where T : class
        {
            return base.Entry<T>(entiry);
        }

        public Database GetDatabase()
        {
            return base.Database;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepository<T>(this);
        }

        public int SaveChange()
        {
            return base.SaveChanges();
        }

        public int RawModify(string commandText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> RawProcedure(string storeName, params object[] vs)
        {
            throw new NotImplementedException();
        }

        public DataTable RawProcedureTable(string storeName, params object[] paramters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> RawQuery(string stringQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public object RawScalar(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public DataTable RawTable(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
