using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(f => f.Title).NotEmpty().WithMessage("Başlık alanı boş geçilmemelidir.");
            RuleFor(f => f.Title).MinimumLength(5).WithMessage("Başlık alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(f => f.Title).MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(f => f.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(f => f.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");

            RuleFor(f => f.Image).NotEmpty().WithMessage("Resim alanı boş geçilmemelidir.");
            RuleFor(f => f.Image).MaximumLength(250).WithMessage("Resim alanı en fazla 250 karakterden oluşmalıdır.");
        }
    }
}
