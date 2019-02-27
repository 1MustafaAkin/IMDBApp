using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.Utilities
{
    //Sıklıkla kullanacağımız için statik ypatık
    public class ValidationTool
    {
        //Burda IValidator dememizin sebebi hem userValidator hemde employeeValidator ve birçoğu içinde çalışabilmesi için object vermemizin sebebi her entity i parametre olara alabilmesi için yukarı çevrim
        public static void Validate(IValidator validator, object entity)
        {
            //Burda gelen validatora göre UserValidatorda olabilir Employee validator da kuralları gelen entitye göre uygulanması sağlanır.
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);//Hata varsa bir exception fırlattık
            }
        }
    }
}
