using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface ICategoryService
    {
        List<Categories> GetAll();
        Categories GetCategoryById(int? id);
        void Add(Categories category);
        void Update(Categories category);
        void Delete(Categories category);
    }
}
