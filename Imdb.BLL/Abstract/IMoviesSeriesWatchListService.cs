using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IMoviesSeriesWatchListService
    {
        List<MoviesSeriesWatchList> GetAll();
        List<MoviesSeriesWatchList> GetMoviesSeriesWatchListByWatchList(int id);
        MoviesSeriesWatchList GetMoviesSeriesWatchListById(int? id);
        void Add(MoviesSeriesWatchList moviesSeriesWatchList);
        void Update(MoviesSeriesWatchList moviesSeriesWatchList);
        void Delete(MoviesSeriesWatchList moviesSeriesWatchList);
    }
}
