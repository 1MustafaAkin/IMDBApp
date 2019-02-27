using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class MoviesSeriesCategoryMapping:EntityTypeConfiguration<MoviesSeriesCategory>
    {
        public MoviesSeriesCategoryMapping()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.CategoryOfMovieSeries).WithMany(x => x.MoviesSeriesOfCategory).HasForeignKey(x => x.MovieSeriesID);
            HasRequired(x => x.MovieSeriesOfCategory).WithMany(x => x.CategoriesOfMovieSeries).HasForeignKey(x => x.CategoryID);
        }
    }
}
