using Imdb.BLL.Abstract;
using Imdb.BLL.Concrete;
using Imdb.DAL.Abstract;
using Imdb.DAL.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.DependencyResolver.Ninject
{
    //Ninject IoC Container 
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //Bir yerden IUserService istenirse  ona UserManager sınıfını döndür.Yani somut bir user manager oluştur ve onu IUserService'e ver
            //Birde burada Bu tip sınıflar için bir kere üretildiğinde bir daha üretilmesin diye InSingletonScope 
            // burda kullanıcı IUserService isterse ProductManager ı new leyip veriyoruz    
            Bind<IUserService>().To<UserManager>().InSingletonScope(); 
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IMoviesSeriesService>().To<MoviesSeriesManager>().InSingletonScope();
            Bind<IMoviesSeriesDal>().To<EfMoviesSeriesDal>().InSingletonScope();

            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();

            Bind<ICountryService>().To<CountryManager>().InSingletonScope();
            Bind<ICountryDal>().To<EfCountryDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRolesDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<ISeasonService>().To<SeasonManager>().InSingletonScope();
            Bind<ISeasonDal>().To<EfSeasonDal>().InSingletonScope();

            Bind<INewsService>().To<NewsManager>().InSingletonScope();
            Bind<INewsDal>().To<EfNewsDal>().InSingletonScope();

            Bind<IWatchListService>().To<WatchListManager>().InSingletonScope();
            Bind<IWatchListDal>().To<EfWatchListDal>().InSingletonScope();

            Bind<IApplicationUserService>().To<ApplicationUserManager>().InSingletonScope();
            Bind<IApplicationUserDal>().To<EfApplicationUserDal>().InSingletonScope();

        }
    }
}
