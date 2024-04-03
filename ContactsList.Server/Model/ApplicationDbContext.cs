namespace ContactsList.Server.Model
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(p => p.Subcategory)
                .WithMany()
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "służbowy" },
                new Category { Id = 2, Name = "prywatny" },
                new Category { Id = 3, Name = "inny" }
                );

            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { Id = 1, CategoryId = 1, Name = "Kierownik" },
                new Subcategory { Id = 2, CategoryId = 1, Name = "Pracownik" },
                new Subcategory { Id = 3, CategoryId = 1, Name = "Klient" },
                new Subcategory { Id = 4, CategoryId = 2, Name = "Domowy" },
                new Subcategory { Id = 5, CategoryId = 2, Name = "Przenośny" }
               );
        }
    }

}
