using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<G> where G : BaseEntity
    {
        public static IQueryable<G> GetQuery(IQueryable<G> query, ISpecification<G> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }
    }
}