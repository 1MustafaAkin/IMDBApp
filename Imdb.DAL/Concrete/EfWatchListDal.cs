using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Concrete
{   
    //2.Adım
    public class EfWatchListDal: EfRepositoryBase<WatchList, Context>, IWatchListDal
    {
    }
}
