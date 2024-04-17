using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myApp.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entity;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        private IDbSet<T> Entities => _entity ?? (_entity = _context.Set<T>());

        public int Count(Expression<Func<T, bool>> expression)
        {
            return expression == null ? Entities.Count() : Entities.Count(expression);
        }

        public void Create(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "Parameter Entiry in Create method can not be null.");

                Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "Parameter Entity in Delete method can not be null.");

                Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public void Delete(Expression<Func<T, bool>> expression = null)
        {
            var enties = Entities.Where(expression);
            foreach (var entity in enties)
            {
                Entities.Remove(entity);
            }

            _context.SaveChange();
        }

        public bool Exit(Expression<Func<T, bool>> expression)
        {
            return expression == null ? Entities.Any() : Entities.Any(expression);
        }

        public T Get(params object[] ids)
        {
            if (ids == null || ids.Count() == 0)
                throw new ArgumentNullException(nameof(ids), "Parameter Ids in Get method can not be null.");

            return Entities.Find(ids);
        }

        public T Get(bool isReadOnly, Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression), "Parameter Expression can not be null.");

            return isReadOnly ? Entities.AsNoTracking().SingleOrDefault(expression) : Entities.SingleOrDefault(expression);
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression), "Parameter Expression in GetQuery method can not be null.");
            return Entities.AsNoTracking().Where(expression);
        }

        public T GetReadOnly(Expression<Func<T, bool>> expression)
        {
            return Get(true, expression);
        }

        public IEnumerable<T> GetsReadOnly(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IQueryable<T>> preFilters = null, params Func<IQueryable<T>, IQueryable<T>>[] postFilters)
        {
            return FindCore(true, expression, preFilters, postFilters);
        }

        public IEnumerable<T> Gets(bool isReadOnly, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IQueryable<T>> preFilters = null, params Func<IQueryable<T>, IQueryable<T>>[] postFilters)
        {
            return FindCore(isReadOnly, expression, preFilters, postFilters);
        }

        public void Insert(T entity)
        {
            Create(entity);
            _context.SaveChange();
        }

        public void InsertMany(IEnumerable<T> entities)
        {

            foreach (var entity in entities)
            {
                Create(entity);
            }

            _context.SaveChange();
        }

        public void Update(T entity, object data)
        {
            if (entity == null || data == null)
                throw new ArgumentNullException(nameof(entity), "Parameter in Update method can not be null.");

            _context.Entry(entity).CurrentValues.SetValues(data);
            _context.SaveChange();
        }

        public void Update(Expression<Func<T, bool>> expression, object data)
        {
            if (expression == null || data == null)
                throw new ArgumentNullException(nameof(expression), "Paramter in Update method can not be null");

            var entities = Entities.Where(expression);
            foreach (var entity in entities)
            {
                _context.Entry(entity).CurrentValues.SetValues(data);
            }
            _context.SaveChange();
        }

        private IQueryable<T> FindCore(
            bool isReadOnly, 
            Expression<Func<T, bool>> spec = null,
            Func<IQueryable<T>, IQueryable<T>> preFilter = null, 
            params Func<IQueryable<T>, IQueryable<T>>[] postFilters
        )
        {
            IQueryable<T> entities = isReadOnly ? Entities.AsNoTracking() : Entities;

            if (preFilter != null)
                entities = preFilter(entities);

            if (spec != null)
                entities = entities.Where(spec);

            foreach (var postFilter in postFilters)
            {
                if (postFilter != null)
                    entities = postFilter(entities);
            }

            return entities;
        }
    }
}
