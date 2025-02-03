using System.Linq;
using System.Threading.Tasks;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class CarRepositoryTests : BaseRepositoryTest
{
    private CarRepository _carRepository;

    [SetUp]
    public void Init() => _carRepository = new CarRepository(_context);

    [Test]
    public void Add_ShouldAddCar()
    {
        var car = new Car { LicensePlate = "AA1234BB", Make = "Toyota", Model = "Corolla", Year = 2020, ClientId = 1 };
        _carRepository.Add(car);
        _carRepository.SaveAsync().Wait();

        var result = _carRepository.GetById(car.CarId);
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetAll_ShouldReturnAllCars()
    {
        var car1 = new Car { LicensePlate = "AA1234BB", Make = "Toyota", Model = "Corolla", Year = 2020, ClientId = 1 };
        var car2 = new Car { LicensePlate = "BB5678CC", Make = "Honda", Model = "Civic", Year = 2019, ClientId = 2 };

        _carRepository.Add(car1);
        _carRepository.Add(car2);
        _carRepository.SaveAsync().Wait();

        var result = _carRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnCar()
    {
        var car = new Car { LicensePlate = "CC6789DD", Make = "Mazda", Model = "3", Year = 2021, ClientId = 3 };
        _carRepository.Add(car);
        _carRepository.SaveAsync().Wait();

        var result = _carRepository.GetById(car.CarId);
        Assert.IsNotNull(result);
        Assert.AreEqual("Mazda", result.Make);
    }

    [Test]
    public void Update_ShouldModifyCar()
    {
        var car = new Car { LicensePlate = "AA1234BB", Make = "Toyota", Model = "Corolla", Year = 2020, ClientId = 1 };
        _carRepository.Add(car);
        _carRepository.SaveAsync().Wait();

        car.LicensePlate = "DD9999EE";
        _carRepository.Update(car);
        _carRepository.SaveAsync().Wait();

        var result = _carRepository.GetById(car.CarId);
        Assert.AreEqual("DD9999EE", result.LicensePlate);
    }

    [Test]
    public void Delete_ShouldRemoveCar()
    {
        var car = new Car { LicensePlate = "AA1234BB", Make = "Toyota", Model = "Corolla", Year = 2020, ClientId = 1 };
        _carRepository.Add(car);
        _carRepository.SaveAsync().Wait();

        _carRepository.Delete(car.CarId);
        _carRepository.SaveAsync().Wait();

        var result = _carRepository.GetById(car.CarId);
        Assert.IsNull(result);
    }
}
