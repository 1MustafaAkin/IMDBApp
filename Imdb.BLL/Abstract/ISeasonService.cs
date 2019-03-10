using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Abstract
{
    public interface ISeasonService
    {
        List<Season> GetAll();
        Season GetSeasonById(int? id);
        void Add(Season season);
        void Update(Season season);
        void Delete(Season season);
        IEnumerable<Season> GetAllWithInclude(params string[] include);
        Season GetAllWithIncludeById(int? id, params string[] include);
    }
}
