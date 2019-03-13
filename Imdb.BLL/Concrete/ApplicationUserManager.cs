using Imdb.BLL.Abstract;
using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        IApplicationUserDal _applicationUserDal;

        public ApplicationUserManager(IApplicationUserDal applicationUserDal)
        {
            _applicationUserDal = applicationUserDal;
        }

        public ApplicationUser GetApplicationUserByUserId(int id)
        {
            return _applicationUserDal.Get(x => x.User.UserID == id);
        }

        public void Update(ApplicationUser applicationUser)
        {
            _applicationUserDal.Update(applicationUser);
        }
    }
}
