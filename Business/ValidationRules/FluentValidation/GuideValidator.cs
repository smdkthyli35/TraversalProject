using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(g => g.Name).NotEmpty().WithMessage("İsim alanı boş geçilmemelidir.");
            RuleFor(g => g.Name).MinimumLength(2).WithMessage("İsim alanı en az 2 karakterden oluşmalıdır.");
            RuleFor(g => g.Name).MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(g => g.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(g => g.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(g => g.Description).MaximumLength(300).WithMessage("Açıklama alanı en fazla 300 karakterden oluşmalıdır.");

            RuleFor(g => g.Image).NotEmpty().WithMessage("Resim alanı boş geçilmemelidir.");
            RuleFor(g => g.Image).MaximumLength(250).WithMessage("Resim alanı en fazla 250 karakterden oluşmalıdır.");

            RuleFor(g => g.TwitterUrl).MinimumLength(5).WithMessage("Twitter Url alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(g => g.TwitterUrl).MaximumLength(50).WithMessage("Twitter Url alanı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(g => g.InstagramUrl).MinimumLength(5).WithMessage("Instagram Url alanı en az 5 karakterden oluşmalıdır.");
            RuleFor(g => g.InstagramUrl).MaximumLength(50).WithMessage("Instagram Url alanı en fazla 50 karakterden oluşmalıdır.");
        }
    }
}
