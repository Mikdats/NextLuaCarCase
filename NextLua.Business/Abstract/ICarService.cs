using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;


namespace NextLua.Business.Abstract;

public interface ICarService
{
    List<Car> GetAll();
    
    Car GetById(int boatId);
    
    void Add(Car car);
    
    void Delete(Car car);
    
    void Update(Car car);
    // List<Car> GetCarsWithUser();
}