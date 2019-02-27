using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        List<User> GetUsersByTitle(int titleId);
        List<User> GetUsersByUserName(string userName);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
