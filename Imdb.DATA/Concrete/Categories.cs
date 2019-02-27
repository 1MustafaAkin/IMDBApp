using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Categories: IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual List<MoviesSeriesCategory> MoviesSeriesOfCategory { get; set; }

    }
}
