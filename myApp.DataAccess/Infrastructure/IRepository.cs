using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myApp.DataAccess.Infrastructure
{
    public interface IRepository<T> where T :  class
    {
        T Get(params object[] ids);

        T Get(bool isReadOnly, Expression<Func<T, bool>> expression);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression);

        IEnumerable<T> Gets(
            bool isReadOnly,
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IQueryable<T>> preFilters = null,
            params Func<IQueryable<T>, IQueryable<T>>[] postFilters
        );

        T GetReadOnly(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetsReadOnly(
            Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, IQueryable<T>> preFilters = null,
            params Func<IQueryable<T>, IQueryable<T>>[] postFilters
        );

        int Count(Expression<Func<T, bool>> expression);

        bool Exit(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Insert(T entity);

        void InsertMany(IEnumerable<T> entities);

        void Update(T entity, object data);

        void Update(Expression<Func<T, bool>> expression, object data);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> expression = null);
    }
}
