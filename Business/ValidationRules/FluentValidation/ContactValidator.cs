using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(c => c.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(c => c.Description).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakterden oluşmalıdır");

            RuleFor(c => c.Mail).NotEmpty().WithMessage("Mail alanı boş geçilmemelidir.");
            RuleFor(c => c.Mail).MinimumLength(10).WithMessage("Mail alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(c => c.Mail).MaximumLength(50).WithMessage("Mail alanı en fazla 50 karakterden oluşmalıdır");

            RuleFor(c => c.Address).NotEmpty().WithMessage("Adres alanı boş geçilmemelidir.");
            RuleFor(c => c.Address).MaximumLength(300).WithMessage("Adres alanı en fazla 300 karakterden oluşmalıdır");

            RuleFor(c => c.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilmemelidir.");
            RuleFor(c => c.Phone).MinimumLength(11).WithMessage("Telefon alanı en az 11 karakterden oluşmalıdır.");
            RuleFor(c => c.Phone).MaximumLength(15).WithMessage("Telefon alanı en fazla 15 karakterden oluşmalıdır");

            RuleFor(c => c.MapLocation).NotEmpty().WithMessage("Harita lokasyonu alanı boş geçilmemelidir.");
            RuleFor(c => c.MapLocation).MinimumLength(5).WithMessage("Harita lokasyonu alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(c => c.MapLocation).MaximumLength(300).WithMessage("Harita lokasyonu alanı en fazla 300 karakterden oluşmalıdır");
        }
    }
}
