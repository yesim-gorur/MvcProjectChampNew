using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("yazar soyadını boş geçemezsiniz");

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("unvan kısmında boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("lütfen  2 karakterden fazla giriş yapın");
        }
    }
}
