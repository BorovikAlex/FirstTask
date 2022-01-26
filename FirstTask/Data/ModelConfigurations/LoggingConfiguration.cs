using FirstTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstTask.Data.ModelConfigurations
{
    public class LoggingConfiguration : IEntityTypeConfiguration<LoggingModel>
    {
        public void Configure(EntityTypeBuilder<LoggingModel> builder)
        {
            builder.ToTable("Logging")
                .HasKey(k => k.ID);



            builder.Property(b => b.Level)
            .HasMaxLength(10); 
        

        }
    }
}