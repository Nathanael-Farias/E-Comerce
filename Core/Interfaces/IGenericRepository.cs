using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<G> where G : BaseEntity
    {
        Task<G?> GetByIdAsync(int id );
        Task<IReadOnlyList<G>> ListAllAsync();
        void Add(G entity);
        void Update(G entity);
        void Remove(G entity);
        Task<bool> SaveAllAsync();
        bool Exists(int id);

    }
}