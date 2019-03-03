using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class WatchList : IEntity
    { 
        
        public int WatchListID { get; set; }
        public string WatchListName { get; set; }
        
        public virtual User User { get; set; }
        public virtual List<MoviesSeriesWatchList> WatchLists { get; set; }


    }
}
