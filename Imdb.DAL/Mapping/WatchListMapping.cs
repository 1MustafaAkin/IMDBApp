using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class WatchListMapping: EntityTypeConfiguration<WatchList>
    {
        public WatchListMapping()
        {
            HasKey(x=>x.WatchListID);

            Property(x=>x.WatchListName).HasMaxLength(30);
        }
    }
}
