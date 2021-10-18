using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core;
using Module.Catalog.Core.Entities;
using Shared.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Infrastructure.Persistence
{
    public class CatalogDBContext : ModuleDbContext, ICatalogDBContext
    {
        protected override string Schema => "Catalog";
        public DbSet<Brand> Brands { get; set; }
        public CatalogDBContext(DbContextOptions opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

      
    }
}
