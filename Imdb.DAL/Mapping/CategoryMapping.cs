using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class CategoryMapping:EntityTypeConfiguration<Categories>
    {
        public CategoryMapping()
        {
            HasKey(x=>x.CategoryID);

            Property(x => x.CategoryName).HasMaxLength(30).IsRequired();
        }
    }
}
