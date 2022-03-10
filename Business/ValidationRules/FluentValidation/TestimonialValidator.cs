using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(t => t.Client).NotEmpty().WithMessage("Müşteri alanı boş geçilmemelidir.");
            RuleFor(t => t.Client).MinimumLength(3).WithMessage("Müşteri alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(t => t.Client).MaximumLength(200).WithMessage("Müşteri alanı en fazla 200 karakterden oluşmalıdır.");

            RuleFor(t => t.Comment).NotEmpty().WithMessage("Yorum alanı boş geçilmemelidir.");
            RuleFor(t => t.Comment).MinimumLength(3).WithMessage("Yorum alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(t => t.Comment).MaximumLength(500).WithMessage("Yorum alanı en fazla 500 karakterden oluşmalıdır.");

            RuleFor(t => t.ClientImage).NotEmpty().WithMessage("Resim alanı boş geçilmemelidir.");
            RuleFor(t => t.ClientImage).MaximumLength(250).WithMessage("Resim alanı en fazla 250 karakterden oluşmalıdır.");
        }
    }
}
