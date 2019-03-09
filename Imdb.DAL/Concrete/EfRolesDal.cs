using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Concrete
{
    public class EfRolesDal : EfRepositoryBase<Roles, Context>, IRoleDal
    {
    }
}
