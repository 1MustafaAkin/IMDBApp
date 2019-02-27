using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Mapping
{
    public class EmployeeMapping:EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            HasKey(x=>x.EmployeeID);

            Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            Property(x => x.LastName).HasMaxLength(30).IsRequired();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.FirstName).HasMaxLength(30);
        }
    }
}
