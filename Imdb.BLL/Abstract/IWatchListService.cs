using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface IWatchListService
    {
        void Add(WatchList watchList);
        void Update(WatchList watchList);
        WatchList GetWatchListById(int? id);
    }
}
