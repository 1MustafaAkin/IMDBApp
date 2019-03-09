using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Expression ile mesela tümünü getirmek yerine kullanıcı bir parametre verirse yani film isminde şunları geçenleri getirmek istiyosak parametre olarak linq expression atarız alttaki parametre de diyoruz ki ben sana bi entity vericem bana dönüş türü olarak bool vereceksin
        //Birde kullanıcı isterse filtreyi vermek zorunda olmadığı için filter a null atarız. Yani hiçbişey vermesse Tüm listeyi getall metodu ile çekecek ama filtre verirse o filtreye göre veri döndürecek
        
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //T Get(int id);
        //Filtreye göre entityi getir anlamında
        T Get(Expression<Func<T, bool>> filter); //Burdada id sine göre çekebiliriz
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAllWithInclude(Expression<Func<T, bool>> filter, params string[] include);



    }
}
