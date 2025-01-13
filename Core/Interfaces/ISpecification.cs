using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISpecification<G>
    {
        Expression<Func<G, bool>>? Criteria { get; }
        Expression<Func<G, object>>? OrderBy {get; }
        Expression<Func<G, object>>? OrderByDescending {get; }
        bool IsDistinct {get; }
        int Take {get; } 
        int Skip {get;}
        bool IsPagingEnabled {get;}
        IQueryable<G> ApplyCriteria(IQueryable<G> query);
    }

    public interface ISpecification<G, GResult> : ISpecification<G>
    {
        Expression<Func<G, GResult>>? Select {get; }
    }
}