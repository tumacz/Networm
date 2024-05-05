using Microsoft.EntityFrameworkCore;
using Networm.Domain.Entities;

namespace Networm.Infrastructure.Persistence
{
    public class NetwormBookDbContext : DbContext
    {
        public NetwormBookDbContext(DbContextOptions<NetwormBookDbContext> options) : base(options) 
        {
            //constructor grants access through :base(options) required to register Db connection string from Networm/.../appsettings.Development.json
        }

        public DbSet<NetwormBook> NetwormBooks { get; set; }
        public DbSet<NetwormBookmark> NetwormBookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NetwormBook>()
                .HasMany(book => book.Bookmarks)
                .WithOne(bookmark => bookmark.NetwormBook)
                .HasForeignKey(bookmark => bookmark.NetwormBookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}