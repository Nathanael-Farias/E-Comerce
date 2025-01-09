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

        public bool Exists(int id)
        {
            return context.Set<G>().Any(x => x.Id == id);
        }

        public async Task<G?> GetByIdAsync(int id)
        {
            return await context.Set<G>().FindAsync(id);
        }

        public async Task<IReadOnlyList<G>> ListAllAsync()
        {
            return await context.Set<G>().ToListAsync();
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
    }
}