using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class WatchState : IEntity
    {
        public int WatchStateID { get; set; }
        public string State { get; set; }

        public virtual MoviesSeriesWatchList MoviesSeriesWatchList { get; set; }

    }
}
