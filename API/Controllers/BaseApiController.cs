using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController :ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<G>(IGenericRepository<G> repo,
             ISpecification<G> spec, int pageIndex, int pageSize) where G : BaseEntity
             {
                var items = await repo.ListAsync(spec);
                var count = await repo.CountAsync(spec);

                var nonNullProducts = items.Where(p => p != null).Cast<G>().ToList();
                 var pagination = new Pagination<G>(pageIndex,pageSize, count, nonNullProducts);

                return Ok(pagination);

             }
    }
}