using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IRatingService
    {
        List<Rating> GetRatingByMoviesID(int id);
        List<Rating> GetRatingByUserID(int id);
        Rating GetRatingByUserAndMovie(int userId,int movieId);
        Rating GetScoreByUserAndMovie(int userId,int movieId);
        Rating GetCommentByUserAndMovie(int userId,int movieId);
        IEnumerable<Rating> GetCommentByUserAndMovieWithInclude(int? movieId, params string[] include);
        List<Rating> GetAll();
        Rating GetRatingById(int? id);
        void Add(Rating rating);
        void Update(Rating rating);
        void Delete(Rating rating);
    }
}
