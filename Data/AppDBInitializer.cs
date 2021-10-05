using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using rewrite_repo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rewrite_repo.Data
{
    public class AppDBInitializer
    {
        public  static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!context.Allocations.Any())
                {
                    context.Allocations.AddRange(new Repo()
                    {
                        Name = "BNY-REPO-1",
                        Amount = 400000,
                        DateAdded = DateTime.Now
                    },
                    new Repo()
                    {
                        Name = "BNY-REPO-2",
                        Amount = 600000,
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
