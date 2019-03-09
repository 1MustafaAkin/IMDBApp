using FluentValidation;
using Imdb.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.BLL.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Olamaz");
            RuleFor(p => p.CountryID).NotEmpty().WithMessage("Ülke Alanı Boş Olamaz");
            RuleFor(p => p.RoleID).NotEmpty().WithMessage("Role Alanı Boş Olamaz");
        }
    }
}
