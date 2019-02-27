using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Employee:IEntity
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int CountryID { get; set; }
        public int RoleID { get; set; }

        public virtual Country Country { get; set; }
        public virtual Roles Role { get; set; }
        public virtual List<MoviesSeriesEmployee> MoviesSeriesOfEmployee { get; set; }


    }
}
