using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsletterValidator : AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(n => n.Mail).NotEmpty().WithMessage("Mail alanı boş geçilmemelidir.");
            RuleFor(n => n.Mail).MinimumLength(10).WithMessage("Mail alanı en az 10 karakterden oluşmalıdır.");
            RuleFor(n => n.Mail).MaximumLength(100).WithMessage("Mail alanı en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
