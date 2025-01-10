using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Especifications
{
    public class BaseSpecification<G>(Expression<Func<G, bool>> criteria) : ISpecification<G>
    {
      

        public Expression<Func<G, bool>> Criteria => criteria;
    }
}