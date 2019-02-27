using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class MoviesSeriesEmployee : IEntity
    {
        public int MovieEmployeeID { get; set; }
        public int MovieSeriesID { get; set; }
        public int EmployeeID { get; set; }

        public virtual MoviesSeries MoviesSeriesOfEmployee { get; set; }
        public virtual Employee EmployeeOfMovieSeries { get; set; }
    }
}
