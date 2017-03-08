using Beers.services.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Implementations
{
    public class ServiceBase
    {
        private BeersBaseContext _context;

        public ServiceBase()
        {
            _context = new BeersBaseContext();
        }

        protected BeersBaseContext Context
        {
            get{
                return _context;
            }
            set
            {

            }
        }

        public TEntity FindWithInclude<TEntity>(Expression<Func<TEntity, bool>> condition, List<Expression<Func<TEntity, object>>> includes) where TEntity : class
        {
            var entityContext = _context.Set<TEntity>();
            return includes.Aggregate(entityContext.Where(condition).AsQueryable(), (current, include) => current.Include(include)).FirstOrDefault();
        }

    }
}
