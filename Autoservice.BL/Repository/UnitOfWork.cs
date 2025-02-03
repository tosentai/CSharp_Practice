using Autoservice.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.BL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly AutoserviceContext _context;

        public UnitOfWork(AutoserviceContext context)
        {
            _context = context;
            Cars = new CarRepository(context);
            Clients = new ClientRepository(context);
            Employees = new EmployeeRepository(context);
            Orders = new OrderRepository(context);
            OrderDetails = new OrderDetailRepository(context);
            Services = new ServiceRepository(context);
            Users = new UserRepository(context);
        }

        public CarRepository Cars { get; }
        public ClientRepository Clients { get; }
        public EmployeeRepository Employees { get; }
        public OrderRepository Orders { get; }
        public OrderDetailRepository OrderDetails { get; }
        public ServiceRepository Services { get; }
        public UserRepository Users { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
