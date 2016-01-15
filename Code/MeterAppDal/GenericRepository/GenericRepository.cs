using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MeterAppDal.Interfaces;

namespace MeterAppDal.GenericRepository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel>, IDisposable where TModel : class
    {
        public DbContext DatabaseContext { get; set; }
        internal DbSet<TModel> DbSet;
        public bool AutoSave { get; set; }

        #region Constructor & Destructor
        //Code the constructor here
        public GenericRepository(MeterContext context)
        {
            this.DatabaseContext = context;
            DbSet = context.Set<TModel>();
        }

        #endregion Constructor & Destructor
        
        public void ExecuteCommand(string sql, params object[] parameters)
        {
            DatabaseContext.Database.ExecuteSqlCommand(sql, parameters);
        }


        public virtual TModel GetSingle(object keyValues)
        {
            return DatabaseContext.Set<TModel>().Find(keyValues);
        }

        public virtual TModel GetSingle(object keyValues, params Expression<Func<TModel, object>>[] childrensToInclude)
        {
            var model = DatabaseContext.Set<TModel>().Find(keyValues);
            if (model != null)
            {
                foreach (var children in childrensToInclude)
                {
                    var member = children.Body as MemberExpression;
                    if (member == null) { throw new ArgumentException("'children' should be a member expression", "childrensToInclude"); }
                    var propertyInfo = (PropertyInfo)member.Member;
                    var isCollectionObject = propertyInfo.PropertyType.IsGenericType;
                    if (isCollectionObject)
                    {
                        if (DatabaseContext != null) { DatabaseContext.Entry(model).Collection(member.Member.Name).Load(); }
                    }
                    else
                    {
                        if (DatabaseContext != null) { DatabaseContext.Entry(model).Reference(member.Member.Name).Load(); }
                    }
                }
            }

            return model;
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return DatabaseContext.Set<TModel>();
        }

        public virtual Int32 Count()
        {
            return DatabaseContext.Set<TModel>().Count();
        }

        public virtual Int64 Max(Expression<Func<TModel, long>> predicate)
        {
            return DatabaseContext.Set<TModel>().Max(predicate);
        }

        public virtual int? Create(TModel entity)
        {
            DatabaseContext.Set<TModel>().Add(entity);
            return AutoSave ? Save() : null;
        }

        public virtual int? Create(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities) { Create(entity); }
            return null;
        }

        public virtual int? Update(TModel entity)
        {
            return AutoSave ? Save() : null;
        }

        public virtual int? Update(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities) { Update(entity); }
            return null;
        }
        public virtual int? Delete(TModel entity)
        {
            DatabaseContext.Set<TModel>().Remove(entity);
            return AutoSave ? Save() : null;
        }

        public virtual int? Delete(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities) { Delete(entity); }
            return null;
        }

        public int? Delete(object id)
        {
            TModel entity = GetSingle(Convert.ToInt32(id, CultureInfo.InvariantCulture));
            if (entity == null) return null;
            Delete(entity);
            return null;
        }

        public int? Delete(string ids)
        {
            ids = ids.TrimEnd(',');
            var idArray = ids.Split(',');
            var processed = 0;
            foreach (var id in idArray)
            {
                if (string.IsNullOrEmpty(id)) continue;
                Delete(id);
                processed++;
            }
            return processed;
        }

        public int? Save()
        {
            return DatabaseContext.SaveChanges();
        }

        public int? Save(TModel entity)
        {
            if (DatabaseContext.Entry(entity).State == EntityState.Unchanged) { return null; }
            if (DatabaseContext.Entry(entity).State == EntityState.Detached) { DatabaseContext.Set<TModel>().Add(entity); }
            return DatabaseContext.SaveChanges();
        }

        public virtual IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate)
        {
            return DatabaseContext.Set<TModel>().Where(predicate);
        }

        public virtual IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] childrensToInclude)
        {
            var model = DatabaseContext.Set<TModel>().Where(predicate);
            foreach (var member in childrensToInclude.Select(children => children.Body as MemberExpression))
            {
                if (member == null) { throw new ArgumentException("'children' should be a member expression", "childrensToInclude"); }
                model.Include(member.Member.Name).Load();
            }
            return model;
        }
        public virtual IQueryable<TModel> Where(IList<Expression<Func<TModel, bool>>> predicates)
        {
            IQueryable<TModel> queryResults = DatabaseContext.Set<TModel>();
            if (predicates != null)
            {
                queryResults = predicates.Aggregate(queryResults, (current, predicate) => current.Where(predicate));
            }
            return queryResults;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
