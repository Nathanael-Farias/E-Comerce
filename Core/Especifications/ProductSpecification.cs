using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Especifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        
        public ProductSpecification(string? brand, string? type) : base(x => 
        (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) && 
        (string.IsNullOrWhiteSpace(type) || x.Type == type)
        )
        {
            
        }

    }
}