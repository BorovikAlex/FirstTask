using DataAccess.Data.ModelConfigurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProgrammerConfiguration().Configure(modelBuilder.Entity<ProgrammerModel>());
            new PositionConfiguration().Configure(modelBuilder.Entity<PositionModel>());
            new LoggingConfiguration().Configure(modelBuilder.Entity<LoggingModel>());
        }
    

        public DbSet<ProgrammerModel> Programmers { get; set; }
        public DbSet<PositionModel> Positions { get; set; }
    }
}
