using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class SeasonMapping: EntityTypeConfiguration<Season>
    {
        public SeasonMapping()
        {
            HasKey(x => x.SeasonID);

            Property(x=>x.SeasonNo).HasColumnType("smallint");
            Property(x=>x.Episode).HasColumnType("smallint");

            HasRequired(x => x.MoviesSeries).WithMany(x => x.SeasonsOfSeries).HasForeignKey(x=>x.MoviesSeriesID);
           
        }
    }
}
