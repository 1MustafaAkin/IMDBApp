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
    public class WatchListManager : IWatchListService
    {

        private IWatchListDal _watchListDal;

        public WatchListManager(IWatchListDal watchListDal)
        {
            _watchListDal = watchListDal;
        }

        public void Add(WatchList watchList)
        {
            _watchListDal.Add(watchList);
        }

        public WatchList GetWatchListById(int? id)
        {
            return _watchListDal.Get(x=>x.WatchListID==id);
        }

        public void Update(WatchList watchList)
        {
            _watchListDal.Update(watchList);
        }
    }
}
