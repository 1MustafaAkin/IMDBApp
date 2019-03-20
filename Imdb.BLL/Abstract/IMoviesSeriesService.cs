using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IMoviesSeriesService
    {
        List<MoviesSeries> GetAll();
        //Çoka çok bunu uygulama anında yaz
        //List<MoviesSeries> GetMoviesSeriesByCategory(int categoryId);
        List<MoviesSeries> GetMoviesSeriesByMovieSeriesName(string moviesSeriesName);
        List<MoviesSeries> GetMoviesSeriesListById(int id);
        MoviesSeries GetMoviesSeriesById(int? id);
        List<MoviesSeries> GetMoviesSeriesByIsSeries();
        IEnumerable<MoviesSeries> GetMoviesSeriesByIsMovies();
        //List<MoviesSeries> GetMoviesSeriesByIsMovies();
        void Add(MoviesSeries moviesSeries);
        void Update(MoviesSeries moviesSeries);
        void Delete(MoviesSeries moviesSeries);
    }
}
