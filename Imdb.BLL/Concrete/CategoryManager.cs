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
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Categories category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);
            _categoryDal.Add(category);
        }

        public void Delete(Categories category)
        {
            try
            {
                _categoryDal.Delete(category);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public List<Categories> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Categories GetCategoryById(int? id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public void Update(Categories category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);
            _categoryDal.Update(category);
        }
    }
}
