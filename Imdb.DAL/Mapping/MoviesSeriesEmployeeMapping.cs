using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class MoviesSeriesEmployeeMapping: EntityTypeConfiguration<MoviesSeriesEmployee>
    {
        public MoviesSeriesEmployeeMapping()
        {
            HasKey(x => x.MovieEmployeeID);

            HasRequired(x => x.MoviesSeriesOfEmployee).WithMany(x => x.EmployeesOfMovieSeries).HasForeignKey(x => x.EmployeeID);
            HasRequired(x => x.EmployeeOfMovieSeries).WithMany(x => x.MoviesSeriesOfEmployee).HasForeignKey(x => x.MovieSeriesID);
        }
    }
}
