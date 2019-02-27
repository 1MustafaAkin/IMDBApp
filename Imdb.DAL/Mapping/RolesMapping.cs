using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class RolesMapping: EntityTypeConfiguration<Roles>
    {
        public RolesMapping()
        {
            HasKey(x=>x.RoleID);

            Property(x => x.Role).HasMaxLength(30);
        }
    }
}
