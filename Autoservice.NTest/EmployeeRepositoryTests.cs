using System.Linq;
using System.Threading.Tasks;
using Autoservice.DAL.Models;
using Autoservice.BL.Repository;
using NUnit.Framework;

[TestFixture]
public class EmployeeRepositoryTests : BaseRepositoryTest
{
    private EmployeeRepository _employeeRepository;

    [SetUp]
    public void Init() => _employeeRepository = new EmployeeRepository(_context);

    [Test]
    public void Add_ShouldAddEmployee()
    {
        var employee = new Employee { Name = "John Doe", Position = "Mechanic", Phone = "123456789" };
        _employeeRepository.Add(employee);
        _employeeRepository.SaveAsync().Wait();

        var result = _employeeRepository.GetById(employee.EmployeeId);
        Assert.IsNotNull(result);
        Assert.AreEqual("John Doe", result.Name);
    }

    [Test]
    public void GetAll_ShouldReturnAllEmployees()
    {
        var emp1 = new Employee { Name = "Alice Smith", Position = "Technician", Phone = "111111111" };
        var emp2 = new Employee { Name = "Bob Johnson", Position = "Manager", Phone = "222222222" };

        _employeeRepository.Add(emp1);
        _employeeRepository.Add(emp2);
        _employeeRepository.SaveAsync().Wait();

        var result = _employeeRepository.GetAll();
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public void GetById_ShouldReturnEmployee()
    {
        var employee = new Employee { Name = "Eve Brown", Position = "Supervisor", Phone = "333333333" };
        _employeeRepository.Add(employee);
        _employeeRepository.SaveAsync().Wait();

        var result = _employeeRepository.GetById(employee.EmployeeId);
        Assert.IsNotNull(result);
        Assert.AreEqual("Eve Brown", result.Name);
    }

    [Test]
    public void Update_ShouldModifyEmployee()
    {
        var employee = new Employee { Name = "Tom White", Position = "Assistant", Phone = "444444444" };
        _employeeRepository.Add(employee);
        _employeeRepository.SaveAsync().Wait();

        employee.Position = "Lead Technician";
        _employeeRepository.Update(employee);
        _employeeRepository.SaveAsync().Wait();

        var result = _employeeRepository.GetById(employee.EmployeeId);
        Assert.AreEqual("Lead Technician", result.Position);
    }

    [Test]
    public void Delete_ShouldRemoveEmployee()
    {
        var employee = new Employee { Name = "Sam Green", Position = "Intern", Phone = "666666666" };
        _employeeRepository.Add(employee);
        _employeeRepository.SaveAsync().Wait();

        _employeeRepository.Delete(employee.EmployeeId);
        _employeeRepository.SaveAsync().Wait();

        var result = _employeeRepository.GetById(employee.EmployeeId);
        Assert.IsNull(result);
    }
}
