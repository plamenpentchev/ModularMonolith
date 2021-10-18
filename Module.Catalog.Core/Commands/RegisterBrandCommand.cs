using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Commands
{
    public class RegisterBrandCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }

    internal class RegisterBrandCommandhandler: IRequestHandler<RegisterBrandCommand, int>
    {
        private readonly ICatalogDBContext context;

        public RegisterBrandCommandhandler(ICatalogDBContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(RegisterBrandCommand request, CancellationToken cancellationToken)
        {
            if (await context.Brands.AnyAsync(b => b.Name == request.Name, cancellationToken))
            {
                throw new Exception("Brand with the same name already exists.");
            }
            var brand = new Brand
            {
                Name=request.Name,
                Detail = request.Detail
            };
            await context.Brands.AddAsync(brand, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return brand.Id;
        }
    }
}
