using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Queries
{
    public class GetAllBrandsQuery: IRequest<IEnumerable<Brand>>
    {
    }

    internal class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly ICatalogDBContext _context;

        public GetAllBrandsQueryHandler(ICatalogDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.OrderBy(b => b.Id).ToListAsync();
            if (null == brands)
            {
                throw new Exception("Brands were not found.");
            }
            return brands;
        }
    }
}
