using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data.ModelConfigurations
{
    public class ProgrammerConfiguration : IEntityTypeConfiguration<ProgrammerModel>
    {
        public void Configure(EntityTypeBuilder<ProgrammerModel> builder)
        {
            builder
                .ToTable("Programmer")
                .HasKey(k => k.ProgrammerID);

            builder        
                .HasOne(s => s.Position)     
                .WithMany(c => c.Programmers)   
                .HasForeignKey(s => s.PositionID);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder
                .Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(256);

        }
    }
}