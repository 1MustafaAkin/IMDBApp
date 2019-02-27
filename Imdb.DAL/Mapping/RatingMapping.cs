using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class RatingMapping: EntityTypeConfiguration<Rating>
    {
        public RatingMapping()
        {
            HasKey(x=>x.RatingID);

            Property(x => x.Comment).HasMaxLength(500);
            Property(x => x.Score).HasColumnType("smallint").IsRequired();

            HasRequired(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserID);
            HasRequired(x => x.RatingOfMovieSeries).WithMany(x => x.Ratings).HasForeignKey(x => x.MoviesSeriesID);

        }
    }
}
