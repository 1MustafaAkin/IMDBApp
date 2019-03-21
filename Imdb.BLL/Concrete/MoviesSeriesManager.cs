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
        private IMoviesSeriesDal _moviesSeriesDal;

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

        public MoviesSeries GetMoviesSeriesById(int? id)
        {
            return _moviesSeriesDal.Get(x=>x.MovieSeriesID==id);
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

        public List<MoviesSeries> GetMoviesSeriesByIsSeries()
        {
            return _moviesSeriesDal.GetAll(x => x.IsSeries == true);
        }

        public IEnumerable<MoviesSeries> GetMoviesSeriesByIsMovies()
        {
            return _moviesSeriesDal.GetAll(x => x.IsSeries == false);
        }

        public List<MoviesSeries> GetMoviesSeriesListById(int id)
        {
            return _moviesSeriesDal.GetAll(x => x.MovieSeriesID == id);
        }

        public IEnumerable<MoviesSeries> GetMoviesSeriesByIsMoviesOrderBy()
        {
            return _moviesSeriesDal.GetAll(x => x.IsSeries == false).OrderBy(x => x.MovieSeriesName).ToList();
        }

        public IEnumerable<MoviesSeries> GetMoviesSeriesByIsMoviesOrderByDescending()
        {
            return _moviesSeriesDal.GetAll(x => x.IsSeries == false).OrderByDescending(x => x.MovieSeriesName).ToList();
        }
    }
}
