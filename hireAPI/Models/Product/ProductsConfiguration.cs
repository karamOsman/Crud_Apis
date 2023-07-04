using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hireAPI.Models
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Arabic_Name).IsRequired().
                HasMaxLength(100);
            builder.Property(x => x.English_Name).IsRequired().
               HasMaxLength(100);
            builder.Property(x => x.CategoryId).IsRequired();



        }
    }
}
