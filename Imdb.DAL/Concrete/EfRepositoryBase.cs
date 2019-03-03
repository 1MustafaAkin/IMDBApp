using Imdb.DAL.Abstract;
using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DAL.Concrete
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                //Entry insert , update , delete  için ilgili nesneye erişebilecek kodu yazabiliyoruz
                var addedEntity = db.Entry(entity);
                //Yeni oluşan bu nesneyi veritabanında bulamayacağımız için bunu yeni eklenecek olarak işaretliyoruz
                addedEntity.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                //Entry insert , update , delete  için ilgili nesneye erişebilecek kodu yazabiliyoruz
                var deletedEntity = db.Entry(entity);
                //Deleted yani entitye abone ol onu silincek diye işaretle kısacısı delete kodunu çalıştıracak
                deletedEntity.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                //Entry insert , update , delete  için ilgili nesneye erişebilecek kodu yazabiliyoruz
                var updatedEntity = db.Entry(entity);
                //Modified yani bu entity var veritabanında ona abone ol ve durmunu update olarak işaretle yani kısacası update kodu çalışacak
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //Burdaki TContext demmeizin sebebi istediğimiz Context ile çalışabilmek için generic yaptık
            using (TContext db = new TContext())
            {
                //return db.User.ToList();
                //Burda ise filtre varsa filtreli olan versiyonun yoksa tüm verileri getirme işlemi uygulanır
                //Set ile TEntityi contexte abone ediyoruz aslında yani db.User.ToList() dedik burda Tentity e hangi entity gelirse ona göre listeleyecek
                return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext db = new TContext())
            {
                //return db.User.SingleOrDefault(x => x.UserID == id);

                //Burda filter gelebeilecek linq sorgusuna göre çekeblirizi 
                //return db.User.SingleOrDefault(filter);

                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }
    }
}
