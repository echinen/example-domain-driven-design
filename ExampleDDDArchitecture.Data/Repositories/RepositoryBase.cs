using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
using ExampleDDDArchitecture.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleDDDArchitecture.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected FaleMaisContext ctx = new FaleMaisContext();

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            ctx.Set<TEntity>().Remove(obj);
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
