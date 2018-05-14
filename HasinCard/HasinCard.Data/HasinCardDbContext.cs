using HasinCard.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Data
{

    public class HasinCardDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<SysUsers> SysUsers { get; set; }
        public HasinCardDbContext(DbContextOptions<HasinCardDbContext> options)
          : base(options)
        {
        }
    }
}
