using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Abstract
{   
    //1.Adım
    public interface IWatchListDal : IEntityRepository<WatchList>
    {
    }
}
