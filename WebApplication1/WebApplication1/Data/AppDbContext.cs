using WebApplication1.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
   public DbSet<Pc> Pcs { get; set; }
   public DbSet<Component> Components { get; set; }
   public DbSet<ComponentType> ComponentTypes { get; set; }
   public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
   public DbSet<PcComponent> PcComponents { get; set; }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.Entity<PcComponent>()
           .HasKey(pc => new { pc.PcId, pc.ComponentCode });
       modelBuilder.Entity<ComponentType>().HasData(
           new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
           new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
           new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
       );
       modelBuilder.Entity<ComponentManufacturer>().HasData(
           new ComponentManufacturer { Id = 1, Abbreviation = "INTC", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
           new ComponentManufacturer { Id = 2, Abbreviation = "NVDA", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
           new ComponentManufacturer { Id = 3, Abbreviation = "CRSL", FullName = "Corsair", FoundationDate = new DateTime(1994, 1, 1) }
       );
       modelBuilder.Entity<Component>().HasData(
           new Component { Code = "I9-14900K", Name = "Core i9 14900K", ComponentManufacturersId = 1, ComponentTypesId = 1 },
           new Component { Code = "RTX4090", Name = "GeForce RTX 4090", ComponentManufacturersId = 2, ComponentTypesId = 2 },
           new Component { Code = "DOM-32GB", Name = "Dominator DDR5 32GB", ComponentManufacturersId = 3, ComponentTypesId = 3 }
       );
       modelBuilder.Entity<Pc>().HasData(
           new Pc { Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
           new Pc { Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 12 },
           new Pc { Id = 3, Name = "Budget Build v2", Weight = 8.7, Warranty = 12, CreatedAt = DateTime.Parse("2026-05-10T11:00:00"), Stock = 3 }
       );
       modelBuilder.Entity<PcComponent>().HasData(
           new PcComponent { PcId = 1, ComponentCode = "I9-14900K", Amount = 1 },
           new PcComponent { PcId = 1, ComponentCode = "RTX4090", Amount = 1 },
           new PcComponent { PcId = 2, ComponentCode = "DOM-32GB", Amount = 2 }
       );
   }
}