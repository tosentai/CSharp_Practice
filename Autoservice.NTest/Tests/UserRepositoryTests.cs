using System.Linq;
using System.Threading.Tasks;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class UserRepositoryTests : BaseRepositoryTest
{
    private UserRepository _userRepository;

    [SetUp]
    public void Init() => _userRepository = new UserRepository(_context);

    [Test]
    public void Add_ShouldAddUser()
    {
        var user = new User { Username = "admin", Password = "password123", LastLogin = DateTime.Now };
        _userRepository.Add(user);
        _userRepository.SaveAsync().Wait();

        var result = _userRepository.GetById(user.UserId);
        Assert.IsNotNull(result);
        Assert.AreEqual("admin", result.Username);
    }

    [Test]
    public void GetAll_ShouldReturnAllUsers()
    {
        var user1 = new User { Username = "user1", Password = "pass1", LastLogin = DateTime.Now };
        var user2 = new User { Username = "user2", Password = "pass2", LastLogin = DateTime.Now };

        _userRepository.Add(user1);
        _userRepository.Add(user2);
        _userRepository.SaveAsync().Wait();

        var result = _userRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnUser()
    {
        var user = new User { Username = "testuser", Password = "testpass", LastLogin = DateTime.Now };
        _userRepository.Add(user);
        _userRepository.SaveAsync().Wait();

        var result = _userRepository.GetById(user.UserId);
        Assert.IsNotNull(result);
        Assert.AreEqual("testuser", result.Username);
    }

    [Test]
    public void Update_ShouldModifyUser()
    {
        var user = new User { Username = "olduser", Password = "oldpass", LastLogin = DateTime.Now };
        _userRepository.Add(user);
        _userRepository.SaveAsync().Wait();

        user.Username = "newuser";
        _userRepository.Update(user);
        _userRepository.SaveAsync().Wait();

        var result = _userRepository.GetById(user.UserId);
        Assert.AreEqual("newuser", result.Username);
    }

    [Test]
    public void Delete_ShouldRemoveUser()
    {
        var user = new User { Username = "deleteuser", Password = "deletepass", LastLogin = DateTime.Now };
        _userRepository.Add(user);
        _userRepository.SaveAsync().Wait();

        _userRepository.Delete(user.UserId);
        _userRepository.SaveAsync().Wait();

        var result = _userRepository.GetById(user.UserId);
        Assert.IsNull(result);
    }
}
