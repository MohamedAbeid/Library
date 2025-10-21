using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Library.Models
{
    public class StoryShelf : IdentityDbContext<Users>
    {
        public StoryShelf(DbContextOptions<StoryShelf> options)
        : base(options)
        {

        }

        public StoryShelf()
        {
        }

        public DbSet<Books> Books { get; set; }
        //public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Borrowings> Borrowings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.Categories)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=db27363.public.databaseasp.net; Database=db27363; User Id=db27363; Password=2z@H#8Dd6g?N; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        }
    }
}
