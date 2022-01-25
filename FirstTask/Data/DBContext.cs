using FirstTask.Data.ModelConfigurations;
using FirstTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProgrammerConfiguration().Configure(modelBuilder.Entity<Programmer>());
            new PositionConfiguration().Configure(modelBuilder.Entity<Position>());
        }
    

        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
