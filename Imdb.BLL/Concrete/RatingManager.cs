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
     public class RatingManager :IRatingService
    {
        private IRatingDal _ratingDal;
        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }

        public void Add(Rating rating)
        {
            _ratingDal.Add(rating);
        }

        public void Delete(Rating rating)
        {
            try
            {
                _ratingDal.Delete(rating);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public List<Rating> GetAll()
        {
            return _ratingDal.GetAll();
        }

        public Rating GetRatingById(int? id)
        {
            return _ratingDal.Get(x => x.RatingID == id);
        }

        public List<Rating> GetRatingByMoviesID(int id)
        {
            return _ratingDal.GetAll(x => x.MoviesSeriesID == id);
        }

        public Rating GetRatingByUserAndMovie(int userId, int movieId)
        {
            return _ratingDal.Get(x => x.UserID == userId && x.MoviesSeriesID == movieId);
        }

        public List<Rating> GetRatingByUserID(int id)
        {
            return _ratingDal.GetAll(x => x.UserID == id);
        }

        public void Update(Rating rating)
        {
            _ratingDal.Update(rating);
        }
    }
}
