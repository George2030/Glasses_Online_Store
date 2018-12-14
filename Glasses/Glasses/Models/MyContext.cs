using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glasses.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
               : base(options)
        {

        }

        public DbSet<Models.Glass> Glasses { get; set; }
        public DbSet<Models.Brand> Brands { get; set; }

    }
}
