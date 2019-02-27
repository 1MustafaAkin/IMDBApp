using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class MoviesSeriesValidator : AbstractValidator<MoviesSeries>
    {
        public MoviesSeriesValidator()
        {   
            //Burası dizide olabilir şimdilik böyle kalsın sonrasında IsSeriese göre Must ile kendimiz bir kural yazıcaz
            RuleFor(p => p.MovieSeriesName).NotEmpty().WithMessage("Film Adı Boş Olamaz Adı Boş Olamaz");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama Boş Olamaz");
            RuleFor(p => p.ReleaseDate).NotEmpty().WithMessage("Yayın Tarihi Boş Olamaz");
            RuleFor(p => p.Duration).NotEmpty().WithMessage("Film Süresi Boş Olamaz");
            RuleFor(p => p.Trailer).NotEmpty().WithMessage("Trailer Boş Olamaz");
            RuleFor(p => p.Photos).NotEmpty().WithMessage("Film Posteri Boş Olamaz");
        }

    }
}
