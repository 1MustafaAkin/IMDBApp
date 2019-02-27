using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class MoviesSeriesCategory : IEntity
    {
        public int ID { get; set; }
        public int MovieSeriesID { get; set; }
        public int CategoryID { get; set; }

        public virtual MoviesSeries MovieSeriesOfCategory { get; set; }
        public virtual Categories CategoryOfMovieSeries { get; set; }
    }
}
