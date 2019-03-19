﻿using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IApplicationUserService
    {
        ApplicationUser GetApplicationUserByUserName(string name);
        void Update(ApplicationUser applicationUser);
    }
}
