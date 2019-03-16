using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IMoviesSeriesCategoryService
    {
        List<MoviesSeriesCategory> GetAll();
        MoviesSeriesCategory GetMoviesSeriesCategoryById(int? id);
        void Add(MoviesSeriesCategory moviesSeriesCategory);
        void Update(MoviesSeriesCategory moviesSeriesCategory);
        void Delete(MoviesSeriesCategory moviesSeriesCategory);
    }
}
