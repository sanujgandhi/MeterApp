using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeterAppDal.Interfaces
{
    public interface IGenericRepository<TModel>
    {
        TModel GetSingle(object keyValues);
        IQueryable<TModel> GetAll();
        Int32 Count();
        Int64 Max(Expression<Func<TModel, long>> predicate);
        int? Create(TModel entity);
        int? Create(IEnumerable<TModel> entities);
        int? Update(TModel entity);
        int? Update(IEnumerable<TModel> entities);
        int? Delete(TModel entity);
        int? Delete(IEnumerable<TModel> entities);
        int? Delete(object id);
        int? Delete(string ids);
        int? Save();
        int? Save(TModel entity);
        IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate);
        void ExecuteCommand(string sql, params object[] parameters);
        IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] childrensToInclude);
        IQueryable<TModel> Where(IList<Expression<Func<TModel, bool>>> predicates);
    }
}
