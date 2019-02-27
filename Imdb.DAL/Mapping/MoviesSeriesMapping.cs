using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    class MoviesSeriesMapping: EntityTypeConfiguration<MoviesSeries>
    {
        public MoviesSeriesMapping()
        {
            HasKey(x => x.MovieSeriesID);

            Property(x => x.MovieSeriesName).HasMaxLength(30).IsRequired();
            Property(x => x.Description).HasMaxLength(150).IsRequired();
            Property(x => x.ReleaseDate).HasColumnType("datetime2");
            Property(x => x.Duration).HasColumnType("smallint");
            Property(x => x.Trailer).HasMaxLength(250).IsRequired();
            Property(x => x.Photos).HasMaxLength(250).IsRequired();
            Property(x => x.IsSeries).HasColumnType("bit").IsOptional();
        }
    }
}
