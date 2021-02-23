using ServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApp.Context
{
    public static class DbContextObject
    {
        public static dbServicesEntities DB = new dbServicesEntities(); 
    }
}
