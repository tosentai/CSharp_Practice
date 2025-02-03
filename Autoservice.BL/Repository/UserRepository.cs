﻿using Autoservice.DAL.Context;
using Autoservice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.BL.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AutoserviceContext context) : base(context) { }
    }
}
