using ComandaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ComandaOnline;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }

    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<UserModel>().ToTable("Users").HasKey(x => x.Id);
    }
}
