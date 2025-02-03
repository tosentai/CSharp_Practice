using Autoservice.DAL.Context;
using Autoservice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.BL.Repository
{
    public class CarRepository : GenericRepository<Car>
    {
        public CarRepository(AutoserviceContext context) : base(context) { }
    }
}
