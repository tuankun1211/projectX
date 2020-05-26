using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Contexts
{
    public class CQRSContext : DbContext, ICQRSContext
    {
        public DbSet<Product> Products { get; set; }
        public CQRSContext(DbContextOptions<CQRSContext> options)
            : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
