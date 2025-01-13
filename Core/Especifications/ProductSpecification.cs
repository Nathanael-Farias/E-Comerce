using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Especifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        
        public ProductSpecification(ProductSpecParams specParams) : base(x => 
        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) && 
        (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type)) &&
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search))
        )
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);

            switch (specParams.Sort)
            {
                case "priceAsc" :
                    AddOrderBy(x => x.Price);
                    break;

                case "priceDesc" :
                    AddOrderByDescending(x => x.Price);
                    break;

                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }

    }
}