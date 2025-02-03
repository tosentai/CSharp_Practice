using Autoservice.DAL.Context;
using Autoservice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.BL.Repository
{
    public class ClientRepository : GenericRepository<Client>
    {
        public ClientRepository(AutoserviceContext context) : base(context) { }
    }
}
