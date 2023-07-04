using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hireAPI.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Rename Table in Dbs
            builder.ToTable("Users");
            builder.HasKey(a => a.Id); // Set PK
            builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd(); // Set IDentity
            builder.Property(a => a.Arabic_Name).IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.English_Name).IsRequired()
              .HasMaxLength(100);

        }
    }
}
