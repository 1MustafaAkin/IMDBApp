using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Country : IEntity
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }


        public virtual List<Employee> Employees { get; set; }
    }
}
