using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Season : IEntity
    {
        public int SeasonID { get; set; }
        public short SeasonNo { get; set; }
        public short Episode { get; set; }

        public int MoviesSeriesID { get; set; }

        public virtual MoviesSeries MoviesSeries { get; set; }
    }
}
