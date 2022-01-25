using FirstTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Data.ModelConfigurations
{
    public class ProgrammerConfiguration : IEntityTypeConfiguration<Programmer>
    {
        public void Configure(EntityTypeBuilder<Programmer> builder)
        {
            builder.ToTable("Programmer")
                .HasKey(k => k.ProgrammerID);

            builder
            .HasOne(s => s.Position)
            .WithMany(c => c.Programmers)
            .HasForeignKey(s => s.PositionID);

            builder.Property(b => b.Name)
            .IsRequired();
            builder.Property(b => b.LastName)
          .IsRequired();

        }
    }
}