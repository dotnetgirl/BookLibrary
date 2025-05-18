using BookLibrary.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Book> Books { get; set; }
}