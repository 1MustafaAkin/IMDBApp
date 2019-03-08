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
    public class UserManager : IUserService
    {
        //EfUserDal _userDal = new EfUserDal(); // Bu kötü kod alışkanlığı User Dal a bağımlı hale gelmememiz lazım 
        //Üstteki sadece Entity Framework için çalışır buraya Nhibernate i veya yarın başka ekenecek olan bir yapıyı gönderdiğimiz zaman sürekli olarak new almamaız gerekecektir.
        //Bunun yerine Dependency Injection ile alltaki koda Nhibernate te atayabilriiz EntityFrameworkte böylece bağımlılık ortadan kalkar.
        private IUserDal _userDal;

        //bu user dal new lendiğinde bana IUserDal türünde bir nesne ver (nh yada ef olabilir)
        //Burada constructor vasıtası ile data acceess layerda hangi concrete ile çalışacağımızı managerda soyut olarak verdik ve kullanıcıdan gelen semout bilgiyi parametre olarak aldık.
        public UserManager(IUserDal userDal)
        {
            //constructor injection
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            //Önemli bilgi iş katmanında hiç bişeyi new lememek gerekir çünkü new lediğimi alana bağımlı olmuş oluruz..
            //Busines Code --> burda bu kişi datayı çekmeye çalışıyor ama acaba datayı çekebilirmi bunun kontrolleri yapılıyor
            return _userDal.GetAll();
        }

        //TODO
        //public List<User> GetUsersByTitle(int titleId)
        //{
        //    //Expression lu ifadeleri burada kullandık getAll fonksiyonuna linq sorgusu gönderdik, yani parametresiz göndererek tüm userları çekebildğimiz gibi linq sorgusu göndererek sorguya göre çekmeyide yapmış olduk
        //    return _userDal.GetAll(x => x.TitleID == titleId);
        //}

        public List<User> GetUsersByUserName(string userName)
        {
            //Burada yine Expression parametre olarak yazdığımız yere linq sorgusu göndermiş olduk
            return _userDal.GetAll(x => x.UserName.ToLower().Contains(userName.ToLower()));
        }

        public void Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDal.Add(user);
        }

        public void Update(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDal.Update(user);
        }

        public void Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }

        }
    }
}
