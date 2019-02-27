using Imdb.BLL.Abstract;
using Imdb.BLL.Utilities;
using Imdb.BLL.ValidationRules;
using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Concrete
{
    public class MoviesSeriesManager : IMoviesSeriesService
    {
        IMoviesSeriesDal _moviesSeriesDal;

        public MoviesSeriesManager(IMoviesSeriesDal moviesSeriesDal)
        {
            _moviesSeriesDal = moviesSeriesDal;
        }

        public void Add(MoviesSeries moviesSeries)
        {
            ValidationTool.Validate(new MoviesSeriesValidator(), moviesSeries);
            _moviesSeriesDal.Add(moviesSeries);
        }

        public void Delete(MoviesSeries moviesSeries)
        {
            try
            {
                _moviesSeriesDal.Delete(moviesSeries);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public List<MoviesSeries> GetAll()
        {
            return _moviesSeriesDal.GetAll();
        }

        public List<MoviesSeries> GetMoviesSeriesByMovieSeriesName(string moviesSeriesName)
        {
            return _moviesSeriesDal.GetAll(x=>x.MovieSeriesName.ToLower()==moviesSeriesName);
        }

        public void Update(MoviesSeries moviesSeries)
        {
            ValidationTool.Validate(new MoviesSeriesValidator(), moviesSeries);
            _moviesSeriesDal.Update(moviesSeries);
        }
    }
}
