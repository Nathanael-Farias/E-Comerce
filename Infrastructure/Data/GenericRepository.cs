using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<G>(StoreContext context) : IGenericRepository<G> where G : BaseEntity
    {
        public void Add(G entity)
        {
            context.Set<G>().Add(entity);
        }

        public async Task<int> CountAsync(ISpecification<G> spec)
        {
            var query = context.Set<G>().AsQueryable();

            query = spec.ApplyCriteria(query);

            return await query.CountAsync();
        }

        public bool Exists(int id)
        {
            return context.Set<G>().Any(x => x.Id == id);
        }

        public async Task<G?> GetByIdAsync(int id)
        {
            return await context.Set<G>().FindAsync(id);
        }

        public async Task<G?> GetEntityWithSpec(ISpecification<G> spec)
        {
           return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<GResult?> GetEntityWithSpec<GResult>(ISpecification<G, GResult> spec)
        {
             return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<G>> ListAllAsync()
        {
            return await context.Set<G>().ToListAsync();
        }

        public async Task<IReadOnlyList<G?>> ListAsync(ISpecification<G> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<GResult?>> ListAsync<GResult>(ISpecification<G, GResult> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public void Remove(G entity)
        {
            context.Set<G>().Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(G entity)
        {
            context.Set<G>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        private IQueryable<G> ApplySpecification(ISpecification<G> spec)
        {
            return SpecificationEvaluator<G>.GetQuery(context.Set<G>().AsQueryable(), spec);
        }


         private IQueryable<GResult> ApplySpecification<GResult>(ISpecification<G, GResult> spec)
        {
            return SpecificationEvaluator<G>.GetQuery<G, GResult>(context.Set<G>().AsQueryable(), spec);
        }
    }
}