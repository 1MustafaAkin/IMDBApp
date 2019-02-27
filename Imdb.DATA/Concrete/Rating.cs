using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Rating : IEntity
    {
        public int RatingID { get; set; }
        public string Comment { get; set; }
        public short Score { get; set; }

        public int UserID { get; set; }
        public int MoviesSeriesID { get; set; }


        public virtual User User { get; set; }
        public virtual MoviesSeries RatingOfMovieSeries { get; set; }

    }
}
