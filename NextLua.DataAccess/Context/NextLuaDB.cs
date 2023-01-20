using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NextLua.Entities.Concrete;

namespace NextLua.DataAccess.Concrete.Context;

public class NextLuaDB : IdentityDbContext<IdentityUser>
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database= NextLuaCaseDB; integrated security=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Car>()
        //     .HasOne(x => x.BuyerUser)
        //     .WithMany(x => x.BuyerCars)
        //     .HasForeignKey(x => x.BuyerId);
        //
        // modelBuilder.Entity<Car>()
        //     .HasOne(x => x.SellerUser)
        //     .WithMany(x => x.SellerCars)
        //     .HasForeignKey(x => x.SellerId);
            

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
}