using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OtherFeatureValidator : AbstractValidator<OtherFeature>
    {
        public OtherFeatureValidator()
        {
            RuleFor(o => o.Title).NotEmpty().WithMessage("Başlık alanı boş geçilmemelidir.");
            RuleFor(o => o.Title).MinimumLength(5).WithMessage("Başlık alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(o => o.Title).MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(o => o.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(o => o.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(o => o.Description).MaximumLength(300).WithMessage("Açıklama alanı en fazla 500 karakterden oluşmalıdır.");

            RuleFor(o => o.Image).NotEmpty().WithMessage("Resim alanı boş geçilmemelidir.");
            RuleFor(o => o.Image).MaximumLength(250).WithMessage("Resim alanı en fazla 250 karakterden oluşmalıdır.");
        }
    }
}
