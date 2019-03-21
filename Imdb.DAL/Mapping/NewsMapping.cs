using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class NewsMapping: EntityTypeConfiguration<News>
    {
        public NewsMapping()
        {
            HasKey(x=>x.NewsID);

            Property(x => x.NewsTitle).HasMaxLength(80).IsRequired();
            Property(x => x.NewsContent).HasMaxLength(3000).IsRequired();
            Property(x => x.NewsPhoto).HasMaxLength(250).IsRequired();
        }
    }
}
