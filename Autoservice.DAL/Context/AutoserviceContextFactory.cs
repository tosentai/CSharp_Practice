using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.DAL.Context
{
    public class AutoserviceContextFactory : IDesignTimeDbContextFactory<AutoserviceContext>
    {
        public AutoserviceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoserviceContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoserviceDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new AutoserviceContext(optionsBuilder.Options);
        }
    }
}
