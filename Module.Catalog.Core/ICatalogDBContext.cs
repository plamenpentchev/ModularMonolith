﻿using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Catalog.Core
{
    public interface ICatalogDBContext
    {
        public DbSet<Brand> Brands { get; set; }
        Task<int> SaveChangesAsync(CancellationToken roken);
    }
}
