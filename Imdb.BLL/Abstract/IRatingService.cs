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
    }
}
