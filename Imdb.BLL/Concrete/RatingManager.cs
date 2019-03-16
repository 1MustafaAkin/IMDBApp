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
     public class RatingManager :IRatingService
    {
        private IRatingDal _ratingDal;
        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }

        public List<Rating> GetRatingByMoviesID(int id)
        {
            return _ratingDal.GetAll(x => x.MoviesSeriesID == id);
        }
    }
}
