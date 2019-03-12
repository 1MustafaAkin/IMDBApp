using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{   
    //3.Adım Nullable ise
    public class CategoryValidator: AbstractValidator<Categories>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori Boş Olamaz");
        }
    }
}
