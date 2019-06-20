using Microsoft.EntityFrameworkCore;
using Oddestodds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oddestodds.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Odd> Odds { get; set; }
    }
}
