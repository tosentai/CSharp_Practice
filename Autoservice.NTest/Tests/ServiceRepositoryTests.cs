using System.Linq;
using System.Threading.Tasks;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class ServiceRepositoryTests : BaseRepositoryTest
{
    private ServiceRepository _serviceRepository;

    [SetUp]
    public void Init() => _serviceRepository = new ServiceRepository(_context);

    [Test]
    public void Add_ShouldAddService()
    {
        var service = new Service { Name = "Oil Change", Price = 50.00m };
        _serviceRepository.Add(service);
        _serviceRepository.SaveAsync().Wait();

        var result = _serviceRepository.GetById(service.ServiceId);
        Assert.IsNotNull(result);
        Assert.AreEqual("Oil Change", result.Name);
    }

    [Test]
    public void GetAll_ShouldReturnAllServices()
    {
        var service1 = new Service { Name = "Brake Inspection", Price = 30.00m };
        var service2 = new Service { Name = "Tire Rotation", Price = 20.00m };

        _serviceRepository.Add(service1);
        _serviceRepository.Add(service2);
        _serviceRepository.SaveAsync().Wait();

        var result = _serviceRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnService()
    {
        var service = new Service { Name = "Battery Replacement", Price = 80.00m };
        _serviceRepository.Add(service);
        _serviceRepository.SaveAsync().Wait();

        var result = _serviceRepository.GetById(service.ServiceId);
        Assert.IsNotNull(result);
        Assert.AreEqual("Battery Replacement", result.Name);
    }

    [Test]
    public void Update_ShouldModifyService()
    {
        var service = new Service { Name = "Air Filter Change", Price = 25.00m };
        _serviceRepository.Add(service);
        _serviceRepository.SaveAsync().Wait();

        service.Price = 30.00m;
        _serviceRepository.Update(service);
        _serviceRepository.SaveAsync().Wait();

        var result = _serviceRepository.GetById(service.ServiceId);
        Assert.AreEqual(30.00m, result.Price);
    }

    [Test]
    public void Delete_ShouldRemoveService()
    {
        var service = new Service { Name = "Coolant Flush", Price = 60.00m };
        _serviceRepository.Add(service);
        _serviceRepository.SaveAsync().Wait();

        _serviceRepository.Delete(service.ServiceId);
        _serviceRepository.SaveAsync().Wait();

        var result = _serviceRepository.GetById(service.ServiceId);
        Assert.IsNull(result);
    }
}
