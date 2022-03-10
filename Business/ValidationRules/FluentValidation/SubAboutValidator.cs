using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SubAboutValidator : AbstractValidator<SubAbout>
    {
        public SubAboutValidator()
        {
            RuleFor(s => s.Title).NotEmpty().WithMessage("Başlık alanı boş geçilmemelidir.");
            RuleFor(s => s.Title).MinimumLength(5).WithMessage("Başlık alanı alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(s => s.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakterden oluşmalıdır.");

            RuleFor(s => s.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(s => s.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(s => s.Description).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakterden oluşmalıdır.");
        }
    }
}
