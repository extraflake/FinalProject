using Exam.Microservices.Bases;
using Exam.Microservices.Context;
using Exam.Microservices.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Microservices.Repositories
{
    public class GeneralRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : MyContext
    {
        private readonly MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public async Task<TEntity> Delete(int Id)
        {
            var entity = await Get(Id);
            if (entity != null)
            {
                this.myContext.Set<TEntity>().Remove(entity);
                await this.myContext.SaveChangesAsync();
                return entity;
            }
            return entity;
        }

        public async Task<List<TEntity>> Get()
        {
            return await this.myContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int Id)
        {
            return await this.myContext.Set<TEntity>().FindAsync(Id);
        }

        public async Task<TEntity> Post(TEntity entity)
        {
            await this.myContext.Set<TEntity>().AddAsync(entity);
            await this.myContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Put(TEntity entity)
        {
            this.myContext.Entry(entity).State = EntityState.Modified;
            await this.myContext.SaveChangesAsync();
            return entity;
        }
    }
}
