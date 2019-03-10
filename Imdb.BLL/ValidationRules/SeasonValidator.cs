using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class SeasonValidator: AbstractValidator<Season>
    {
        public SeasonValidator()
        {
            RuleFor(p => p.SeasonNo).NotEmpty().WithMessage("Sezon Numarası Boş Olamaz");
            RuleFor(p => p.Episode).NotEmpty().WithMessage("Bölüm Bilgisi Boş Olamaz");
        }
    }
}
