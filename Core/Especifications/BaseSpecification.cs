using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Especifications
{
    public class BaseSpecification<G>(Expression<Func<G, bool>>? criteria) : ISpecification<G>
    {
      protected BaseSpecification() : this(null) {}

        public Expression<Func<G, bool>>? Criteria => criteria;

        public Expression<Func<G, object>>? OrderBy {get; private set;}

        public Expression<Func<G, object>>? OrderByDescending  {get; private set;}

        public bool IsDistinct {get; private set;}

        protected void AddOrderBy(Expression<Func<G, object>> orderByExpression)
        {
          OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<G, object>> orderByDescExpression)
        {
          OrderByDescending = orderByDescExpression;
        }
        protected void ApplyDistinct ()
        {
          IsDistinct = true;
        }
    }

    public class BaseSpecification<G, GResult>(Expression<Func<G, bool>> criteria)
    : BaseSpecification<G>(criteria), ISpecification<G, GResult>
    {

         protected BaseSpecification() : this(null!) {}
        public Expression<Func<G, GResult>>? Select {get; private set;}

        protected void AddSelect(Expression<Func<G, GResult>> selectExpression)
        {
          Select = selectExpression;
        }
    }
}