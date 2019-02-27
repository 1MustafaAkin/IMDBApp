using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class MovieSeriesWatchListMapping: EntityTypeConfiguration<MoviesSeriesWatchList>
    {
        public MovieSeriesWatchListMapping()
        {
            HasKey(x=>x.MoviesSeriesWatchListID);

            HasRequired(x => x.MoviesSeries).WithMany(x => x.WatchListsOfMoviesSeries).HasForeignKey(x => x.MoviesSeriesID);
            HasRequired(x => x.WatchList).WithMany(x => x.WatchLists).HasForeignKey(x => x.WatchListID);
            HasRequired(x => x.WatchState).WithRequiredPrincipal(x => x.MoviesSeriesWatchList);
        }
    }
}
