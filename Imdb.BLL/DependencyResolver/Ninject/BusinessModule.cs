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
            //Bir yerden IProductService istenirse  ona ProductManager sınıfını döndür.Yani somut bir product manager oluştur ve onu IProductService ver
            //Birde burada Bu tip sınıflar için bir kere üretildiğinde bir daha üretilmesin diye InSingletonScope 
            Bind<IUserService>().To<UserManager>().InSingletonScope(); // burda kullanıcı ProductService isterse ProductManager ı new leyip veriyoruz    
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IMoviesSeriesService>().To<MoviesSeriesManager>().InSingletonScope();
            Bind<IMoviesSeriesDal>().To<EfMoviesSeriesDal>().InSingletonScope();
            //Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            //Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }
    }
}
