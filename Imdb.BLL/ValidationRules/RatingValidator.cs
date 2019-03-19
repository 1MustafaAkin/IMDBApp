using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            //RuleFor(p => p.Comment).NotEmpty().WithMessage("Yorum Boş Olamaz");
            //RuleFor(p => p.Score).NotEmpty().WithMessage("Yorum Boş Olamaz");
        }
    }
}
