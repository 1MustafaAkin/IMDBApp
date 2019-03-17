using Imdb.BLL.Abstract;
using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Concrete
{
    public class MoviesSeriesEmployeeManager : IMoviesSeriesEmployeeService
    {
        IMoviesSeriesEmployeeDal _moviesSeriesEmployeeDal;

        public MoviesSeriesEmployeeManager(IMoviesSeriesEmployeeDal moviesSeriesEmployeeDal)
        {
            _moviesSeriesEmployeeDal = moviesSeriesEmployeeDal;
        }

        public void Add(MoviesSeriesEmployee moviesSeriesEmployee)
        {
            _moviesSeriesEmployeeDal.Add(moviesSeriesEmployee);
        }

        public void Delete(MoviesSeriesEmployee moviesSeriesEmployee)
        {
            try
            {
                _moviesSeriesEmployeeDal.Delete(moviesSeriesEmployee);
            }
            catch
            {

                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public List<MoviesSeriesEmployee> GetAll()
        {
            return _moviesSeriesEmployeeDal.GetAll();
        }

        public MoviesSeriesEmployee GetMoviesSeriesEmployeeById(int? id)
        {
            return _moviesSeriesEmployeeDal.Get(x => x.MovieEmployeeID == id);
        }

        public void Update(MoviesSeriesEmployee moviesSeriesEmployee)
        {
            _moviesSeriesEmployeeDal.Update(moviesSeriesEmployee);
        }
    }
}
