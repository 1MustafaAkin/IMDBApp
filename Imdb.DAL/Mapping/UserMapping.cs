using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class UserMapping: EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(x => x.UserID);

            Property(x => x.UserName).HasMaxLength(30).IsRequired();
            Property(x => x.Password).HasMaxLength(12).IsRequired();
            Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            Property(x => x.LastName).HasMaxLength(30).IsRequired();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Gender).HasColumnType("bit").IsOptional();
            Property(x => x.Email).HasMaxLength(50).IsRequired();
            Property(x => x.Avatar).HasMaxLength(250);
            HasRequired(x => x.WatchList).WithRequiredPrincipal(x => x.User);

            
        }
    }
}
