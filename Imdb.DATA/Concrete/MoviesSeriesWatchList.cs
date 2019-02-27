using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class MoviesSeriesWatchList : IEntity
    {
        public int MoviesSeriesWatchListID { get; set; }
        public int MoviesSeriesID { get; set; }
        public int WatchListID { get; set; }

        public virtual MoviesSeries MoviesSeries { get; set; }
        public virtual WatchList WatchList { get; set; }
        public virtual WatchState WatchState { get; set; }
    }
}
