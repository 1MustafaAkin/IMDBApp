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
    public class SeasonManager : ISeasonService
    {

        private ISeasonDal _seasonDal;

        public SeasonManager(ISeasonDal seasonDal)
        {
            _seasonDal = seasonDal;
        }

        public void Add(Season season)
        {
            ValidationTool.Validate(new SeasonValidator(), season);
            _seasonDal.Add(season);
        }

        public void Delete(Season season)
        {
            try
            {
                _seasonDal.Delete(season);
            }
            catch
            {

                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public List<Season> GetAll()
        {
            return _seasonDal.GetAll();
        }

        public IEnumerable<Season> GetAllWithInclude(params string[] include)
        {
            return _seasonDal.GetAllWithInclude(null, include);
        }

        public Season GetAllWithIncludeById(int? id, params string[] include)
        {
            return _seasonDal.GetAllWithInclude(x => x.SeasonID == id, include).FirstOrDefault();
        }

        public Season GetSeasonById(int? id)
        {
            return _seasonDal.Get(x => x.SeasonID == id);
        }

        public void Update(Season season)
        {
            ValidationTool.Validate(new SeasonValidator(), season);
            _seasonDal.Update(season);
        }
    }
}
