using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class MoviesSeries : IEntity
    {
        public int MovieSeriesID { get; set; }
        public string MovieSeriesName { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public short Duration { get; set; }
        public string Trailer { get; set; }
        public string Photos { get; set; }
        public bool IsSeries { get; set; }

        public virtual List<MoviesSeriesCategory> CategoriesOfMovieSeries { get; set; }
        public virtual List<MoviesSeriesEmployee> EmployeesOfMovieSeries { get; set; }
        public virtual List<Season> SeasonsOfSeries { get; set; }
        public virtual List<MoviesSeriesWatchList> WatchListsOfMoviesSeries { get; set; }
        public virtual List<Rating> Ratings { get; set; }
    }
}
