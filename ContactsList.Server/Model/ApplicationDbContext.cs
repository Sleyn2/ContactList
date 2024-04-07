namespace ContactsList.Server.Model
{
    using ContactsList.Server.Core;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IPasswordHasher _passwordHasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher passwordHasher)
            : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER1_ID = Guid.NewGuid().ToString();
            string USER2_ID = Guid.NewGuid().ToString();
            string USER3_ID = Guid.NewGuid().ToString();
            string ROLE_ID_ADMIN = Guid.NewGuid().ToString();
            string ROLE_ID_USER = Guid.NewGuid().ToString();

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
                new Subcategory { Id = 4, CategoryId = 2, Name = "Osobisty" },
                new Subcategory { Id = 5, CategoryId = 2, Name = "Rodzinny" }
               );


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID_ADMIN,
                    Name = "admin",
                    NormalizedName = "admin"
                },
                new IdentityRole
                {
                    Id = ROLE_ID_USER,
                    Name = "user",
                    NormalizedName = "user"
                });
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = ADMIN_ID,
                    Name = "Alexander",
                    Surname = "Johnston",
                    CategoryId = 1,
                    SubcategoryId = 1,
                    BirthDate = DateTime.Now,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = _passwordHasher.Hash("zaq1@WSX"),
                    SecurityStamp = string.Empty,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = USER1_ID,
                    Name = "Phoenix",
                    Surname = "Elliott",
                    CategoryId = 2,
                    SubcategoryId = 5,
                    BirthDate = DateTime.Now,
                    UserName = "user1",
                    NormalizedUserName = "user1",
                    Email = "user1@gmail.com",
                    NormalizedEmail = "user1@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = _passwordHasher.Hash("passwOrd1!"),
                    SecurityStamp = string.Empty,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = USER2_ID,
                    Name = "Christin",
                    Surname = "Cavanaugh",
                    CategoryId = 2,
                    SubcategoryId = 4,
                    BirthDate = DateTime.Now,
                    UserName = "user2",
                    NormalizedUserName = "user2",
                    Email = "user2@gmail.com",
                    NormalizedEmail = "user2@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = _passwordHasher.Hash("ZAq1@Wsx"),
                    SecurityStamp = string.Empty,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = USER3_ID,
                    Name = "Rafael",
                    Surname = "Weiner",
                    CategoryId = 1,
                    SubcategoryId = 3,
                    BirthDate = DateTime.Now,
                    UserName = "user3",
                    NormalizedUserName = "user3",
                    Email = "user3@gmail.com",
                    NormalizedEmail = "user3@gmail.com",
                    EmailConfirmed = false,
                    PasswordHash = _passwordHasher.Hash("zaq1@WSX"),
                    SecurityStamp = string.Empty,
                    AccessFailedCount = 0
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_ADMIN,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_USER,
                    UserId = USER1_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_USER,
                    UserId = USER2_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_USER,
                    UserId = USER3_ID
                });
        }
    }

}
