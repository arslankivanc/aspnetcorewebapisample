using Eticaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess
{
    public class EticaretDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-F3DJ12H;Database=EticCoreDb;Integrated Security=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}
