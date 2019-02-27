using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class TitleMapping: EntityTypeConfiguration<Title>
    {
        public TitleMapping()
        {
            HasKey(x=>x.TitleID);

            Property(x => x.TitleName).HasMaxLength(30);
        }
    }
}
