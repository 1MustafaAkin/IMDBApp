using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IApplicationUserService
    {
        ApplicationUser GetApplicationUserByUserId(int id);
        void Update(ApplicationUser applicationUser);
    }
}
