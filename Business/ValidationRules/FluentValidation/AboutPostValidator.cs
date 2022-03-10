using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutPostValidator : AbstractValidator<AboutPost>
    {
        public AboutPostValidator()
        {
            RuleFor(a => a.FirstTitle).NotEmpty().WithMessage("Başlık alanı boş geçilmemelidir.");
            RuleFor(a => a.FirstTitle).MinimumLength(5).WithMessage("Başlık alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(a => a.FirstTitle).MaximumLength(100).WithMessage("Başlık en fazla 100 karakterden oluşmalıdır.");

            RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(a => a.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");

            RuleFor(a => a.Image).NotEmpty().WithMessage("Resim alanı boş geçilmemelidir.");
            RuleFor(a => a.Image).MaximumLength(300).WithMessage("Resim alanı en fazla 300 karakterden oluşmalıdır.");

            RuleFor(a => a.SecondTitle).NotEmpty().WithMessage("Başlık alanı boş geçilmemelidir.");
            RuleFor(a => a.SecondTitle).MinimumLength(5).WithMessage("Başlık alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(a => a.SecondTitle).MaximumLength(100).WithMessage("Başlık en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
