using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data.ModelConfigurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<PositionModel>
    {
        public void Configure(EntityTypeBuilder<PositionModel> builder)
        {
            builder.ToTable("Position")
                .HasKey(k => k.PositionID);


            builder.Property(b => b.PositionName)
            .IsRequired()
            .HasMaxLength(256);

        }
    }
}