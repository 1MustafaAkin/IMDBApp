using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class WatchStateMapping: EntityTypeConfiguration<WatchState>
    {
        public WatchStateMapping()
        {
            HasKey(x=>x.WatchStateID);

            Property(x => x.State).HasMaxLength(20);
        }
    }
}
