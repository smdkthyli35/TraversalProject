using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DestinationValidator : AbstractValidator<Destination>
    {
        public DestinationValidator()
        {
            RuleFor(d => d.City).NotEmpty().WithMessage("Şehir alanı boş geçilmemelidir.");
            RuleFor(d => d.City).MinimumLength(3).WithMessage("Şehir alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(d => d.City).MaximumLength(100).WithMessage("Şehir alanı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(d => d.DayNight).NotEmpty().WithMessage("Kalınacak gün sayısı alanı boş geçilmemelidir.");
            RuleFor(d => d.DayNight).MinimumLength(2).WithMessage("Kalınacak gün sayısı alanı en az 2 karakterden oluşmalıdır.");
            RuleFor(d => d.DayNight).MaximumLength(50).WithMessage("Kalınacak gün sayısı alanı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(d => d.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilmemelidir.");

            RuleFor(d => d.Image).NotEmpty().WithMessage("Şehir alanı boş geçilmemelidir.");
            RuleFor(d => d.Image).MaximumLength(250).WithMessage("Şehir alanı en fazla 250 karakterden oluşmalıdır.");

            RuleFor(d => d.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilmemelidir.");
            RuleFor(d => d.Description).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakterden oluşmalıdır.");

            RuleFor(d => d.Capacity).NotEmpty().WithMessage("Kapasite alanı boş geçilmemelidir.");
        }
    }
}
