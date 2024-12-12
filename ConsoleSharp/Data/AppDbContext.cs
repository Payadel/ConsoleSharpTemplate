using Microsoft.EntityFrameworkCore;

namespace ConsoleSharp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
    // public DbSet<Person> Persons { get; set; }
    //
    // protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //     modelBuilder.Entity<Person>().HasKey(p => p.Id);
    // }
}