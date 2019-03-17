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
    public class MoviesSeriesWatchListManager : IMoviesSeriesWatchListService
    {
        IMoviesSeriesWatchListDal _moviesSeriesWatchListDal;

        public MoviesSeriesWatchListManager(IMoviesSeriesWatchListDal moviesSeriesWatchListDal)
        {
            _moviesSeriesWatchListDal = moviesSeriesWatchListDal;
        }

        public void Add(MoviesSeriesWatchList moviesSeriesWatchList)
        {
            _moviesSeriesWatchListDal.Add(moviesSeriesWatchList);
        }

        public void Delete(MoviesSeriesWatchList moviesSeriesWatchList)
        {
            try
            {
                _moviesSeriesWatchListDal.Delete(moviesSeriesWatchList);
            }
            catch
            {

                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public List<MoviesSeriesWatchList> GetAll()
        {
            return _moviesSeriesWatchListDal.GetAll();
        }

        public MoviesSeriesWatchList GetMoviesSeriesWatchListById(int? id)
        {
            return _moviesSeriesWatchListDal.Get(x => x.MoviesSeriesWatchListID == id);
        }

        public List<MoviesSeriesWatchList> GetMoviesSeriesWatchListByWatchList(int id)
        {
            return _moviesSeriesWatchListDal.GetAll(x=>x.WatchListID==id);
        }

        public void Update(MoviesSeriesWatchList moviesSeriesWatchList)
        {
            _moviesSeriesWatchListDal.Update(moviesSeriesWatchList);
        }
    }
}
