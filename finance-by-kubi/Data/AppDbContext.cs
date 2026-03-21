namespace finance_by_kubi.Data;

using Microsoft.EntityFrameworkCore;
using finance_by_kubi.Models;



public class AppDbContext : DbContext
{

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	
	}

	public DbSet<Transaction> Transactions { get; set; }
	public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Category)          // Transakce má jednu kategorii
            .WithMany(c => c.Transactions)    // Kategorie má mnoho transakcí
            .HasForeignKey(t => t.CategoryId) // Propojeno přes CategoryId
            .IsRequired();                    // Vazba je povinná
    }
}