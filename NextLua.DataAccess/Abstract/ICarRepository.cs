using NextLua.Core.DataAccess;
using NextLua.Entities.Concrete;

namespace NextLua.DataAccess.Abstract;

public interface ICarRepository:IEntityRepository<Car>
{
    // List<Car> GetCarsWithUser();
}