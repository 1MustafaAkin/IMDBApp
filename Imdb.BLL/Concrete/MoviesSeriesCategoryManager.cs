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
    public class MoviesSeriesCategoryManager : IMoviesSeriesCategoryService
    {
        private IMoviesSeriesCategoryDal _moviesSeriesCategoryDal;

        public MoviesSeriesCategoryManager(IMoviesSeriesCategoryDal moviesSeriesCategoryDal)
        {
            _moviesSeriesCategoryDal = moviesSeriesCategoryDal;        
        }

        public void Add(MoviesSeriesCategory moviesSeriesCategory)
        {
            _moviesSeriesCategoryDal.Add(moviesSeriesCategory);
        }

        public void Delete(MoviesSeriesCategory moviesSeriesCategory)
        {
            try
            {
                _moviesSeriesCategoryDal.Delete(moviesSeriesCategory);
            }
            catch
            {

                throw new Exception("Silme işlemi gerçekleşmedi");
            }
        }

        public List<MoviesSeriesCategory> GetAll()
        {
            return _moviesSeriesCategoryDal.GetAll();
        }

        public MoviesSeriesCategory GetMoviesSeriesCategoryById(int? id)
        {
            return _moviesSeriesCategoryDal.Get(x=>x.ID==id);
        }

        public void Update(MoviesSeriesCategory moviesSeriesCategory)
        {
            _moviesSeriesCategoryDal.Update(moviesSeriesCategory);
        }
    }
}
