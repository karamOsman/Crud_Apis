using Microsoft.EntityFrameworkCore;

namespace hireAPI.Models.AppContext

{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. Task ------- User
            //    M    ------- 1
            builder.Entity<Products>().HasOne(a=>a.User)
                .WithMany(a=>a.ProductUser).HasForeignKey(a=>a.manufacturer)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            // 2. Categories --------- Task
            //    1          --------- M
            builder.Entity<Products>().HasOne(a => a.Category)
                .WithMany(a => a.CategoryProducts).HasForeignKey(a => a.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
