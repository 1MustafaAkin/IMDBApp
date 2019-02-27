using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Roles : IEntity
    {
        public int RoleID { get; set; }
        public string Role { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
