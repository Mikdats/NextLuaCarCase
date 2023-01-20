using NextLua.Business.Abstract;
using NextLua.DataAccess.Abstract;
using NextLua.Entities.Concrete;
using NextLua.Entities.DTOs;

namespace NextLua.Business.Concrete;

public class CarService :ICarService
{
    readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public List<Car> GetAll()
    {
        return _carRepository.GetAll();
    }

    public Car GetById(int carId)
    {
        return _carRepository.Get(x => x.Id == carId);
    }

    public void Add(Car car)
    {
        _carRepository.Add(car);
    }

    public void Delete(Car car)
    {
        _carRepository.Delete(car);
    }

    public void Update(Car car)
    {
        _carRepository.Update(car);
    }
    // public List<Car> GetCarsWithUser()
    // {
    //     return _carRepository.GetCarsWithUser();
    // }
}