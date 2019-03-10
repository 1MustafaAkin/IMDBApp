using Imdb.BLL.Abstract;
using Imdb.BLL.Utilities;
using Imdb.BLL.ValidationRules;
using Imdb.DAL.Abstract;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public void Add(News news)
        {
            ValidationTool.Validate(new NewsValidator(), news);
            _newsDal.Add(news);
        }

        public void Delete(News news)
        {
            try
            {
                _newsDal.Delete(news);
            }
            catch
            {

                throw new Exception("Silme Gerçekleşmedi");
            }
        }

        public List<News> GetAll()
        {
            return _newsDal.GetAll();
        }

        public News GetNewsById(int? id)
        {
            return _newsDal.Get(x=>x.NewsID == id);
        }

        public void Update(News news)
        {
            ValidationTool.Validate(new NewsValidator(), news);
            _newsDal.Update(news);
        }
    }
}
