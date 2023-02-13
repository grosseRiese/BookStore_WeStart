using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreDbContext : IdentityDbContext<AppUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Classics" },
            //    new Category { Id = 2, Name = "Fantasy" },
            //    new Category { Id = 3, Name = "Crime" },
            //    new Category { Id = 4, Name = "Horror" },
            //    new Category { Id = 5, Name = "Humour" },
            //    new Category { Id = 6, Name = "Adventure" },
            //    new Category { Id = 7, Name = "Mystery" },
            //    new Category { Id = 8, Name = "Poetry" },
            //    new Category { Id = 9, Name = "Science fiction" },
            //    new Category { Id = 10, Name = "Short stories" },
            //    new Category { Id = 11, Name = "Historical fiction" },
            //    new Category { Id = 12, Name = "Young adult" }
            //);
           
            //modelBuilder.Entity<Author>().HasData(
            //    new Author { Id = 1, Name = "Steven Even" },
            //    new Author { Id = 2, Name = "Faris Faris" },
            //    new Author { Id = 3, Name = "John Doe" },
            //    new Author { Id = 4, Name = "unknown" }
            //);

            //modelBuilder.Entity<Publisher>().HasData(
            //    new Publisher { Id = 1, Name = "Steven Even",Logo=" " },
            //    new Publisher { Id = 2, Name = "Faris Faris" ,Logo = " " },
            //    new Publisher { Id = 3, Name = "John Doe",Logo = " " },
            //    new Publisher { Id = 4, Name = "unknown",Logo = " " }
            //); 


            //modelBuilder.Entity<Translator>().HasData(
            //    new Translator { Id = 1, Name = "Google" },
            //    new Translator { Id = 2, Name = "Wehda"},
            //    new Translator { Id = 3, Name = "MLs ltdCo"},
            //    new Translator { Id = 4, Name = "unknown" }
            //);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
             .HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "User", NormalizedName = "USER" });

            modelBuilder.Entity<UserFavs>().HasKey(x => new {x.AppUserId, x.BookId});

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReviews> BookReviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<UserFavs> UserFavs { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Zone> Zones{ get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<StaticPage> StaticPages { get; set; }
        public DbSet<BookSuggestion> BookSuggestions { get; set; }
    }
}
