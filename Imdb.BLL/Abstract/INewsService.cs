using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface INewsService
    {
        List<News> GetAll();
        News GetNewsById(int? id);
        void Add(News news);
        void Update(News news);
        void Delete(News news);
    }
}
