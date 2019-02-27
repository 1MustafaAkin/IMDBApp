using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class CountryMapping: EntityTypeConfiguration<Country>
    {
        public CountryMapping()
        {
            HasKey(x=>x.CountryID);

            Property(x => x.CountryName).HasMaxLength(30).IsRequired();
        }
    }
}
