using Microsoft.EntityFrameworkCore;
using rewrite_repo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rewrite_repo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
              
        }

        public DbSet<Repo> Allocations { get; set; }
    }
}
