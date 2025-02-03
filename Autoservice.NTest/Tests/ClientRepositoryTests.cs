using System.Linq;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class ClientRepositoryTests : BaseRepositoryTest
{
    private ClientRepository _clientRepository;

    [SetUp]
    public void Init() => _clientRepository = new ClientRepository(_context);

    [Test]
    public void Add_ShouldAddClient()
    {
        var client = new Client { FirstName = "John", LastName = "Doe", Phone = "123456789" };
        _clientRepository.Add(client);
        _clientRepository.SaveAsync().Wait();

        var result = _clientRepository.GetById(client.ClientId);
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetAll_ShouldReturnAllClients()
    {
        var client1 = new Client { FirstName = "Alice", LastName = "Smith", Phone = "111111111" };
        var client2 = new Client { FirstName = "Bob", LastName = "Johnson", Phone = "222222222" };

        _clientRepository.Add(client1);
        _clientRepository.Add(client2);
        _clientRepository.SaveAsync().Wait();

        var result = _clientRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnClient()
    {
        var client = new Client { FirstName = "Eve", LastName = "Brown", Phone = "333333333" };
        _clientRepository.Add(client);
        _clientRepository.SaveAsync().Wait();

        var result = _clientRepository.GetById(client.ClientId);
        Assert.IsNotNull(result);
        Assert.AreEqual("Eve", result.FirstName);
    }

    [Test]
    public void Update_ShouldModifyClient()
    {
        var client = new Client { FirstName = "Tom", LastName = "White", Phone = "444444444" };
        _clientRepository.Add(client);
        _clientRepository.SaveAsync().Wait();

        client.Phone = "555555555";
        _clientRepository.Update(client);
        _clientRepository.SaveAsync().Wait();

        var result = _clientRepository.GetById(client.ClientId);
        Assert.AreEqual("555555555", result.Phone);
    }

    [Test]
    public void Delete_ShouldRemoveClient()
    {
        var client = new Client { FirstName = "Sam", LastName = "Green", Phone = "666666666" };
        _clientRepository.Add(client);
        _clientRepository.SaveAsync().Wait();

        _clientRepository.Delete(client.ClientId);
        _clientRepository.SaveAsync().Wait();

        var result = _clientRepository.GetById(client.ClientId);
        Assert.IsNull(result);
    }
}
