using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryHub.Entities;

namespace InventoryHub.Data
{
    public class InventoryHubContext : DbContext
    {
        public InventoryHubContext (DbContextOptions<InventoryHubContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryHub.Entities.ProductItem> ProductItem { get; set; } = default!;
    }
}
