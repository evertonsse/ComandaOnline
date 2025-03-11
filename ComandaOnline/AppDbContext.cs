using ComandaOnline.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ComandaOnline;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<OrganizationModel> Organization { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().ToTable("Users").HasKey(x => x.Id);
        modelBuilder.Entity<OrganizationModel>().ToTable("Organization").HasKey(x => x.Id);
    }
}
