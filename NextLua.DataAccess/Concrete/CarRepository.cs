using Microsoft.EntityFrameworkCore;
using NextLua.Core.DataAccess.EntityFramework;
using NextLua.DataAccess.Abstract;
using NextLua.DataAccess.Concrete.Context;
using NextLua.Entities.Concrete;

namespace NextLua.DataAccess.Concrete;

public class CarRepository: EfEntityRepositoryBase<Car, NextLuaDB>, ICarRepository
{
    // public List<Car> GetCarsWithUser()
    // {
    //     using (NextLuaDB context = new NextLuaDB())
    //     {
    //         context.Set<User>();
    //         DbSet<Car> query = context.Set<Car>();
    //         query.Include(x => x.SellerUser);
    //         query.Include(x => x.BuyerUser);
    //
    //
    //
    //         return query.ToList();
    //     }
    // }
}