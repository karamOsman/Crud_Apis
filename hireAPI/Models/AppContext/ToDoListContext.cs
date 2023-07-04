
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hireAPI.Models.AppContext
{
    public class ToDoListContext :IdentityDbContext<User>
    {
         // Dependancy Injection call base 
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> ProductsCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new ProductsConfiguration().Configure(modelBuilder.Entity<Products>());
            new ProductCategoryConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            // Calling RelationShip
            modelBuilder.MapRelation();
        }
    }
}
