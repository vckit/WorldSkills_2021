using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessia.Base
{
    /// <summary>
    /// Обращение к базе
    /// </summary>
    public class BaseClass
    {
        public static SessionBaseEntities db = new SessionBaseEntities();
    }
}
