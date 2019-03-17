using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IMoviesSeriesEmployeeService
    {
        List<MoviesSeriesEmployee> GetAll();
        MoviesSeriesEmployee GetMoviesSeriesEmployeeById(int? id);
        List<MoviesSeriesEmployee> GetEmployeeByMoviesSeriesId(int? id);
        void Add(MoviesSeriesEmployee moviesSeriesEmployee);
        void Update(MoviesSeriesEmployee moviesSeriesEmployee);
        void Delete(MoviesSeriesEmployee moviesSeriesEmployee);
    }
}
