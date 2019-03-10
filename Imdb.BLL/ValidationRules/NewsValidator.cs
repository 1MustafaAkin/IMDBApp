using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(p => p.NewsTitle).NotEmpty().WithMessage("Haber Başlığı Boş Olamaz");
            RuleFor(p => p.NewsContent).NotEmpty().WithMessage("Haber İçeriği Boş Olamaz");
            RuleFor(p => p.NewsPhoto).NotEmpty().WithMessage("Haber Fotoğrafı Boş Olamaz");
        }
    }
}
