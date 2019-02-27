using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.DependencyResolver.Ninject
{
    public class InstanceFactory
    {
        //new ledikten sonra ninjectModule parametresini alıyoruz
        public static T GetInstance<T>()
        {
            // businessModule classında yaptığımız konfigrasyonları bir kutucuk olarak düşünelim buraya bir modül olarak verdik
            var kernel = new StandardKernel(new BusinessModule()); // Burası dahada iyileştirilebilir
            return kernel.Get<T>();
        }
    }
}
