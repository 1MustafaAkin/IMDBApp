using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class UserValidator: AbstractValidator<User>
    {
        //FluenValidation ın ManageNuget ten yüklenmesi gerekiyor
        public UserValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Alanı Boş Olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre 6 Haneden fazla olmalı");
        }

    }
}
